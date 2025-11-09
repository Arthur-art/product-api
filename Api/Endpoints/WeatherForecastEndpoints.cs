using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ProductApi.Application.Interfaces;

namespace ProductApi.Api.Endpoints;

public static class WeatherForecastEndpoints
{
    private const int DefaultDays = 5;

    public static IEndpointRouteBuilder MapWeatherForecastEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/weatherforecast", async (IWeatherForecastService service, CancellationToken cancellationToken) =>
        {
            var forecasts = await service.GetForecastAsync(DefaultDays, cancellationToken);
            return Results.Ok(forecasts);
        })
        .WithName("GetWeatherForecast");

        return endpoints;
    }
}

