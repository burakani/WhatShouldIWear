namespace WhatShouldIWear.Services
{
    using WhatShouldIWear.Models;
    using WhatShouldIWear.Services.Interfaces;

    public class OutfitSuggestionService : IOutfitSuggestionService
    {
        private readonly IWeatherService _weatherService;
        private readonly IAiService _aiService;

        public OutfitSuggestionService(IWeatherService weatherService, IAiService aiService)
        {
            _weatherService = weatherService;
            _aiService = aiService;
        }

        public async Task<string> GetOutfitSuggestion(OutfitSuggestionRequestModel request)
        {
            var weatherInfo = await _weatherService.GetWeatherAsync(request.City);

            if (weatherInfo == null)
            {
                return "Weather info fetch error!";
            }

            string prompt = $@"
                Act as a professional fashion stylist.
                
                User Profile:
                - Gender: {request.Gender}
                - Style Preference: {request.Style}
                - Occasion: {request.Occasion}
                
                Current Weather in {weatherInfo.City}:
                - Condition: {weatherInfo.Description}
                - Temperature: {weatherInfo.Temperature}°C

                Based on this, suggest a complete outfit including top, bottom, shoes, and accessories.
                Explain why this outfit fits the weather and occasion.

                IMPORTANT: Return the response ONLY in raw JSON format (no markdown, no ```json tags).
                Structure:
                {{
                    ""outfitName"": ""Name of the look"",
                    ""items"": [""Item 1"", ""Item 2"", ""Item 3""],
                    ""reasoning"": ""Your explanation here""
                }}
            ";

            var suggestion = await _aiService.GetOutfitRecommendationAsync(prompt);

            return suggestion;
        }
    }
}
