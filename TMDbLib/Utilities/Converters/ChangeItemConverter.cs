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
        var jElement = JsonElement.ParseValue(ref reader);

        ChangeItemBase? result;
        if (jElement.TryGetProperty("action", out JsonElement value))
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
            var actionType = Enum.Parse<ChangeAction>(value.GetString()!, true);
            result = actionType switch
            {
                ChangeAction.Added => new ChangeItemAdded(),
                ChangeAction.Created => new ChangeItemCreated(),
                ChangeAction.Updated => new ChangeItemUpdated(),
                ChangeAction.Deleted => new ChangeItemDeleted(),
                ChangeAction.Destroyed => new ChangeItemDestroyed(),
                _ => throw new ArgumentOutOfRangeException(nameof(reader)),
            };
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, ChangeItemBase? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WritePropertyName("value");
        // var jToken = JToken.FromObject(value);
        // serializer.Serialize(writer, jToken);
    }
}
