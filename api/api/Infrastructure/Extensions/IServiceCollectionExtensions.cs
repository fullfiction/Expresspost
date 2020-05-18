using System.Text.Json;
using System.Text.Json.Serialization;
using api.Infrastructure.JsonConverters;
using api.Infrastructure.ModelBinders;
using api.Infrastructure.Security;
using api.Infrastructure.Store;
using api.Infrastructure.SwaggerVersioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace api.Infrastructure.Extensions.SwaggerVersioning
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            services.ConfigureStore(loggerFactory, configuration);
            services.ConfigureSecurity(configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(options =>
                {
                    var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                                    .RequireAuthenticatedUser()
                                    .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                    options.ModelBinderProviders.Add(new UnixDateTimeModelBinderProvider(loggerFactory));
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new UnixDateTimeJsonConverterFactory());
                });
            services.ConfigureSwaggerAndVersioning();
        }
    }
}
