using ApiGateway.Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        public Startup(IHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Environment = environment;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtService(Configuration);
            services.AddOcelot();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseCors(options => options.AllowAnyOrigin()
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod());
            
            app.UseAuthentication();

            app.UseOcelot().Wait();
        }
    }
}