using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

/// <summary>
/// JSON converter that treats null integer values as zero.
/// </summary>
public class TmdbNullIntAsZero : JsonConverter<int?>
{
    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <returns>True if this converter can convert the type; otherwise, false.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(int);
    }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <param name="options">The calling serializer.</param>
    /// <returns>The object value, or zero if the value is null.</returns>
    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var tokenString = reader.GetString();

        if (tokenString is null)
        {
            return 0;
        }

        return Convert.ToInt32(tokenString, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">Serializer options.</param>
    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStringValue(value.Value.ToString(string.Empty, CultureInfo.InvariantCulture));
    }
}
