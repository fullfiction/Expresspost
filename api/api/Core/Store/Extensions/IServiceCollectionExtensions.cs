using api.Core.Store;
using Microsoft.Extensions.DependencyInjection;

namespace api.Core.Store.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureStore(this IServiceCollection services)
        {
            services.AddScoped(typeof(Store<>));
            services.AddScoped<UnitOfWork>();
        }
    }
}
