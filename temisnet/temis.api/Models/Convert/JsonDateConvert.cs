using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace temis.Api.Models.Convert
{
    class JsonDateConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString(),
                        "dd-MM-yyyy", CultureInfo.InvariantCulture);


            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(
                        "dd-MM-yyyy", CultureInfo.InvariantCulture));
        }
}