using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace api.Infrastructure.ModelBinders
{
    public class UnixDateTimeModelBinder : IModelBinder
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private IModelBinder SimpleModelBinder => new SimpleTypeModelBinder(typeof(DateTime), _loggerFactory);
        public UnixDateTimeModelBinder(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                var valueAsString = valueProviderResult.FirstValue;
                if (long.TryParse(valueAsString, out var seconds))
                {
                    if (seconds > 0)
                    {
                        bindingContext.Result = ModelBindingResult.Success(_epoch.AddSeconds(seconds));
                        return;
                    }
                }
            }
            await SimpleModelBinder.BindModelAsync(bindingContext);
        }
    }

    public class UnixDateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly ILoggerFactory _loggerFactory;
        public UnixDateTimeModelBinderProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return new UnixDateTimeModelBinder(_loggerFactory);
        }
    }
}
