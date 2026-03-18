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
    /// <param name="value">The value to serialize.</param>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <returns>Returns a string json representation of the value.</returns>
    string Serialize<T>(object value);

    /// <summary>
    /// Deserializes an object from a stream.
    /// </summary>
    /// <param name="source">The source stream to read from.</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The deserialized object.</returns>
    object? Deserialize<T>(Stream source);
}
