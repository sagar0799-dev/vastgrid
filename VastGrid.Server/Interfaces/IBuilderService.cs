using System.Threading.Tasks;
using VastGrid.Server.Models.DTOs;

namespace VastGrid.Server.Interfaces
{
    public interface IBuilderService
    {
        Task<BuilderPortfolioDto> GetPortfolioAsync(string keycloakUserId);
    }
}
