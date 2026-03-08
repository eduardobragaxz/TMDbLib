using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;

namespace TMDbLib.Utilities.Converters;

internal class CombinedCreditsCrewConverter : JsonConverter<List<CombinedCreditsCrewBase?>>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<CombinedCreditsCrewBase>);
    }

    public override List<CombinedCreditsCrewBase?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jElement = JsonElement.ParseValue(ref reader);

        var target = GetInstance(jElement!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, List<CombinedCreditsCrewBase?> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    protected List<CombinedCreditsCrewBase?> GetInstance(JsonElement jElement)
    {
        List<CombinedCreditsCrewBase?> combinedCreditsCrewBase = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var m in arrayEnumerator)
        {
            var mediaType = m.GetProperty("media_type").Deserialize<MediaType>(SourceGenerationContext.Default.MediaType);
            combinedCreditsCrewBase.Add(mediaType switch
            {
                MediaType.Movie => m.Deserialize<CombinedCreditsCrewMovie>(SourceGenerationContext.Default.CombinedCreditsCrewMovie),
                MediaType.Tv => m.Deserialize<CombinedCreditsCrewTv>(SourceGenerationContext.Default.CombinedCreditsCrewTv),
                _ => null
            });
        }

        return combinedCreditsCrewBase;
    }
}
