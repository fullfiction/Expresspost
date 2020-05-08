using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Infrastructure.SwaggerVersioning
{
    public static class IServiceCollectionExtensions
    {

        public static void ConfigureSwaggerAndVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();
                    options.OperationFilter<DateTimeOperationFilter>();
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
