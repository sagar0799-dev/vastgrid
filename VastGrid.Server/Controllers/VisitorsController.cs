using System.Collections.Generic;
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
    [Authorize]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorsController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpPost("check-in")]
        [Authorize(Roles = "watchman")]
        public async Task<ActionResult<VisitorLogDto>> CheckIn([FromBody] VisitorCheckInDto dto)
        {
            var watchmanId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(watchmanId)) return Unauthorized();

            var result = await _visitorService.LogVisitorArrivalAsync(watchmanId, dto);
            return Ok(result);
        }

        [HttpPatch("respond/{logId}")]
        [Authorize(Roles = "resident")]
        public async Task<ActionResult> Respond(int logId, [FromQuery] string status)
        {
            if (status != "Approved" && status != "Denied") return BadRequest("Invalid status.");

            var success = await _visitorService.UpdateVisitorStatusAsync(logId, status);
            return success ? Ok() : NotFound();
        }

        [HttpGet("history")]
        [Authorize(Roles = "resident")]
        public async Task<ActionResult<IEnumerable<VisitorLogDto>>> GetHistory()
        {
            var residentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(residentId)) return Unauthorized();

            var history = await _visitorService.GetResidentHistoryAsync(residentId);
            return Ok(history);
        }

        [HttpGet("my-pending")]
        [Authorize(Roles = "resident")]
        public async Task<ActionResult<IEnumerable<VisitorLogDto>>> GetMyPending()
        {
            var residentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(residentId)) return Unauthorized();

            var pending = await _visitorService.GetResidentPendingVisitorsAsync(residentId);
            return Ok(pending);
        }

        [HttpGet("pending")]
        [Authorize(Roles = "watchman")]
        public async Task<ActionResult<IEnumerable<VisitorLogDto>>> GetPending()
        {
            var pending = await _visitorService.GetPendingVisitorsAsync();
            return Ok(pending);
        }
    }
}
