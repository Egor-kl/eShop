using System;
using Basket.API.Common.Interfaces;
using Basket.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Basket.API.Common.Extensions
{
    public static class DependencyInjectionBasket
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