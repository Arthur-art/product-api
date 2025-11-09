using ProductApi.Application.DTOs;

namespace ProductApi.Application.Interfaces;

public interface IWeatherForecastService
{
    Task<IReadOnlyList<WeatherForecastDto>> GetForecastAsync(int days, CancellationToken cancellationToken = default);
}

