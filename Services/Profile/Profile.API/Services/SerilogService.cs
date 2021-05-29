using Microsoft.Extensions.Configuration;
using Profile.API.Common.Interfaces;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Profile.API.Services
{
    public class SerilogService : ILogerService
    {
        public Logger SerilogConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString =
                configuration[$"ConnectionStrings: {configuration.GetConnectionString("PostgreSQLConnection")}"];

            var serilogConfig =
                new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .WriteTo.Console()
                    .CreateLogger();

            return serilogConfig;
        }
    }
}