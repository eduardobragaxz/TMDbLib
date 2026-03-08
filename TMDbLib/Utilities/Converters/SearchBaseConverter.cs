using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class SearchBaseConverter : JsonConverter<SearchBase>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(SearchBase);
    }

    public override SearchBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));
        SearchBase? result;
        if (jObject?["media_type"] is null)
        {
            // We cannot determine the correct type, let's hope we were provided one
            result = Activator.CreateInstance(typeToConvert) as SearchBase;
        }
        else
        {
            // Determine the type based on the media_type
            using JsonDocument document = JsonDocument.Parse(jObject.ToJsonString());
            var mediaType = document.RootElement.GetProperty("media_type").Deserialize<MediaType>();

            result = mediaType switch
            {
                MediaType.Movie => document.RootElement.Deserialize<SearchMovie>(),
                MediaType.Tv => document.RootElement.Deserialize<SearchTv>(),
                MediaType.Person => document.RootElement.Deserialize<SearchPerson>(),
                MediaType.Episode => document.RootElement.Deserialize<SearchTvEpisode>(),
                MediaType.TvEpisode => document.RootElement.Deserialize<SearchTvEpisode>(),
                MediaType.Season => document.RootElement.Deserialize<SearchTvSeason>(),
                MediaType.TvSeason => document.RootElement.Deserialize<SearchTvSeason>(),
                MediaType.Collection => document.RootElement.Deserialize<SearchCollection>(),
                _ => throw new ArgumentOutOfRangeException(nameof(reader)),
            };
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, SearchBase value, JsonSerializerOptions options)
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
