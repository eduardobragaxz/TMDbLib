using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

/// <summary>
/// JSON converter for UTC datetime values in TMDb's specific format.
/// </summary>
public class TmdbUtcTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-dd HH:mm:ss 'UTC'";

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime);
    }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <param name="options">Serializer options.</param>
    /// <returns>The parsed DateTime value.</returns>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        if (string.IsNullOrEmpty(stringValue))
        {
            return DateTime.Now;
        }

        return DateTime.Parse(stringValue, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">Serializer options.</param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        if (value is DateTime dateTime)
        {
            writer?.WriteStringValue(dateTime.ToString(Format, CultureInfo.InvariantCulture));
        }
        else
        {
            writer?.WriteNullValue();
        }
    }
}
