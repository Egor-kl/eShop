using System;
using Microsoft.Extensions.DependencyInjection;
using Profile.API.Common.Interfaces;
using Profile.API.Infrastructure;
using Profile.API.Services;
using Serilog;

namespace Profile.API.Common.Extensions
{
    public static class DependencyInjectionProfile
    {
        /// <summary>
        ///     Add scoped services.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <returns>Services.</returns>
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileContext, ProfileContext>();
            services.AddScoped<IProfileService, ProfileService>();

            return services;
        }

        public static IServiceCollection AddSerilogService(this IServiceCollection services)
        {
            ILogerService serilogConfiguration = new SerilogService();
            Log.Logger = serilogConfiguration.SerilogConfiguration();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();

            return services.AddSingleton(Log.Logger);
        }
    }
}