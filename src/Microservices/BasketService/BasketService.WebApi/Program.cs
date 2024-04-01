using Logging;
using StackExchange.Redis;
using HealthChecks.UI.Client;
using BasketService.WebApi.Services.Contracts;
using BasketService.WebApi.Services.Implementations;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using BasketService.WebApi.DataAccess.Repositories.Contracts;
using BasketService.WebApi.DataAccess.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSerilog(builder.Configuration);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketServices, BasketServices>();

builder.Services.AddScoped<IDiscountServices, DiscountServices>();


builder.Services.AddHttpClient("Discount", client =>
{
client.BaseAddress = new Uri("https://localhost:7220/");
});


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("CacheSettings:ConnectionString");
    options.ConfigurationOptions = new ConfigurationOptions
    {
        Password = "",
        ConnectRetry = 5,
        AbortOnConnectFail = false,
        ConnectTimeout = 5000,
        SyncTimeout = 5000,
        DefaultDatabase = 0,
        AllowAdmin = true,
    };
    options.ConfigurationOptions.EndPoints.Add("localhost:6379");
});

builder.Services.AddHealthChecks();

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

app.UseHttpsRedirection();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseAuthorization();

app.MapControllers();

app.UseErrorLogging();

app.Run();
