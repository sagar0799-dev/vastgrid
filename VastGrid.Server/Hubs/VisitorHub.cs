using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VastGrid.Server.Hubs
{
    /**
     * VisitorHub
     * Manages real-time WebSocket communication for visitor requests and approvals.
     */
    public class VisitorHub : Hub
    {
        // Join a group based on role or specific identity
        public async Task JoinResidentGroup(string residentId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Resident_{residentId}");
        }

        public async Task JoinWatchmanGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Watchmen");
        }

        // Methods for broadcasting status updates (called by the hub itself or services)
        public async Task NotifyResidentOfVisitor(string residentId, object visitorDetails)
        {
            await Clients.Group($"Resident_{residentId}").SendAsync("ReceiveVisitorRequest", visitorDetails);
        }

        public async Task NotifyWatchmanOfStatus(string watchmanId, object statusUpdate)
        {
            await Clients.Group("Watchmen").SendAsync("ReceiveStatusUpdate", statusUpdate);
        }
    }
}
