using ProductApi.Application.DTOs;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Services;

public sealed class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastProvider _provider;

    public WeatherForecastService(IWeatherForecastProvider provider)
    {
        _provider = provider;
    }

    public async Task<IReadOnlyList<WeatherForecastDto>> GetForecastAsync(int days, CancellationToken cancellationToken = default)
    {
        var forecasts = await _provider.GetForecastAsync(days, cancellationToken);

        return forecasts
            .Select(forecast => new WeatherForecastDto(forecast.Date, forecast.TemperatureC, forecast.TemperatureF, forecast.Summary))
            .ToArray();
    }
}

