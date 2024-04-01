using Logging;
using HealthChecks.UI.Client;
using Microsoft.EntityFrameworkCore;
using ProductService.WebApi.DataAccess.EfCore;
using ProductService.WebApi.Services.Contracts;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ProductService.WebApi.Services.Implementations;
using ProductService.WebApi.DataAccess.Repositories.Contracts;
using ProductService.WebApi.DataAccess.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddSerilog(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connectionString));

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorLogging();

app.MapControllers();

app.UseCors(Option =>
{
    Option.AllowAnyMethod();
    Option.AllowAnyHeader();
    Option.AllowAnyOrigin();
});

app.Run();
