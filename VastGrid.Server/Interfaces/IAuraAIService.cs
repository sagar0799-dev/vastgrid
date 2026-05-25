using System.Collections.Generic;
using System.Threading.Tasks;

namespace VastGrid.Server.Interfaces
{
    public interface IAuraAIService
    {
        Task<AuraAIDiagnosisDto> AnalyzeImageAsync(string base64Image);
    }

    public class AuraAIDiagnosisDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Severity { get; set; } = "Small"; // Small, Big
        public List<string> DiySteps { get; set; } = new();
        public double Confidence { get; set; }
    }
}
