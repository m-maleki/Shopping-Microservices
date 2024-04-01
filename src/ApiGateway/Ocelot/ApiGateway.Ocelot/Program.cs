using Ocelot.Middleware;
using HealthChecks.UI.Client;
using Logging;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

builder.Services.AddSerilog(builder.Configuration);

builder.Services.AddOcelot(configuration)
    .AddCacheManager(settings => settings.WithDictionaryHandle());

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MapControllers();

app.UseRouting();

#region HealthCheck

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

#endregion

app.UseEndpoints(endpoints =>
{
    IEndpointConventionBuilder endpointConventionBuilder =
        endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Ocelot ApiGateway");
        });
});

app.UseCors(Option =>
{
    Option.AllowAnyMethod();
    Option.AllowAnyHeader();
    Option.AllowAnyOrigin();
});

app.UseErrorLogging();

await app.UseOcelot();

app.Run();
