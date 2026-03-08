using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class TaggedImageConverter : JsonConverter<TaggedImage>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TaggedImage);
    }

    public override TaggedImage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));

        using JsonDocument document = JsonDocument.Parse(jObject!.ToJsonString());
        var result = document.RootElement.Deserialize<TaggedImage>();

        return result;
    }

    public override void Write(Utf8JsonWriter writer, TaggedImage value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        // var jToken = JsonObject.Create(JsonElement.par)
        writer.WritePropertyName("value");
        // jToken.WriteTo(writer);
    }
}
