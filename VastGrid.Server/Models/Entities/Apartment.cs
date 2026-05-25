using System.Collections.Generic;

namespace VastGrid.Server.Models.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string BlockName { get; set; } = string.Empty;
        public int TotalFlats { get; set; }
        
        // Foreign Key
        public int BuilderId { get; set; }

        // Navigation Properties
        public Builder Builder { get; set; } = null!;
        public ICollection<Resident> Residents { get; set; } = new List<Resident>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
        
        // Fix for CS1061: Apartment does not contain a definition for 'Tickets'
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
