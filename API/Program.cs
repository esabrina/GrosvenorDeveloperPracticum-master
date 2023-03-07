using API.Configuration;
using Application.Contracts;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerConfig();
builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks().AddCheck("self", () => HealthCheckResult.Healthy(), tags: new[] { "self" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction()) app.UseCustomSwaggerConfig();

app.UseHttpsRedirection();
app.MapCustomHealthCheck();


/// <summary>
///     Request order
/// </summary>
/// <param name="order">string with daytime menu and comma delimited list of dishes.</param>
/// <response code="200">Returns a list with dish names</response>
/// <response code="400">Bad requestl</response>
app.MapPost("/order", async (IServer _server, [FromBody] RequestOrderDto request) =>
{
    var dishes = (request.Dishes != null) ? string.Join(",", request.Dishes.Select(n => n.ToString()).ToArray()) : string.Empty;
    var task = Task.Run(() => _server.TakeOrder($"{request.Menu},{dishes}"));
    var output = await task;
    return output == "error" ? Results.BadRequest(output) : Results.Ok(output.Split(','));
})
    .WithSummary("Request order")
    .WithDescription("Request an order with the menu and a list (integer) of dishes.")
    .Produces<List<string>>(StatusCodes.Status200OK).Produces(StatusCodes.Status400BadRequest)
.WithOpenApi(); 

app.Run();


public partial class Program { }
