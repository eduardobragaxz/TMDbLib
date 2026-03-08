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
            MediaType mediaType = jObject["media_type"]!.GetValue<MediaType>();

            result = mediaType switch
            {
                MediaType.Movie => new SearchMovie(),
                MediaType.Tv => new SearchTv(),
                MediaType.Person => new SearchPerson(),
                MediaType.Episode => new SearchTvEpisode(),
                MediaType.TvEpisode => new SearchTvEpisode(),
                MediaType.Season => new SearchTvSeason(),
                MediaType.TvSeason => new SearchTvSeason(),
                MediaType.Collection => new SearchCollection(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        // Populate the result
        // if (result is not null)
        // {
        //    using var jsonReader = jObject.CreateReader();
        //    serializer.Populate(jsonReader, result);
        // }

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
