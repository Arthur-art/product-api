namespace ProductApi.Domain.Entities;

public sealed class WeatherForecast
{
    public WeatherForecast(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public DateOnly Date { get; }

    public int TemperatureC { get; }

    public string? Summary { get; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

