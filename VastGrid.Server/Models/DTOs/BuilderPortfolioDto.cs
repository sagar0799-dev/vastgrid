using System.Collections.Generic;

namespace VastGrid.Server.Models.DTOs
{
    public class BuilderPortfolioDto
    {
        public int BuilderId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public PortfolioStatsDto Summary { get; set; } = new();
        public List<ApartmentPortfolioItemDto> Blocks { get; set; } = new();
    }

    public class ApartmentPortfolioItemDto
    {
        public int Id { get; set; }
        public string BlockName { get; set; } = string.Empty;
        public int TotalFlats { get; set; }
        public int OccupiedFlats { get; set; }
        public double OccupancyRate => TotalFlats > 0 ? (double)OccupiedFlats / TotalFlats * 100 : 0;
        public decimal EstimatedMonthlyRevenue { get; set; }
        public int OpenTickets { get; set; }
        public string HealthStatus => OpenTickets > 5 ? "Critical" : OpenTickets > 2 ? "Warning" : "Stable";
    }

    public class PortfolioStatsDto
    {
        public int TotalBlocks { get; set; }
        public int TotalResidents { get; set; }
        public decimal TotalEstimatedRevenue { get; set; }
        public double AverageOccupancy { get; set; }
    }
}
