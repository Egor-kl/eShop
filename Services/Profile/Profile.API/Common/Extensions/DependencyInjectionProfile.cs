using System;
using Microsoft.Extensions.DependencyInjection;
using Profile.API.Common.Interfaces;
using Profile.API.Services;
using Serilog;

namespace Profile.API.Common.Extensions
{
    public static class DependencyInjectionProfile
    {
        public static IServiceCollection AddSerilogService(this IServiceCollection services)
        {
            ILogerService serilogConfiguration = new SerilogService();
            Log.Logger = serilogConfiguration.SerilogConfiguration();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();

            return services.AddSingleton(Log.Logger);
        }
    }
}