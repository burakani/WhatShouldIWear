namespace WhatShouldIWear.Services
{
    using Microsoft.Extensions.Options;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using WhatShouldIWear.Configuration;
    using WhatShouldIWear.Services.Interfaces;
    using static WhatShouldIWear.Models.AiModels;

    public class AiService : IAiService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AiSettings> _settings;

        public AiService(HttpClient httpClient, IOptions<AiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<string> GetOutfitRecommendationAsync(string prompt)
        {
            var requestBody = new GeminiRequest
            {
                Contents = new List<RequestContent>
                {
                    new RequestContent
                    {
                        Parts = new List<Part>
                        {
                            new Part { Text = _settings.Value.PromptPrefix + prompt }
                        }
                    }
                }
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"?key={_settings.Value.ApiKey}", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                return "AI is unreachable right now.";
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(responseString);

            var resultText = geminiResponse?.Candidates?.FirstOrDefault()
                             ?.Content?.Parts?.FirstOrDefault()?.Text;

            return resultText ?? "-";
        }
    }
}
