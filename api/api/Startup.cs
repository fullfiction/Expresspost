using api.Core.Extensions;
using api.Infrastructure.Extensions;
using api.Infrastructure.Extensions.SwaggerVersioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILoggerFactory LoggerFactory { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                LoggerFactory = scope.ServiceProvider.GetService<ILoggerFactory>();
            }
            services.ConfigureCore();
            services.ConfigureInfrastructure(LoggerFactory, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseInfrastructureMiddlwares(env, provider);
        }
    }
}
