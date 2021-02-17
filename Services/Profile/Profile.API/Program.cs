using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Profile.API.Common.Interfaces;
using Profile.API.Services;
using Serilog;

namespace Profile.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogerService serilogConfiguration = new SerilogService();
            Log.Logger = serilogConfiguration.SerilogConfiguration();

            try
            {
                Log.Information("Start web host");
                var host = CreateHostBuilder(args).Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Web host terminated");
            }
            finally
            {
                Log.Information("Web host stop.");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseSerilog();
    }
}