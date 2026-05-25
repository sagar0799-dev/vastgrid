using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VastGrid.Server.Interfaces;

namespace VastGrid.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuraAIController : ControllerBase
    {
        private readonly IAuraAIService _aiService;

        public AuraAIController(IAuraAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("analyze")]
        public async Task<ActionResult<AuraAIDiagnosisDto>> Analyze([FromBody] string base64Image)
        {
            if (string.IsNullOrEmpty(base64Image)) return BadRequest("Image data required.");
            var result = await _aiService.AnalyzeImageAsync(base64Image);
            return Ok(result);
        }
    }
}
