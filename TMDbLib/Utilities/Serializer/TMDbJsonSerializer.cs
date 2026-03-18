using System.IO;
using System.Text;
using System.Text.Json;

namespace TMDbLib.Utilities.Serializer;

/// <summary>
/// JSON serializer implementation for TMDbLib using Newtonsoft.Json with custom converters.
/// </summary>
public class TMDbJsonSerializer : ITMDbSerializer
{
    private readonly Encoding _encoding = new UTF8Encoding(false);

    /// <summary>
    /// Gets serialization options.
    /// </summary>

    /// <summary>
    /// Gets the singleton instance of the <see cref="TMDbJsonSerializer"/>.
    /// </summary>
    public static TMDbJsonSerializer Instance { get; } = new();

    /// <summary>
    /// Serializes an object to a stream.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <returns>String representation of the value.</returns>
    public string Serialize<T>(object value)
    {
        return JsonSerializer.Serialize(value, typeof(T), SourceGenerationContext.Default);
    }

    /// <summary>
    /// Deserializes an object from a stream.
    /// </summary>
    /// <param name="source">The source stream to read from.</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The deserialized object.</returns>
    public object? Deserialize<T>(Stream source)
    {
        return JsonSerializer.Deserialize(source, typeof(T), SourceGenerationContext.Default);
    }
}
