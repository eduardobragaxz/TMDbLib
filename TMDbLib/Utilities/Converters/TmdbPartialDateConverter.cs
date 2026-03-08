using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

/// <summary>
/// JSON converter for partial or incomplete date values that may not parse correctly.
/// </summary>
public class TmdbPartialDateConverter : JsonConverter<DateTime?>
{
    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <returns>True if this converter can convert the type; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime?);
    }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <param name="options">Serializer options.</param>
    /// <returns>The parsed DateTime value, or null if parsing fails.</returns>
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var str = reader.GetString();
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }

        if (!DateTime.TryParse(str, CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.None, out var result))
        {
            return null;
        }

        return result;
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">Serializer options.</param>
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        var date = value as DateTime?;
        if (date is null)
        {
            writer?.WriteNullValue();
            return;
        }

        writer?.WriteStringValue(date.Value.ToString(CultureInfo.InvariantCulture));
    }
}
