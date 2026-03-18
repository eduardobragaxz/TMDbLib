using System;
using System.IO;
using System.Text;
using System.Text.Json;
using TMDbLib.Objects.General;
using static TMDbLib.Rest.RestRequest;

namespace TMDbLib.Utilities.Serializer;

/// <summary>
/// Extension methods for <see cref="ITMDbSerializer"/>.
/// </summary>
public static class SerializerExtensions
{
    /// <summary>
    /// Serializes an object to a stream.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="serializer">The serializer instance.</param>
    /// <param name="target">The target stream to write to.</param>
    public static void Serialize<T>(this ITMDbSerializer serializer, Stream target)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(serializer);
        serializer.Serialize<T>(target);
    }

    /// <summary>
    /// Serializes an object to a byte array.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="serializer">The serializer instance.</param>
    /// <param name="value">The value to be serialized.</param>
    /// <returns>A byte array containing the serialized object.</returns>
    public static byte[] SerializeToBytes<T>(this ITMDbSerializer serializer, object value)
        where T : notnull
    {
        // using var ms = new MemoryStream();

        ArgumentNullException.ThrowIfNull(serializer);
        string json = serializer.Serialize<T>(value);

        return Encoding.UTF8.GetBytes(json);
    }

    /// <summary>
    /// Serializes an object to a JSON string.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="serializer">The serializer instance.</param>
    /// <param name="value">The object to serialize.</param>
    /// <returns>A JSON string representation of the object.</returns>
    public static string SerializeToString<T>(this ITMDbSerializer serializer, object value)
        where T : notnull
    {
        // using var ms = new MemoryStream();

        ArgumentNullException.ThrowIfNull(serializer);
        string json = serializer.Serialize<T>(value);

        // ms.Seek(0, SeekOrigin.Begin);

        // using var sr = new StreamReader(ms, Encoding.UTF8);

        return json;
    }

    /// <summary>
    /// Deserializes an object from a stream.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="serializer">The serializer instance.</param>
    /// <param name="source">The source stream to read from.</param>
    /// <returns>The deserialized object.</returns>
    public static T? Deserialize<T>(this ITMDbSerializer serializer, Stream source)
    {
        ArgumentNullException.ThrowIfNull(serializer);
        var result = serializer.Deserialize<T>(source);
        return result is T typed ? typed : default;
    }

    /// <summary>
    /// Deserializes an object from a JSON string.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="serializer">The serializer instance.</param>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    public static object? DeserializeFromString<T>(this ITMDbSerializer serializer, string json)
    {
        // TODO: Better method
        var bytes = Encoding.UTF8.GetBytes(json);
        using var ms = new MemoryStream(bytes);

        ArgumentNullException.ThrowIfNull(serializer);

        return serializer.Deserialize<T>(ms);
    }

    /// <summary>
    /// Deserializes an object from a JSON string.
    /// </summary>
    /// <param name="serializer">The serializer instance.</param>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>The deserialized object, or null if deserialization fails.</returns>
    public static object? DeserializeFromString(this ITMDbSerializer serializer, string json)
    {
        // TODO: Better method
        ArgumentNullException.ThrowIfNull(serializer);
        var bytes = Encoding.UTF8.GetBytes(json);
        using var ms = new MemoryStream(bytes);
        return serializer.Deserialize<object>(ms);
    }
}
