using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApartmentsController(IApartmentService apartmentService, ILogger<ApartmentsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartment>>> GetApartments()
        {
            try
            {
                var apartments = await apartmentService.GetApartmentsAsync();
                return Ok(apartments);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to retrieve apartments.");
                return StatusCode(500, new { Message = "An unexpected error occurred while retrieving apartments." });
            }
        }
    }
}
