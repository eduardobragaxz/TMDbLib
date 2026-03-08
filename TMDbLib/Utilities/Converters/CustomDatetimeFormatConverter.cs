using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

/// <summary>
/// JSON converter for DateTime values with custom format strings.
/// </summary>
public class CustomDatetimeFormatConverter : JsonConverter<DateTime?>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomDatetimeFormatConverter"/> class.
    /// </summary>
    public CustomDatetimeFormatConverter()
    {
        CultureInfo = new CultureInfo("en-US");
        DatetimeFormat = "yyyy-MM-dd HH:mm:ss UTC";
    }

    /// <summary>
    /// Gets or sets the culture info to use for date formatting.
    /// </summary>
    public CultureInfo CultureInfo { get; set; }

    /// <summary>
    /// Gets or sets the datetime format string.
    /// </summary>
    public string DatetimeFormat { get; set; }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">Type of the object.</param>
    /// <param name="options">Serializer options.</param>
    /// <returns>The object value.</returns>
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        if (string.IsNullOrEmpty(stringValue))
        {
            return null;
        }

        return DateTime.ParseExact(stringValue, DatetimeFormat, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">Serializer options.</param>
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is DateTime dateTime)
        {
            writer.WriteStringValue(dateTime.ToString(DatetimeFormat, CultureInfo));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
