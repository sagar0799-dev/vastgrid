using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VastGrid.Server.Interfaces;

namespace VastGrid.Server.Services
{
    public class AuraAIService : IAuraAIService
    {
        public async Task<AuraAIDiagnosisDto> AnalyzeImageAsync(string base64Image)
        {
            // Simulate Neural Analysis Delay
            await Task.Delay(1500);

            // Mock logic: Randomly decide if it's a minor or major issue
            var isBig = new Random().Next(0, 2) == 1;

            if (isBig)
            {
                return new AuraAIDiagnosisDto
                {
                    Title = "Major Water Leak Detected",
                    Description = "Neural scan identifies high-pressure pipe rupture behind tile wall. Immediate intervention required.",
                    Severity = "Big",
                    Confidence = 0.98,
                    DiySteps = new List<string> { "Shut off main water valve immediately.", "Clear electronics from the area.", "Wait for emergency technician." }
                };
            }

            return new AuraAIDiagnosisDto
            {
                Title = "Minor Faucet Drip",
                Description = "Thermal analysis indicates worn washer in sink fixture. Non-critical waste detected.",
                Severity = "Small",
                Confidence = 0.92,
                DiySteps = new List<string> { "Unscrew the faucet handle.", "Replace the internal rubber washer.", "Tighten fixture and test." }
            };
        }
    }
}
