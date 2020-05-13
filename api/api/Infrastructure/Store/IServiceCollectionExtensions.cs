using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace api.Infrastructure.Store
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureStore(this IServiceCollection services, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Store"));
                options.UseLoggerFactory(loggerFactory);
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
