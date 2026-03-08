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

        var result = new TaggedImage();

        var mediaJson = jObject?["media"];
        if (mediaJson is not null)
        {
            result.Media = result.MediaType switch
            {
                MediaType.Movie => mediaJson.GetValue<SearchMovie>(),
                MediaType.Tv => mediaJson.GetValue<SearchTv>(),
                MediaType.Episode => mediaJson.GetValue<SearchTvEpisode>(),
                MediaType.Season => mediaJson.GetValue<SearchTvSeason>(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        return result;
    }

    // public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    // {
    //    var jObject = JObject.Load(reader);

    // var result = new TaggedImage();

    // using (JsonReader jsonReader = jObject.CreateReader())
    //    {
    //        serializer.Populate(jsonReader, result!);
    //    }

    // var mediaJson = jObject["media"];
    //    if (mediaJson is not null)
    //    {
    //        result.Media = result.MediaType switch
    //        {
    //            MediaType.Movie => mediaJson.ToObject<SearchMovie>(),
    //            MediaType.Tv => mediaJson.ToObject<SearchTv>(),
    //            MediaType.Episode => mediaJson.ToObject<SearchTvEpisode>(),
    //            MediaType.Season => mediaJson.ToObject<SearchTvSeason>(),
    //            _ => throw new ArgumentOutOfRangeException(),
    //        };
    //    }

    // return result;
    // }

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

    // public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    // {
    //    if (value is null)
    //    {
    //        writer.WriteNull();
    //        return;
    //    }

    // var jToken = JToken.FromObject(value);
    //    jToken.WriteTo(writer);
    // }
}
