using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;

namespace TMDbLib.Utilities.Converters;

internal class EnumStringValueConverter : JsonConverter<Enum>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.GetTypeInfo().IsEnum;
    }

    public override Enum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(MediaType))
        {
            var e = Enum.Parse<MediaType>(reader.GetString()!);
            return e;
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        var str = EnumMemberCache.GetString(value);
        writer.WriteRawValue(str!);
    }
}
