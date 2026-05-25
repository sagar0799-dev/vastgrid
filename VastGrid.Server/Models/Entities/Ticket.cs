namespace VastGrid.Server.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Resolved
        public string Priority { get; set; } = "Normal"; // Normal, Urgent
        public string AssignedTo { get; set; } = string.Empty; // Technician Name
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relationship to Apartment
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

        // AuraAI Metadata
        public int ResidentId { get; set; }
        public Resident? Resident { get; set; }
        public string? ImageUrl { get; set; }
        public string? DiagnosisResult { get; set; }
        public string Severity { get; set; } = "Small"; // Small (DIY), Big (Escalated)
    }
}
