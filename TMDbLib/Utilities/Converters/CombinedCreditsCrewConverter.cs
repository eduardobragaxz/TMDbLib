using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;

namespace TMDbLib.Utilities.Converters;

internal class CombinedCreditsCrewConverter : JsonConverter<CombinedCreditsCrewBase>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(CombinedCreditsCrewBase);
    }

    public override CombinedCreditsCrewBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));

        var target = GetInstance(jObject!);

        // using var jsonReader = jObject.CreateReader();
        // serializer.Populate(jsonReader, target!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, CombinedCreditsCrewBase value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    protected CombinedCreditsCrewBase? GetInstance(JsonObject jObject)
    {
        var mediaType = jObject["media_type"]?.GetValue<MediaType>();

        return mediaType switch
        {
            MediaType.Movie => new CombinedCreditsCrewMovie(),
            MediaType.Tv => new CombinedCreditsCrewTv(),
            null => null,
            _ => throw new ArgumentOutOfRangeException(nameof(jObject)),
        };
    }
}
