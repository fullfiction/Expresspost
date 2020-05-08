using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace api.Infrastructure.JsonConverters
{
    public class UnixDateTimeJsonConverter : JsonConverter<DateTime>
    {
        internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            bool nullable = Nullable.GetUnderlyingType(typeToConvert) != null;
            if (reader.TokenType == JsonTokenType.Null)
            {
                if (!nullable)
                {
                    throw new JsonException($"Cannot convert null value to {typeToConvert}.");
                }

                return default(DateTime);
            }

            long seconds;

            if (reader.TokenType == JsonTokenType.Number)
            {
                seconds = (long)reader.GetInt64();
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                if (!long.TryParse(reader.GetString(), out seconds))
                {
                    throw new JsonException($"Cannot convert invalid value to {typeToConvert}.");
                }
            }
            else
            {
                throw new JsonException($"Unexpected token parsing date. Expected Integer or String, got {reader.TokenType}");
            }

            DateTime d = UnixEpoch.AddSeconds(seconds);
            return d;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long seconds;
            if (value == DateTime.MinValue)
                seconds = 0;
            else
                seconds = (long)(value - UnixEpoch).TotalSeconds;
            writer.WriteNumberValue(seconds);
        }
    }
}
