using ProductApi.Domain.Entities;

namespace ProductApi.Domain.Interfaces;

public interface IWeatherForecastProvider
{
    Task<IReadOnlyList<WeatherForecast>> GetForecastAsync(int days, CancellationToken cancellationToken = default);
}

