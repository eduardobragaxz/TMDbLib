using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

/// <summary>
/// JSON converter factory for DateTime values with custom format strings.
/// Supports both <see cref="DateTime"/> and <see cref="Nullable{DateTime}"/>.
/// </summary>
public class CustomDatetimeFormatConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// Gets or sets the culture info to use for date formatting.
    /// </summary>
    public CultureInfo CultureInfo { get; set; } = new CultureInfo("en-US");

    /// <summary>
    /// Gets or sets the datetime format string.
    /// </summary>
    public string DatetimeFormat { get; set; } = "yyyy-MM-dd HH:mm:ss UTC";

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?);
    }

    /// <inheritdoc />
    public  JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(DateTime?))
        {
            return new NullableConverter(DatetimeFormat, CultureInfo);
        }

        return new Converter(DatetimeFormat, CultureInfo);
    }

    /// <inheritdoc/>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private sealed class Converter : JsonConverter<DateTime>
    {
        private readonly string _format;
        private readonly CultureInfo _culture;

        public Converter(string format, CultureInfo culture)
        {
            _format = format;
            _culture = culture;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TryGetDateTimeExact(_format, _culture, out var value)
                ? value
                : default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteFormattedStringValue(value, _format, _culture);
        }
    }

    private sealed class NullableConverter : JsonConverter<DateTime?>
    {
        private readonly string _format;
        private readonly CultureInfo _culture;

        public NullableConverter(string format, CultureInfo culture)
        {
            _format = format;
            _culture = culture;
        }

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
                return DateTime.Now;
            }

            return reader.TryGetDateTimeExact(_format, _culture, out var value)
                ? value
                : null;
        }


        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="options">Serializer options.</param>
        //public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        //{
        //    if (value is DateTime dateTime)
        //    {
        //        writer?.WriteStringValue(dateTime.ToString(DatetimeFormat, CultureInfo));
        //    }
        //    else
        //    {
        //        writer?.WriteNullValue();
        //    }
        //}

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
