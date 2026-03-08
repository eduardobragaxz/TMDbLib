using System;
using System.IO;
using System.Text;
using System.Text.Json;
using TMDbLib.Utilities.Converters;

namespace TMDbLib.Utilities.Serializer;

/// <summary>
/// JSON serializer implementation for TMDbLib using Newtonsoft.Json with custom converters.
/// </summary>
public class TMDbJsonSerializer : ITMDbSerializer
{
    private readonly Encoding _encoding = new UTF8Encoding(false);

    private TMDbJsonSerializer()
    {
        JsonSerializerOptions = new();
        JsonSerializerOptions.Converters.Add(new ChangeItemConverter());
        JsonSerializerOptions.Converters.Add(new AccountStateConverterFactory());
        JsonSerializerOptions.Converters.Add(new KnownForConverter());
        JsonSerializerOptions.Converters.Add(new CombinedCreditsCastConverter());
        JsonSerializerOptions.Converters.Add(new CombinedCreditsCrewConverter());
        JsonSerializerOptions.Converters.Add(new SearchBaseConverter());
        JsonSerializerOptions.Converters.Add(new TaggedImageConverter());
        JsonSerializerOptions.Converters.Add(new TolerantEnumConverter());
    }

    /// <summary>
    /// Gets serialization options.
    /// </summary>
    public JsonSerializerOptions JsonSerializerOptions { get; }

    /// <summary>
    /// Gets the singleton instance of the <see cref="TMDbJsonSerializer"/>.
    /// </summary>
    public static TMDbJsonSerializer Instance { get; } = new();

    /// <summary>
    /// Serializes an object to a stream.
    /// </summary>
    /// <param name="target">The target stream to write to.</param>
    /// <param name="obj">The object to serialize.</param>
    /// <param name="type">The type of the object.</param>
    public void Serialize(Stream target, object obj, Type type)
    {
        using var sw = new StreamWriter(target, _encoding, 4096, true);
        // using var jw = new Utf8JsonWriter(sw.BaseStream);

        JsonSerializer.Serialize(sw.BaseStream, obj, type, JsonSerializerOptions);
    }

    /// <summary>
    /// Deserializes an object from a stream.
    /// </summary>
    /// <param name="source">The source stream to read from.</param>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    public object? Deserialize(Stream source, Type type)
    {
        using var sr = new StreamReader(source, _encoding, false, 4096, true);
        // using var jr = new JsonTextReader(sr);
        return System.Text.Json.JsonSerializer.Deserialize(sr.BaseStream, type);
    }
}
