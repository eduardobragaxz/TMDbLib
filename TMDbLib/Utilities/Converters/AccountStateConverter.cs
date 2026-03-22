using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.TvShows;

namespace TMDbLib.Utilities.Converters;

internal class AccountStateConverter : JsonConverter<double?>
{
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Sometimes the AccountState.Rated is an object with a value in it
        // In these instances, convert it from:
        //  "rated": { "value": 5 }
        //  "rated": False
        // To:
        //  "rating": 5
        //  "rating": null

        if (reader.TokenType == JsonTokenType.False)
        {
            return null;
        }
        else
        {
            JsonElement jElement = JsonElement.ParseValue(ref reader);

            if (jElement.TryGetProperty("value", out JsonElement value) == false)
            {
                return null;
            }

            return value.GetDouble();
        }
    }

    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
    {
        // if (value is null)
        // {
        //    writer.WriteNullValue();
        //    return;
        // }

        // var jsonObject = JsonSerializer.SerializeToNode(value, SourceGenerationContext.Default.AccountState)?.AsObject();

        // if (jsonObject != null)
        // {
        //    var ratingNode = jsonObject["rating"];
        //    jsonObject.Remove("rating");

        // if (ratingNode is JsonValue jsonValue && jsonValue.TryGetValue<ContentRating>(out var contentRating) && contentRating is not null)
        //    {
        //        jsonObject["rated"] = JsonSerializer.SerializeToNode(new { value = contentRating }, SourceGenerationContext.Default.AccountState);
        //    }
        //    else
        //    {
        //        jsonObject["rated"] = null;
        //    }

        // jsonObject.WriteTo(writer);
        // }
    }
}
