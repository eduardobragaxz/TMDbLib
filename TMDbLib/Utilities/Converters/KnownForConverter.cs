using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class KnownForConverter : JsonConverter<KnownForBase>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(KnownForBase);
    }

    public override KnownForBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));

        var target = GetInstance(jObject!);

        // using var jsonReader = jObject.CreateReader();
        // serializer.Populate(jsonReader, target!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, KnownForBase value, JsonSerializerOptions options)
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

    protected KnownForBase? GetInstance(JsonObject jObject)
    {
        MediaType? mediaType = jObject["media_type"]!.GetValue<MediaType>();

        return mediaType switch
        {
            MediaType.Movie => new KnownForMovie(),
            MediaType.Tv => new KnownForTv(),
            null => null,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
