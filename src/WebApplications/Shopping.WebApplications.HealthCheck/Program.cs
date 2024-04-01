using Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog(builder.Configuration);

builder.Services.AddHealthChecks();

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapHealthChecksUI();

app.MapGet("/", () => Results.Redirect("/healthchecks-ui"));

app.UseErrorLogging();

app.Run();
