using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;

namespace EmployeeKnowledgeDatabase.Infrastructure.Serilog
{
    public static class Extensions
    {
        public static void AddSerilogLogging(this ILoggerFactory loggerFactory, IApplicationBuilder builder)
        {

            var options = builder.ApplicationServices.GetService<IConfiguration>()
                .GetOptions<SerilogOptions>("serilog");


            if (!Enum.TryParse<LogEventLevel>(options.Level, true, out var level))
            {
                level = LogEventLevel.Information;
            }

            var log = new LoggerConfiguration()
                .MinimumLevel.Is(level)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {SourceContext} {Message}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            loggerFactory.AddSerilog(log);
            Log.Logger = log;
        }
    }
}