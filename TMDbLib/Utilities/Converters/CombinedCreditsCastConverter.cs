using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;

namespace TMDbLib.Utilities.Converters;

internal class CombinedCreditsCastConverter : JsonConverter<CombinedCreditsCastBase>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(CombinedCreditsCastBase);
    }

    public override CombinedCreditsCastBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, CombinedCreditsCastBase value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    protected CombinedCreditsCastBase? GetInstance(JsonObject jObject)
    {
        var mediaType = jObject["media_type"]?.GetValue<MediaType>();

        return mediaType switch
        {
            MediaType.Movie => new CombinedCreditsCastMovie(),
            MediaType.Tv => new CombinedCreditsCastTv(),
            null => null,
            _ => throw new ArgumentOutOfRangeException(nameof(jObject)),
        };
    }
}
