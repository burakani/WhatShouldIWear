namespace WhatShouldIWear.Services.Interfaces
{
    using WhatShouldIWear.Models;

    public interface IWeatherService
    {
        Task<WeatherInfoModel> GetWeatherAsync(string city);
    }
}
