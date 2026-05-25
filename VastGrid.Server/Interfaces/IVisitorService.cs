using System.Collections.Generic;
using System.Threading.Tasks;
using VastGrid.Server.Models.DTOs;

namespace VastGrid.Server.Interfaces
{
    public interface IVisitorService
    {
        Task<VisitorLogDto> LogVisitorArrivalAsync(string watchmanId, VisitorCheckInDto dto);
        Task<bool> UpdateVisitorStatusAsync(int logId, string status);
        Task<IEnumerable<VisitorLogDto>> GetResidentHistoryAsync(string keycloakUserId);
        Task<IEnumerable<VisitorLogDto>> GetResidentPendingVisitorsAsync(string keycloakUserId);
        Task<IEnumerable<VisitorLogDto>> GetPendingVisitorsAsync();
    }
}
