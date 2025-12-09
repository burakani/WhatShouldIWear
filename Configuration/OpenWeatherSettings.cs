namespace WhatShouldIWear.Configuration
{
    public class OpenWeatherSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public int TimeoutSeconds { get; set; } = 30;
    }
}
