using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;

namespace TMDbLib.Utilities.Converters;

internal class ChangeItemConverter : JsonConverter<ChangeItemBase?>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(ChangeItemBase);
    }

    public override ChangeItemBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonObject.Create(JsonElement.ParseValue(ref reader));

        ChangeItemBase? result;
        if (jObject?["action"] is null)
        {
            // We cannot determine the correct type, let's hope we were provided one

            if (typeToConvert == typeof(ChangeItemAdded))
            {
                result = new ChangeItemAdded();
            }
            else if (typeToConvert == typeof(ChangeItemCreated))
            {
                result = new ChangeItemCreated();
            }
            else if (typeToConvert == typeof(ChangeItemUpdated))
            {
                result = new ChangeItemUpdated();
            }
            else if (typeToConvert == typeof(ChangeItemDeleted))
            {
                result = new ChangeItemDeleted();
            }
            else
            {
                result = new ChangeItemDestroyed();
            }
        }
        else
        {
            // Determine the type based on the media_type
            using JsonDocument document = JsonDocument.Parse(jObject.ToJsonString());
            var mediaType = document.RootElement.GetProperty("action").Deserialize(SourceGenerationContext.Default.ChangeAction);

            result = mediaType switch
            {
                ChangeAction.Added => new ChangeItemAdded(),
                ChangeAction.Created => new ChangeItemCreated(),
                ChangeAction.Updated => new ChangeItemUpdated(),
                ChangeAction.Deleted => new ChangeItemDeleted(),
                ChangeAction.Destroyed => new ChangeItemDestroyed(),
                _ => throw new ArgumentOutOfRangeException(nameof(reader)),
            };
        }

        // Populate the result
        // if (result is not null)
        // {
        //    using var jsonReader = jObject.CreateReader();
        //    serializer.Populate(jsonReader, result);
        // }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, ChangeItemBase? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, SourceGenerationContext.Default.ChangeItemBase);
        // var jToken = JToken.FromObject(value);
        // serializer.Serialize(writer, jToken);
    }
}
