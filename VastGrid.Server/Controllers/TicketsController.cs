using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("mine")]
        [Authorize(Roles = "resident")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetResidentTickets()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            return Ok(await _ticketService.GetResidentTicketsAsync(userId));
        }

        [HttpGet("managed")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetManagerTickets()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            return Ok(await _ticketService.GetManagerTicketsAsync(userId));
        }

        [HttpPost("escalate")]
        [Authorize(Roles = "resident")]
        public async Task<ActionResult<Ticket>> Escalate([FromBody] EscalationRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var ticket = await _ticketService.CreateAiEscalatedTicketAsync(
                userId, 
                request.Title, 
                request.Description, 
                request.ImageUrl, 
                request.Diagnosis
            );

            return Ok(ticket);
        }
    }

    public class EscalationRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
    }
}
