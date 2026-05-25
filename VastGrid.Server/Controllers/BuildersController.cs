using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.DTOs;

namespace VastGrid.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "builder")]
    public class BuildersController : ControllerBase
    {
        private readonly IBuilderService _builderService;

        public BuildersController(IBuilderService builderService)
        {
            _builderService = builderService;
        }

        [HttpGet("portfolio")]
        public async Task<ActionResult<BuilderPortfolioDto>> GetPortfolio()
        {
            // Extract the Keycloak Sub from the JWT claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "User identity not found in security context." });
            }

            var portfolio = await _builderService.GetPortfolioAsync(userId);
            
            if (portfolio == null)
            {
                return NotFound(new { Message = "Builder profile not found for this identity." });
            }

            return Ok(portfolio);
        }
    }
}
