using System.Collections.Generic;
using System.Threading.Tasks;
using VastGrid.Server.Models.DTOs;

namespace VastGrid.Server.Interfaces
{
    public interface IManagerDashboardService
    {
        Task<IEnumerable<object>> GetResidentsAsync(string keycloakUserId);
        Task<IEnumerable<object>> GetStatisticsAsync(string keycloakUserId);
        Task<IEnumerable<object>> GetApartmentsAsync(string keycloakUserId);
        Task<bool> SellFlatAsync(string keycloakUserId, SellFlatDto dto);
    }
}
