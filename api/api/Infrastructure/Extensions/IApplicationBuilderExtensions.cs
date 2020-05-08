using System;
using api.Infrastructure.SwaggerVersioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Hosting;

namespace api.Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseInfrastructureMiddlwares(this IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseVersionedSwagger(provider);
        }
    }
}

