using System.Collections.Generic;

namespace VastGrid.Server.Models.Entities
{
    public class Builder
    {
        public int Id { get; set; }
        public string? KeycloakUserId { get; set; } // Map to OIDC Sub
        public string CompanyName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
