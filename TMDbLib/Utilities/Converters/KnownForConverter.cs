using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class KnownForConverter : JsonConverter<List<KnownForBase?>>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<KnownForBase>);
    }

    public override List<KnownForBase?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jElement = JsonElement.ParseValue(ref reader);

        var target = GetInstance(jElement!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, List<KnownForBase?> value, JsonSerializerOptions options)
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

    protected List<KnownForBase?> GetInstance(JsonElement jElement)
    {
        List<KnownForBase?> knownForBaseList = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var item in arrayEnumerator)
        {
            var property = item.GetProperty("media_Type");
            var mediaType = Enum.Parse<MediaType>(property.GetString()!, true);

            knownForBaseList.Add(mediaType switch
            {
                MediaType.Movie => item.Deserialize(SourceGenerationContext.Default.KnownForMovie),
                MediaType.Tv => item.Deserialize(SourceGenerationContext.Default.KnownForTv),
                _ => null
            });
        }

        return knownForBaseList;
    }
}
