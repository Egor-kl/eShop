using AutoMapper;
using Identity.API.Common.Extensions;
using Identity.Common.Extensions;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(x => x.UseNpgsql(Configuration.GetConnectionString("HerokuPostgres")));
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            
            services.AddScopedServices();
            services.AddSerilogService();
            services.AddJwtService(Configuration);
            services.AddSwaggerService();
            
            services.AddOpenTracing();
            services.AddJaegerService(Configuration, Environment);
            services.AddEventBusService(Configuration, Environment);

            services.AddCors();
            services.AddHealthChecks();
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

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API version 1"));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/health");
                });
        }
    }
}