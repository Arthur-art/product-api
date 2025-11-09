using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Infrastructure.Providers;

public sealed class RandomWeatherForecastProvider : IWeatherForecastProvider
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public Task<IReadOnlyList<WeatherForecast>> GetForecastAsync(int days, CancellationToken cancellationToken = default)
    {
        var forecasts = Enumerable
            .Range(1, days)
            .Select(index => new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]))
            .ToArray();

        return Task.FromResult<IReadOnlyList<WeatherForecast>>(forecasts);
    }
}

