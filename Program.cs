using ProductApi.Api.Endpoints;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Services;
using ProductApi.Domain.Interfaces;
using ProductApi.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IWeatherForecastProvider, RandomWeatherForecastProvider>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapWeatherForecastEndpoints();

app.Run();
