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
        List<CombinedCreditsCrewBase?> combinedCreditsCrewBaseList = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var m in arrayEnumerator)
        {
            var combinedCreditsCrewBase = m.Deserialize(SourceGenerationContext.Default.CombinedCreditsCrewBase);

            combinedCreditsCrewBaseList.Add(combinedCreditsCrewBase!.MediaType switch
            {
                MediaType.Movie => m.Deserialize(SourceGenerationContext.Default.CombinedCreditsCrewMovie),
                MediaType.Tv => m.Deserialize(SourceGenerationContext.Default.TMDbLib_Objects_People_CombinedCreditsCrewTv),
                _ => null
            });
        }

        return combinedCreditsCrewBaseList;
    }
}
