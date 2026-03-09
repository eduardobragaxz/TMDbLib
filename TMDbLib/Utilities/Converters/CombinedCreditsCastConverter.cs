using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class CombinedCreditsCastConverter : JsonConverter<List<CombinedCreditsCastBase?>>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<CombinedCreditsCastBase>);
    }

    public override List<CombinedCreditsCastBase?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jElement = JsonElement.ParseValue(ref reader);

        var target = GetInstance(jElement!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, List<CombinedCreditsCastBase?> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    protected List<CombinedCreditsCastBase?> GetInstance(JsonElement jElement)
    {
        List<CombinedCreditsCastBase?> combinedCreditsCastBaseList = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var m in arrayEnumerator)
        {
            var combinedCreditsCastBase = m.Deserialize(SourceGenerationContext.Default.CombinedCreditsCastBase);

            combinedCreditsCastBaseList.Add(combinedCreditsCastBase!.MediaType switch
            {
                MediaType.Movie => m.Deserialize(SourceGenerationContext.Default.CombinedCreditsCastMovie),
                MediaType.Tv => m.Deserialize(SourceGenerationContext.Default.TMDbLib_Objects_People_CombinedCreditsCastTv),
                _ => null
            });
        }

        return combinedCreditsCastBaseList;
    }
}
