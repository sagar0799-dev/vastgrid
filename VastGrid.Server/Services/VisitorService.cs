using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VastGrid.Server.Data;
using VastGrid.Server.Hubs;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.DTOs;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly VastGridDbContext _context;
        private readonly IHubContext<VisitorHub> _hubContext;
        private readonly ILogger<VisitorService> _logger;

        public VisitorService(VastGridDbContext context, IHubContext<VisitorHub> hubContext, ILogger<VisitorService> logger)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<VisitorLogDto> LogVisitorArrivalAsync(string watchmanId, VisitorCheckInDto dto)
        {
            _logger.LogInformation("Processing visitor check-in for {VisitorName} to Resident {ResidentId}", dto.VisitorName, dto.ResidentId);

            var resident = await _context.Residents
                .Include(r => r.Apartment)
                .FirstOrDefaultAsync(r => r.Id == dto.ResidentId);

            if (resident == null)
            {
                _logger.LogWarning("Visitor check-in failed: Resident {ResidentId} not found", dto.ResidentId);
                throw new KeyNotFoundException("Resident not found.");
            }

            var log = new VisitorLog
            {
                VisitorName = dto.VisitorName,
                Purpose = dto.Purpose,
                ResidentId = dto.ResidentId,
                WatchmanId = watchmanId,
                Status = "Pending",
                Timestamp = DateTime.UtcNow
            };

            _context.VisitorLogs.Add(log);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Visitor log {LogId} created successfully for {VisitorName}", log.Id, log.VisitorName);

            var result = MapToDto(log, resident);

            // Broadcast to Resident's SignalR Group
            await _hubContext.Clients.Group($"Resident_{resident.KeycloakUserId}")
                .SendAsync("ReceiveVisitorRequest", result);

            _logger.LogDebug("SignalR notification dispatched to Resident {ResidentId} for Visitor {LogId}", resident.KeycloakUserId, log.Id);

            return result;
        }

        public async Task<bool> UpdateVisitorStatusAsync(int logId, string status)
        {
            _logger.LogInformation("Updating visitor log {LogId} status to {Status}", logId, status);

            var log = await _context.VisitorLogs
                .Include(l => l.Resident)
                .FirstOrDefaultAsync(l => l.Id == logId);

            if (log == null)
            {
                _logger.LogWarning("Failed to update status: Visitor log {LogId} not found", logId);
                return false;
            }

            log.Status = status;
            await _context.SaveChangesAsync();

            // Broadcast back to Watchmen
            await _hubContext.Clients.Group("Watchmen")
                .SendAsync("ReceiveStatusUpdate", new { LogId = logId, Status = status });

            _logger.LogInformation("Visitor log {LogId} status confirmed as {Status}", logId, status);

            return true;
        }

        public async Task<IEnumerable<VisitorLogDto>> GetResidentHistoryAsync(string keycloakUserId)
        {
            return await _context.VisitorLogs
                .Include(l => l.Resident)
                .ThenInclude(r => r!.Apartment)
                .Where(l => l.Resident != null && l.Resident.KeycloakUserId == keycloakUserId)
                .OrderByDescending(l => l.Timestamp)
                .Select(l => MapToDto(l, l.Resident!))
                .ToListAsync();
        }

        public async Task<IEnumerable<VisitorLogDto>> GetResidentPendingVisitorsAsync(string keycloakUserId)
        {
            return await _context.VisitorLogs
                .Include(l => l.Resident)
                .ThenInclude(r => r!.Apartment)
                .Where(l => l.Resident != null && l.Resident.KeycloakUserId == keycloakUserId && l.Status == "Pending")
                .OrderByDescending(l => l.Timestamp)
                .Select(l => MapToDto(l, l.Resident!))
                .ToListAsync();
        }

        public async Task<IEnumerable<VisitorLogDto>> GetPendingVisitorsAsync()
        {
            return await _context.VisitorLogs
                .Include(l => l.Resident)
                .ThenInclude(r => r!.Apartment)
                .Where(l => l.Status == "Pending" && l.Resident != null)
                .Select(l => MapToDto(l, l.Resident!))
                .ToListAsync();
        }

        private static VisitorLogDto MapToDto(VisitorLog log, Resident resident)
        {
            return new VisitorLogDto
            {
                Id = log.Id,
                VisitorName = log.VisitorName,
                Purpose = log.Purpose,
                Timestamp = log.Timestamp.ToString("o"),
                Status = log.Status,
                ResidentName = $"{resident.FirstName} {resident.LastName}",
                ResidentPhone = resident.PhoneNumber,
                ApartmentBlock = resident.Apartment?.BlockName ?? "Unknown"
            };
        }
    }
}
