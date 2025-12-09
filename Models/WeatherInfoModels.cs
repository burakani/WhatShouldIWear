namespace WhatShouldIWear.Models
{
    using System.Text.Json.Serialization;

    public class OpenWeatherResponse
    {
        [JsonPropertyName("weather")]
        public List<WeatherDescription> Weather { get; set; }

        [JsonPropertyName("main")]
        public MainData Main { get; set; }
    }

    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class MainData
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }

    /// <summary>
    /// Simplified weather info model
    /// </summary>
    public class WeatherInfoModel
    {
        public string Description { get; set; }
        public double Temperature { get; set; }
        public string City { get; set; }
    }
}
