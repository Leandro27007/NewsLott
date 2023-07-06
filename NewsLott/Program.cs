using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NewsLott.Datos;
using NewsLott.ServiciosSegundoPlano.HostedService;
using NewsLott.ServiciosSegundoPlano.Implementaciones;
using NewsLott.ServiciosSegundoPlano.Interfaces;

var builder = WebApplication.CreateBuilder(args);
string? conexion = builder.Configuration.GetConnectionString("Conexion");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NewsLottDbContext>(c => c.UseSqlServer(conexion), ServiceLifetime.Transient);
builder.Services.AddScoped<IResultadoWebScrapy, ResultadoWebScrappy>();
builder.Services.AddHostedService<ScrapyHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};



app.MapGet("/weatherforecast", async (NewsLottDbContext context, IResultadoWebScrapy resultadoWebScrapy) =>
{




    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
