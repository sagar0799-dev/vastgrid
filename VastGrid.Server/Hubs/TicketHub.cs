using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VastGrid.Server.Hubs
{
    /**
     * TicketHub
     * Real-time alerts for maintenance ticketing.
     */
    public class TicketHub : Hub
    {
        public async Task JoinManagerGroup() => await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
        public async Task JoinTechnicianGroup() => await Groups.AddToGroupAsync(Context.ConnectionId, "Technicians");
    }
}
