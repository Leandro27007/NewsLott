
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsLott.DAL;
using NewsLott.DAL.Repositorio.Implementacion;
using NewsLott.DAL.Repositorio.Interfaces;
using NewsLott.DTOs;
using NewsLott.Servicios.Implementaciones;
using NewsLott.Servicios.Interfaces;
using NewsLott.ServiciosSegundoPlano.HostedService;
using NewsLott.ServiciosSegundoPlano.Implementaciones;
using NewsLott.ServiciosSegundoPlano.Interfaces;

var builder = WebApplication.CreateBuilder(args);
string? conexion = builder.Configuration.GetConnectionString("Conexion");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NewsLottDbContext>(c => c.UseSqlServer(conexion)/*, ServiceLifetime.Transient*/);

builder.Services.AddScoped<ILoteriaRepositorio, LoteriaRepositorio>();
builder.Services.AddScoped<IResultadoLoteriaRepositorio, ResultadoLoteriaRepositorio>();

builder.Services.AddScoped<IScrapeableWeb, PaginaWebConectate>();
builder.Services.AddScoped<IScraper, Scraper>();

builder.Services.AddSingleton<INavegador, NavegadorChrome>();
builder.Services.AddSingleton<IWebDriverWsppService, WebDriverWsppService>();
builder.Services.AddScoped<IWsppChat, WsppChat>();

builder.Services.AddHostedService<ScrapyHostedService>();
builder.Services.AddHostedService<WsppChatHostedService>();


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



app.MapGet("/GetWeatherForecast", async (IWsppChat chat) =>
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


//app.MapGet("/WsspChat/ObtenerUltimoMensajeNoLeido", (IWsppChat wsppChat) => Results.Ok(wsppChat.ObtenerMsgNoLeido()));


app.MapGet("WsppChat/BackgroupService/Interruptor", () => { bool respuesta = WsppChatHostedService.InterruptorWsppChatService(); return Results.Ok(respuesta); });

app.MapGet("/Driver/ObtenerNombre", (INavegador webDriver) => Results.Ok(webDriver.ObtenerNombreDriver()));

app.MapPost("/CerrarSesion", (IWebDriverWsppService webDriver) =>
{
    return Results.Ok(webDriver.CerrarSesionWspp());
});

app.MapPost("/CerrarDriver", (INavegador webDriver) =>
{
    return Results.Ok(webDriver.CerrarDriver());
});
app.MapPost("/ReiniciarDriver", (INavegador webDriver) =>
{
    return Results.Ok(webDriver.ReiniciarDriver());
});

app.MapPost("/vincularPorNumero", ([FromBody] string url, IWebDriverWsppService webDriver) => webDriver.VincularWsppPorNumero("8297552708"));

app.MapPost("/vincularPorQr", ([FromBody] string url, IWebDriverWsppService webDriver) => webDriver.VincularWsppPorQr());



app.MapGet("/ListarLoterias", async (ILoteriaRepositorio _lR) => 
{

    var consulta = await _lR.Consultar();

    return new CodigoEstadoDTO()
    {
        ObjRespuesta = await consulta.ToListAsync(),
        Mensaje = $"Cantidad de elementos {await consulta.CountAsync()}",
    };

});

app.MapGet("/Resultados", async (IResultadoLoteriaRepositorio _rLR) =>
{
    var consulta = await _rLR.Consultar();

    return new CodigoEstadoDTO()
    {
        ObjRespuesta = await consulta.ToListAsync(),
        Mensaje = $"Cantidad de elementos {await consulta.CountAsync()}",
    };


});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
