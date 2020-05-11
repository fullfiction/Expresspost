using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Infrastructure.Security
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurtiyOptions>(configuration.GetSection("security"));
            services.AddScoped<JWTokenService>();
        }
    }
}
