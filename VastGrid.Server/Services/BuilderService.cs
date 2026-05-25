using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VastGrid.Server.Data;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.DTOs;

namespace VastGrid.Server.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly VastGridDbContext _context;
        private readonly ILogger<BuilderService> _logger;

        public BuilderService(VastGridDbContext context, ILogger<BuilderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<BuilderPortfolioDto> GetPortfolioAsync(string keycloakUserId)
        {
            _logger.LogInformation("Synchronizing global portfolio for Builder {BuilderId}", keycloakUserId);

            var builder = await _context.Builders
                .Include(b => b.Apartments)
                    .ThenInclude(a => a.Residents)
                .Include(b => b.Apartments)
                    .ThenInclude(a => a.Tickets)
                .FirstOrDefaultAsync(b => b.KeycloakUserId == keycloakUserId);

            if (builder == null)
            {
                _logger.LogWarning("Portfolio fetch failed: Builder {BuilderId} profile not found", keycloakUserId);
                return null!;
            }

            _logger.LogDebug("Compiling analytics for {BlockCount} property blocks in portfolio", builder.Apartments.Count);

            var portfolio = new BuilderPortfolioDto
            {
                BuilderId = builder.Id,
                CompanyName = builder.CompanyName,
                Blocks = builder.Apartments.Select(a => new ApartmentPortfolioItemDto
                {
                    Id = a.Id,
                    BlockName = a.BlockName,
                    TotalFlats = a.TotalFlats,
                    OccupiedFlats = a.Residents.Count,
                    OpenTickets = a.Tickets.Count(t => t.Status != "Resolved"),
                    EstimatedMonthlyRevenue = a.Residents.Count * 1500 // Logic rule: $1500 per unit
                }).ToList()
            };

            portfolio.Summary = new PortfolioStatsDto
            {
                TotalBlocks = portfolio.Blocks.Count,
                TotalResidents = portfolio.Blocks.Sum(b => b.OccupiedFlats),
                TotalEstimatedRevenue = portfolio.Blocks.Sum(b => b.EstimatedMonthlyRevenue),
                AverageOccupancy = portfolio.Blocks.Any() ? portfolio.Blocks.Average(b => b.OccupancyRate) : 0
            };

            _logger.LogInformation("Portfolio analytics successfully generated for {CompanyName}", builder.CompanyName);

            return portfolio;
        }
    }
}
