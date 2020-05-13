using System;
using api.Core.Services.Extensions;
using api.Core.Store.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace api.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureCore(this IServiceCollection services)
        {
            services.ConfigureStore();
            services.ConfigureServices();
        }
    }
}
