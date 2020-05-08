using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace api.Infrastructure.JsonConverters
{
    public class UnixDateTimeJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsAssignableFrom(typeof(DateTime));
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new UnixDateTimeJsonConverter();
        }
    }
}
