using System;

namespace VastGrid.Server.Models.Entities
{
    public class VisitorLog
    {
        public int Id { get; set; }
        public string VisitorName { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        
        // Status: Pending, Approved, Denied
        public string Status { get; set; } = "Pending";

        // Foreign Keys
        public int ResidentId { get; set; }
        public Resident? Resident { get; set; }

        public string WatchmanId { get; set; } = string.Empty; // Keycloak Sub of the watchman
    }
}
