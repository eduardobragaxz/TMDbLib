using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Changes;

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
            var instance = Activator.CreateInstance(typeToConvert);
            result = instance as ChangeItemBase;
        }
        else
        {
            // Determine the type based on the media_type
            var mediaType = jObject["action"]?.GetValue<ChangeAction>();

            switch (mediaType)
            {
                case ChangeAction.Added:
                    result = new ChangeItemAdded();
                    break;
                case ChangeAction.Created:
                    result = new ChangeItemCreated();
                    break;
                case ChangeAction.Updated:
                    result = new ChangeItemUpdated();
                    break;
                case ChangeAction.Deleted:
                    result = new ChangeItemDeleted();
                    break;
                case ChangeAction.Destroyed:
                    result = new ChangeItemDestroyed();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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

        JsonSerializer.Serialize(writer, value);
        // var jToken = JToken.FromObject(value);
        // serializer.Serialize(writer, jToken);
    }
}
