using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VastGrid.Server.Data;
using VastGrid.Server.Hubs;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Services
{
    public class TicketService : ITicketService
    {
        private readonly VastGridDbContext _context;
        private readonly IHubContext<TicketHub> _hubContext;
        private readonly ILogger<TicketService> _logger;

        public TicketService(VastGridDbContext context, IHubContext<TicketHub> hubContext, ILogger<TicketService> logger)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync() => await _context.Tickets.ToListAsync();

        public async Task<IEnumerable<Ticket>> GetResidentTicketsAsync(string keycloakUserId)
        {
            _logger.LogInformation("Fetching ticket history for Resident {ResidentId}", keycloakUserId);
            return await _context.Tickets
                .Include(t => t.Apartment)
                .Where(t => t.Resident != null && t.Resident.KeycloakUserId == keycloakUserId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetManagerTicketsAsync(string keycloakUserId)
        {
            _logger.LogInformation("Fetching managed tickets for Manager {ManagerId}", keycloakUserId);
            // Find blocks managed by this manager
            var apartmentIds = await _context.Managers
                .Include(m => m.Apartments)
                .Where(m => m.KeycloakUserId == keycloakUserId)
                .SelectMany(m => m.Apartments.Select(a => a.Id))
                .ToListAsync();

            return await _context.Tickets
                .Include(t => t.Resident)
                .Include(t => t.Apartment)
                .Where(t => apartmentIds.Contains(t.ApartmentId))
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            _logger.LogInformation("Creating new maintenance ticket: {Title}", ticket.Title);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Ticket {TicketId} persisted successfully", ticket.Id);

            // Broadcast to Managers
            await _hubContext.Clients.Group("Managers").SendAsync("ReceiveNewTicket", ticket);
            
            _logger.LogDebug("Real-time notification dispatched to Managers for Ticket {TicketId}", ticket.Id);

            return ticket;
        }

        public async Task<Ticket> CreateAiEscalatedTicketAsync(string keycloakUserId, string title, string description, string imageUrl, string diagnosis)
        {
            _logger.LogInformation("Processing AuraAI escalation for Resident {ResidentId}", keycloakUserId);

            var resident = await _context.Residents
                .FirstOrDefaultAsync(r => r.KeycloakUserId == keycloakUserId);

            if (resident == null)
            {
                _logger.LogWarning("AI Escalation failed: Resident {ResidentId} not found", keycloakUserId);
                throw new KeyNotFoundException("Resident not found.");
            }

            var ticket = new Ticket
            {
                Title = title,
                Description = description,
                ResidentId = resident.Id,
                ApartmentId = resident.ApartmentId,
                ImageUrl = imageUrl,
                DiagnosisResult = diagnosis,
                Severity = "Big",
                Priority = "Urgent",
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _logger.LogInformation("AI escalated Ticket auto-generated for Resident {ResidentId} in Block {BlockId}", keycloakUserId, resident.ApartmentId);

            return await CreateTicketAsync(ticket);
        }
    }
}
