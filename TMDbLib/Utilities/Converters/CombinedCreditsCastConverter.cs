using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using TMDbLib.Objects.General;
using TMDbLib.Objects.General.Schema;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class CombinedCreditsCastConverter : JsonConverter<List<TmdbMediaSummary?>>
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
        List<TmdbMediaSummary?> combinedCreditsCastBaseList = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var m in arrayEnumerator)
        {
            var property = m.GetProperty("media_type");
            var mediaType = Enum.Parse<MediaType>(property.GetString()!, true);

            combinedCreditsCastBaseList.Add(mediaType switch
            {
                MediaType.Movie => m.Deserialize(SourceGenerationContext.Default.CombinedCreditsCastMovie),
                MediaType.Tv => m.Deserialize(SourceGenerationContext.Default.TMDbLib_Objects_People_CombinedCreditsCastTv),
                _ => null
            });
        }

        return combinedCreditsCastBaseList;
    }
}
