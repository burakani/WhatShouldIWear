namespace WhatShouldIWear.Services
{
    using Microsoft.Extensions.Options;
    using System.Text.Json;
    using System.Threading.Tasks;
    using WhatShouldIWear.Configuration;
    using WhatShouldIWear.Models;
    using WhatShouldIWear.Services.Interfaces;

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<OpenWeatherSettings> _settings;

        public WeatherService(HttpClient httpClient, IOptions<OpenWeatherSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        /// <summary>
        /// Get weather information for a given city
        /// </summary>
        public async Task<WeatherInfoModel> GetWeatherAsync(string city)
        {
            var response = await _httpClient.GetAsync($"weather?q={city}&appid={_settings.Value.ApiKey}&units=metric");

            if (response == null)
            {
                //Logging
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<OpenWeatherResponse>(content);

            return new WeatherInfoModel
            {
                City = city,
                Description = weatherData?.Weather?.FirstOrDefault()?.Description ?? "Unknown",
                Temperature = weatherData?.Main?.Temp ?? 0
            };
        }
    }
}
