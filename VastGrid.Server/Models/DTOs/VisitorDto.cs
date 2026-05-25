namespace VastGrid.Server.Models.DTOs
{
    public class VisitorCheckInDto
    {
        public string VisitorName { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public int ResidentId { get; set; }
    }

    public class VisitorLogDto
    {
        public int Id { get; set; }
        public string VisitorName { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ResidentName { get; set; } = string.Empty;
        public string ResidentPhone { get; set; } = string.Empty;
        public string ApartmentBlock { get; set; } = string.Empty;
    }
}
