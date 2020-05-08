using System;
using System.Linq;
using api.Infrastructure.ModelBinders;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Infrastructure.SwaggerVersioning
{
    public class DateTimeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            var p = context.ApiDescription.ActionDescriptor.Parameters;
            var dateTimeParamNames = context.ApiDescription.ActionDescriptor.Parameters
                .Where(parameter => parameter.BindingInfo.BinderType == typeof(UnixDateTimeModelBinder))
                .Select(x => x.Name)
                .ToList();
            if (!dateTimeParamNames.Any())
                return;

            foreach (var param in operation.Parameters.ToList())
            {
                foreach (var dateParam in dateTimeParamNames)
                {
                    if (param.Name == dateParam)
                    {
                        if (param is OpenApiParameter)
                        {
                            (param as OpenApiParameter).Schema.Format = null;
                        }
                    }
                }
            }
        }
    }
}
