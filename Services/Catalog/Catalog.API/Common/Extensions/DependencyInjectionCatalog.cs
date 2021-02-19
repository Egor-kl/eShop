using System;
using Catalog.API.Common.Interfaces;
using Catalog.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Catalog.API.Common.Extensions
{
    public static class DependencyInjectionCatalog
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