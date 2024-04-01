using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logging;

public static class SeriLogger
{
    public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.MSSqlServer(connectionString,
                new MSSqlServerSinkOptions
                {
                    UseSqlBulkCopy = true,
                    AutoCreateSqlDatabase = true,
                    AutoCreateSqlTable = true,
                    TableName = "ApplicationLogs",
                    BatchPostingLimit = 50,
                    BatchPeriod = TimeSpan.FromSeconds(1),
                    LevelSwitch = new LoggingLevelSwitch { MinimumLevel = LogEventLevel.Information },
                })
            .Enrich.WithMachineName()
            .Enrich.WithEnvironmentName()
            .CreateLogger();

        AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();

        return services.AddSingleton(Log.Logger);
    }
}
