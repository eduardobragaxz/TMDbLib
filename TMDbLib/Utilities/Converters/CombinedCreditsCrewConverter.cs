using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.General.Schema;
using TMDbLib.Objects.People;

namespace TMDbLib.Utilities.Converters;

internal class CombinedCreditsCrewConverter : JsonConverter<List<TmdbMediaSummary?>>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<TmdbMediaSummary>);
    }

    public override List<TmdbMediaSummary?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jElement = JsonElement.ParseValue(ref reader);

        var target = GetInstance(jElement!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, List<TmdbMediaSummary?> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    protected List<TmdbMediaSummary?> GetInstance(JsonElement jElement)
    {
        List<TmdbMediaSummary?> combinedCreditsCrewBaseList = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var m in arrayEnumerator)
        {
            var property = m.GetProperty("media_type");
            var mediaType = Enum.Parse<MediaType>(property.GetString()!, true);

            combinedCreditsCrewBaseList.Add(mediaType switch
            {
                MediaType.Movie => m.Deserialize(SourceGenerationContext.Default.CombinedCreditsCrewMovie),
                MediaType.Tv => m.Deserialize(SourceGenerationContext.Default.TMDbLib_Objects_People_CombinedCreditsCrewTv),
                _ => null
            });
        }

        return combinedCreditsCrewBaseList;
    }
}
