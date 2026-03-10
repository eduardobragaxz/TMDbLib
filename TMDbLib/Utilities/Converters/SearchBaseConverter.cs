using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Changes;
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
            if (typeToConvert == typeof(SearchMovie))
            {
                result = new SearchMovie();
            }
            else if (typeToConvert == typeof(SearchTv))
            {
                result = new SearchTv();
            }
            else if (typeToConvert == typeof(SearchPerson))
            {
                result = new SearchPerson();
            }
            else if (typeToConvert == typeof(SearchTvEpisode))
            {
                result = new SearchTvEpisode();
            }
            else if (typeToConvert == typeof(SearchTvSeason))
            {
                result = new SearchTvSeason();
            }
            else
            {
                result = new SearchCollection();
            }
        }
        else
        {
            // Determine the type based on the media_type
            using JsonDocument document = JsonDocument.Parse(jObject.ToJsonString());
            var searchBase = document.RootElement.Deserialize(SourceGenerationContext.Default.SearchBase);

            result = searchBase!.MediaType switch
            {
                MediaType.Movie => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchMovie),
                MediaType.Tv => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchTv),
                MediaType.Person => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchPerson),
                MediaType.Episode => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchTvEpisode),
                MediaType.Tv_Episode => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchTvEpisode),
                MediaType.Season => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchTvSeason),
                MediaType.TvSeason => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchTvSeason),
                MediaType.Collection => document.RootElement.Deserialize(SourceGenerationContext.Default.SearchCollection),
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
