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

        foreach (var m in arrayEnumerator)
        {
            var mediaType = m.GetProperty("media_type").Deserialize<MediaType>();

            knownForBaseList.Add(mediaType switch
            {
                MediaType.Movie => m.Deserialize<KnownForMovie>(),
                MediaType.Tv => m.Deserialize<KnownForTv>(),
                _ => null
            });
        }

        return knownForBaseList;

        // return mediaType switch
        // {
        //    MediaType.Movie => new KnownForMovie(),
        //    MediaType.Tv => new KnownForTv(),
        //    null => null,
        //    _ => throw new ArgumentOutOfRangeException(),
        // };
    }
}
