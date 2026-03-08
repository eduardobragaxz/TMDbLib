using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

/// <summary>
/// JSON converter for enum values that gracefully handles unrecognized values by falling back to defaults.
/// </summary>
public class TolerantEnumConverter : JsonConverter<object>
{
    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <returns>True if this converter can convert the type; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        var type = IsNullableType(typeToConvert) ? Nullable.GetUnderlyingType(typeToConvert) : typeToConvert;
        return type is not null && type.GetTypeInfo().IsEnum;
    }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <param name="options">The calling serializer.</param>
    /// <returns>The parsed enum value, or a default value if parsing fails.</returns>
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var isNullable = IsNullableType(typeToConvert);
        var enumType = isNullable ? Nullable.GetUnderlyingType(typeToConvert) : typeToConvert;

        if (enumType is null)
        {
            return null;
        }

        var names = Enum.GetNames(enumType);

        if (reader.TokenType == JsonTokenType.String)
        {
            var enumText = reader.GetString();

            if (!string.IsNullOrEmpty(enumText))
            {
                var match = names.FirstOrDefault(n => string.Equals(n, enumText, StringComparison.OrdinalIgnoreCase));

                if (match is not null)
                {
                    return Enum.Parse(enumType, match);
                }
            }
        }
        else if (reader.TokenType == JsonTokenType.Number)
        {
            var enumVal = reader.GetInt32();
            var values = (int[])Enum.GetValues(enumType);
            if (values.Contains(enumVal))
            {
                return Enum.Parse(enumType, enumVal.ToString(CultureInfo.InvariantCulture));
            }
        }

        if (!isNullable)
        {
            var defaultName = names.FirstOrDefault(n => string.Equals(n, "Unknown", StringComparison.OrdinalIgnoreCase)) ?? names.First();

            return Enum.Parse(enumType, defaultName);
        }

        return null;
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The calling serializer.</param>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer?.WriteNullValue();
            return;
        }

        writer?.WriteStringValue(value.ToString());
    }

    private static bool IsNullableType(Type t)
    {
        return t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
}
