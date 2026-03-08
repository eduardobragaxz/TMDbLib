using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.TvShows;

namespace TMDbLib.Utilities.Converters;

internal class AccountStateConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(AccountState) ||
                objectType == typeof(TvAccountState) ||
                objectType == typeof(TvEpisodeAccountState) ||
                objectType == typeof(TvEpisodeAccountStateWithNumber);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(AccountState))
        {
            return new AccountStateConverter();
        }
        else
        {
            return new TVAccountStateConverter();
        }
    }
}

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

        var result = Activator.CreateInstance(typeToConvert);

        // Populate the result
        // if (result is not null)
        // {
        //    using var jsonReader = jObject.CreateReader();
        //    serializer.Populate(jsonReader, result);
        // }

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
                jsonObject["rated"] = JsonSerializer.SerializeToNode(new { value = contentRating });
            }
            else
            {
                jsonObject["rated"] = null;
            }

            jsonObject.WriteTo(writer);
        }
    }
}


internal class TVAccountStateConverter : JsonConverter<TvAccountState>
{
    public override TvAccountState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

        var result = Activator.CreateInstance(typeToConvert);

        // Populate the result
        // if (result is not null)
        // {
        //    using var jsonReader = jObject.CreateReader();
        //    serializer.Populate(jsonReader, result);
        // }

        return (TvAccountState?)result;
    }

    public override void Write(Utf8JsonWriter writer, TvAccountState value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        var jsonObject = JsonSerializer.SerializeToNode(value)?.AsObject();

        if (jsonObject != null)
        {
            var ratingNode = jsonObject["rating"];
            jsonObject.Remove("rating");

            if (ratingNode is JsonValue jsonValue && jsonValue.TryGetValue<ContentRating>(out var contentRating) && contentRating is not null)
            {
                jsonObject["rated"] = JsonSerializer.SerializeToNode(new { value = contentRating });
            }
            else
            {
                jsonObject["rated"] = null;
            }

            jsonObject.WriteTo(writer);
        }
    }
}
