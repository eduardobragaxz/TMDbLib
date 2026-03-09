using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.TvShows;

namespace TMDbLib.Utilities.Converters;

internal class AccountStateConverter : JsonConverter<AccountState>
{
    public override AccountState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));

        // Sometimes the AccountState.Rated is an object with a value in it
        // In these instances, convert it from:
        //  "rated": { "value": 5 }
        //  "rated": False
        // To:
        //  "rating": 5
        //  "rating": null

        var obj = jObject?["rated"]!;
        if (reader.TokenType == JsonTokenType.False)
        {
            // It's "False", so the rating is not set
            jObject?.Remove("rated");
            jObject?.Add("rating", null);
        }
        else
        // if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Read out the value
            var rating = obj["value"]?.GetValue<double>();
            jObject?.Remove("rated");
            jObject?.Add("rating", rating);
        }

        using JsonDocument document = JsonDocument.Parse(jObject!.ToJsonString());
        var result = document.RootElement.Deserialize<AccountState>(SourceGenerationContext.Default.AccountState);

        return (AccountState?)result;
    }

    public override void Write(Utf8JsonWriter writer, AccountState value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        var jsonObject = JsonSerializer.SerializeToNode(value, SourceGenerationContext.Default.AccountState)?.AsObject();

        if (jsonObject != null)
        {
            var ratingNode = jsonObject["rating"];
            jsonObject.Remove("rating");

            if (ratingNode is JsonValue jsonValue && jsonValue.TryGetValue<ContentRating>(out var contentRating) && contentRating is not null)
            {
                jsonObject["rated"] = JsonSerializer.SerializeToNode(new { value = contentRating }, SourceGenerationContext.Default.AccountState);
            }
            else
            {
                jsonObject["rated"] = null;
            }

            jsonObject.WriteTo(writer);
        }
    }
}
