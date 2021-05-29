using System;
using Jaeger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTracing.Util;
using Profile.API.Common.Settings;

namespace Profile.API.Common.Extensions
{
    public static class JaegerConfiguration
    {
        /// <summary>
        ///     Add Jaeger service.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <param name="environment">Application environment.</param>
        /// <returns>Services with configured Jaeger.</returns>
        public static IServiceCollection AddJaegerService(this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            var jaegerSettingsSection = configuration.GetSection("JaegerSettings");
            services.Configure<JaegerSettings>(jaegerSettingsSection);
            var jaegerSettings = jaegerSettingsSection.Get<JaegerSettings>();

            var agentHost = jaegerSettings.DefaultAgentHost;

            services.AddSingleton(serviceProvider =>
            {
                Environment.SetEnvironmentVariable("JAEGER_SERVICE_NAME", jaegerSettings.ServiceName);
                Environment.SetEnvironmentVariable("JAEGER_AGENT_HOST", agentHost);
                Environment.SetEnvironmentVariable("JAEGER_AGENT_PORT", jaegerSettings.AgentPort);
                Environment.SetEnvironmentVariable("JAEGER_SAMPLER_TYPE", jaegerSettings.SamplerType);

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var config = Configuration.FromEnv(loggerFactory);
                var tracer = config.GetTracer();

                if (!GlobalTracer.IsRegistered()) GlobalTracer.Register(tracer);
                return tracer;
            });
            return services;
        }
    }
}