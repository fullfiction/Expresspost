using System.Text.Json.Serialization;
using api.Infrastructure.JsonConverters;
using api.Infrastructure.ModelBinders;
using api.Infrastructure.SwaggerVersioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace api.Infrastructure.Extensions.SwaggerVersioning
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, ILoggerFactory loggerFactory)
        {
            services.AddControllers(options => options.ModelBinderProviders.Add(new UnixDateTimeModelBinderProvider(loggerFactory)))
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new UnixDateTimeJsonConverterFactory());
                });
            services.ConfigureSwaggerAndVersioning();
        }
    }
}
