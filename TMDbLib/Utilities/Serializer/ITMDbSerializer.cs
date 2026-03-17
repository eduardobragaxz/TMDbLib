using System;
using System.IO;

namespace TMDbLib.Utilities.Serializer;

/// <summary>
/// Interface for JSON serialization and deserialization in TMDbLib.
/// </summary>
public interface ITMDbSerializer
{
    /// <summary>
    /// Serializes an object to a stream.
    /// </summary>
    /// <param name="target">The target stream to write to.</param>
    /// <typeparam name="T">The type of the object.</typeparam>
    void Serialize<T>(Stream target);

    /// <summary>
    /// Deserializes an object from a stream.
    /// </summary>
    /// <param name="source">The source stream to read from.</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The deserialized object.</returns>
    object? Deserialize<T>(Stream source);
}
