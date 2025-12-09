namespace WhatShouldIWear
{
    using Microsoft.Extensions.Options;
    using WhatShouldIWear.Configuration;
    using WhatShouldIWear.Services;
    using WhatShouldIWear.Services.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<OpenWeatherSettings>(builder.Configuration.GetSection("OpenWeather"));
            builder.Services.Configure<AiSettings>(builder.Configuration.GetSection("Gemini"));

            builder.Services.AddHttpClient<IWeatherService, WeatherService>((serviceProvider, client) =>
            {
                var settings = serviceProvider
                    .GetRequiredService<IOptions<OpenWeatherSettings>>().Value;

                client.BaseAddress = new Uri(settings.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(settings.TimeoutSeconds);
            });

            builder.Services.AddHttpClient<IAiService, AiService>((serviceProvider, client) =>
            {
                var settings = serviceProvider
                    .GetRequiredService<IOptions<AiSettings>>().Value;

                client.BaseAddress = new Uri(settings.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(settings.TimeoutSeconds);
            });

            builder.Services.AddScoped<IOutfitSuggestionService, OutfitSuggestionService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
