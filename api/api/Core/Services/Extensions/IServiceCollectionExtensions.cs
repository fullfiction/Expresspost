using System;
using Microsoft.Extensions.DependencyInjection;

namespace api.Core.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUsernameNormalizerService, UsernameUpperNormalizer>();
            services.AddScoped<IPasswordHashService, Sha256PasswordHashService>();
            services.AddScoped<EmployeeService>();
        }
    }
}
