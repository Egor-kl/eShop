using EventBus.Common;
using EventBus.DTO;
using EventBus.Events;
using GreenPipes;
using Identity.API.Common.Settings;
using Identity.EventBus.Consumers;
using Identity.EventBus.Producers;
using MassTransit;
using MassTransit.OpenTracing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity.API.Common.Extensions
{
    public static class EventBusConfiguration
    {
        public static IServiceCollection AddEventBusService(this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            var eventBusSettingsSection = configuration.GetSection("EventBusSettings");
            var eventBusSettings = eventBusSettingsSection.Get<EventBusSettings>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserDeletedConsumer>();

                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(context);

                    var hostName = eventBusSettings.DockerHostName;
                    cfg.Host(hostName, eventBusSettings.VirtualHostName, host =>
                    {
                        host.Username(eventBusSettings.UserName);
                        host.Password(eventBusSettings.Password);
                    });

                    cfg.PropagateOpenTracingContext();

                    cfg.ReceiveEndpoint("user-events", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));

                        ep.ConfigureConsumer<UserDeletedConsumer>(context);
                    });
                }));
            });

            services.AddMassTransitHostedService();

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            services.AddScoped(typeof(IEventProducer<IProfileDeleted, int>), typeof(ProfileDeletedProducer));
            services.AddScoped(typeof(IEventProducer<IRegisterProfile, IUserDTO>), typeof(CreateProfileProducer));

            return services;
        }
    }
}