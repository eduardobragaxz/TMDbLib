using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities.Converters;

internal abstract class JsonCreationConverter<T> : JsonConverter<T>
{
    protected abstract T? GetInstance(JsonObject jObject);

    public object? ReadJson(Utf8JsonReader reader, Type objectType, object? existingValue, JsonSerializerOptions serializer)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));

        var target = GetInstance(jObject!);

        // using var jsonReader = jObject.CreateReader();
        // serializer.Populate(jsonReader, target!);

        return target;
    }

    public void WriteJson(Utf8JsonWriter writer, object? value, JsonSerializerOptions serializer)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WritePropertyName("value");
        // var jToken = JToken.FromObject(value);
        // jToken.WriteTo(writer);
    }
}
