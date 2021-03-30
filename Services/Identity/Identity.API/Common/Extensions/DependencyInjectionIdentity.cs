using System;
using System.Text;
using Identity.Common.Interfaces;
using Identity.Infrastructure;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Identity.Common.Extensions
{
    public static class DependencyInjectionIdentity
    {
        /// <summary>
        /// Add scoped services.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <returns>Services.</returns>
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityContext, IdentityContext>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        /// <summary>
        /// Add Serilog Service.
        /// </summary>
        /// <param name="services">DI container.</param>
        public static IServiceCollection AddSerilogService(this IServiceCollection services)
        {
            ILogerService serilogConfiguration = new SerilogService();
            Log.Logger = serilogConfiguration.SerilogConfiguration();

            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();

            return services.AddSingleton(Log.Logger);
        }

        /// <summary>
        /// Add JWT-based authentication.
        /// </summary>
        /// <param name="services">DI container.</param>
        /// <param name="configuration">Application configuration.</param>
        public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingSection = configuration.GetSection("Settings");
            services.Configure<Settings.Settings>(appSettingSection);
            var appSettings = appSettingSection.Get<Settings.Settings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = true;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        /// <summary>
        /// Add Swagger Service.
        /// </summary>
        /// <param name="services">DI container.</param>
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Identity API",
                    Version = "v1",
                    Description = "The Identity Microservice HTTP API. This is a Data-Driven/CRUD microservice."
                });
            });
        }
    }
}