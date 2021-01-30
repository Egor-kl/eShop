using System;
using Identity.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Identity.Services
{
    public class SerilogService : ILogerService
    {
        public Logger SerilogConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = configuration[$"ConnectionStrings: {configuration.GetConnectionString("PostgreSQLConnection")}"];

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