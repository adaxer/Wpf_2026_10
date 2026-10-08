var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ForeCastService>();

builder.Services.AddAuthentication();

//builder.Services.BuildServiceProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (ForeCastService foreCastService) =>
{
    return foreCastService.GetForecasts();
});

var testService =app.Services.GetRequiredService<ForeCastService>();
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

class ForeCastService
{
    private readonly ILogger<ForeCastService> _logger;

    public ForeCastService(ILogger<ForeCastService> logger)
    {
        _logger = logger;
    }

    public WeatherForecast[] GetForecasts()
    {

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
        return forecast;
    }
}
