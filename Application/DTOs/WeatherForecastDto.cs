namespace ProductApi.Application.DTOs;

public sealed record WeatherForecastDto(DateOnly Date, int TemperatureC, int TemperatureF, string? Summary);

