namespace VastGrid.Server.Models.Entities
{
    public class Resident
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string KeycloakUserId { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty; // Contact for fallback

        // Foreign Key
        public int ApartmentId { get; set; }
        
        // Navigation Property
        public Apartment Apartment { get; set; } = null!;
    }
}
