using Logging;
using HealthChecks.UI.Client;
using DiscountService.WebApi.Services.Contracts;
using DiscountService.WebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using DiscountService.WebApi.Services.Implementations;
using DiscountService.WebApi.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog(builder.Configuration);

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDiscountServices, DiscountServices>();

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseErrorLogging();

app.Run();
