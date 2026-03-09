using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;
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
        JsonSerializerOptions = new()
        {
            Converters =
            {
                new ChangeItemConverter(),
                new AccountStateConverterFactory(),
                new SearchBaseConverter(),
                new TaggedImageConverter(),
                new TolerantEnumConverter(),
                new TmdbNullIntAsZero()
            },
            TypeInfoResolver = SourceGenerationContext.Default
        };
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

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
        JsonSerializer.Serialize(sw.BaseStream, obj, type, JsonSerializerOptions);
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
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

#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
        return JsonSerializer.Deserialize(sr.BaseStream, type, JsonSerializerOptions);
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
    }
}
