using System.Collections.Generic;
using System.Threading.Tasks;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<IEnumerable<Ticket>> GetResidentTicketsAsync(string keycloakUserId);
        Task<IEnumerable<Ticket>> GetManagerTicketsAsync(string keycloakUserId);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task<Ticket> CreateAiEscalatedTicketAsync(string keycloakUserId, string title, string description, string imageUrl, string diagnosis);
    }
}
