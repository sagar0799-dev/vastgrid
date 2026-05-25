using System.Collections.Generic;

namespace VastGrid.Server.Models.Entities
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string KeycloakUserId { get; set; } = string.Empty;

        // Navigation Property for Many-to-Many
        public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
