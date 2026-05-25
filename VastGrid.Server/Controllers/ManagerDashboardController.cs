using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.DTOs;

namespace VastGrid.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerDashboardController(IManagerDashboardService dashboardService) : ControllerBase
    {
        [HttpGet("residents")]
        [Authorize(Roles = "manager,watchman")]
        public async Task<ActionResult<IEnumerable<object>>> GetResidents()
        {
            var keycloakUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(keycloakUserId))
            {
                return Unauthorized(new { Message = "User is not authenticated." });
            }

            try
            {
                // If watchman, we can return a global list or handle differently
                // For now, let's update the service to handle role-based filtering
                var residents = await dashboardService.GetResidentsAsync(keycloakUserId);
                return Ok(residents);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("stats")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<IEnumerable<object>>> GetStatistics()
        {
            var keycloakUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(keycloakUserId))
            {
                return Unauthorized(new { Message = "User is not authenticated." });
            }

            try
            {
                var statistics = await dashboardService.GetStatisticsAsync(keycloakUserId);
                return Ok(statistics);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("apartments")]
        [Authorize(Roles = "manager,watchman")]
        public async Task<ActionResult<IEnumerable<object>>> GetApartments()
        {
            var keycloakUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(keycloakUserId))
            {
                return Unauthorized(new { Message = "User is not authenticated." });
            }

            try
            {
                var apartments = await dashboardService.GetApartmentsAsync(keycloakUserId);
                return Ok(apartments);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost("sell-flat")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> SellFlat([FromBody] SellFlatDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { Message = "Invalid resident or flat sale payload." });
            }

            var keycloakUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(keycloakUserId))
            {
                return Unauthorized(new { Message = "User is not authenticated or lacks manager role." });
            }

            try
            {
                var result = await dashboardService.SellFlatAsync(keycloakUserId, dto);
                return Ok(new { Message = "Flat sold and resident registered successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(403, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                // Handle duplicate resident registration (Keycloak Conflict)
                if (errorMessage.Contains("Conflict", StringComparison.OrdinalIgnoreCase) ||
                    errorMessage.Contains("exists with same", StringComparison.OrdinalIgnoreCase))
                {
                    if (errorMessage.Contains("email", StringComparison.OrdinalIgnoreCase))
                    {
                        return StatusCode(409, new { Message = "A resident with this email address already exists in the system." });
                    }
                    return StatusCode(409, new { Message = "A resident with this username already exists in the system." });
                }

                return BadRequest(new { Message = $"Error creating resident account in Identity Provider: {errorMessage}" });
            }
        }
    }
}
