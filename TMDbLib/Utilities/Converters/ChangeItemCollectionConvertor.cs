using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;

namespace TMDbLib.Utilities.Converters;

internal class ChangeItemCollectionConvertor : JsonConverter<List<ChangeItemBase>?>
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<ChangeItemBase>);
    }

    public override List<ChangeItemBase>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jElement = JsonElement.ParseValue(ref reader);

        var target = GetInstance(jElement!);

        return target;
    }

    public override void Write(Utf8JsonWriter writer, List<ChangeItemBase>? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WritePropertyName("value");
    }

    protected List<ChangeItemBase>? GetInstance(JsonElement jElement)
    {
        List<ChangeItemBase> changeItemBaseList = [];
        using JsonElement.ArrayEnumerator arrayEnumerator = jElement.EnumerateArray();

        foreach (var m in arrayEnumerator)
        {
            var property = m.GetProperty("action");

            var actionType = Enum.Parse<ChangeAction>(property.GetString()!, true);

            changeItemBaseList.Add(actionType switch
            {
                ChangeAction.Added => new ChangeItemAdded(),
                ChangeAction.Created => new ChangeItemCreated(),
                ChangeAction.Updated => new ChangeItemUpdated(),
                ChangeAction.Deleted => new ChangeItemDeleted(),
                ChangeAction.Destroyed => new ChangeItemDestroyed(),
                _ => throw new ArgumentOutOfRangeException(nameof(jElement)),
            });
        }

        return changeItemBaseList.Count != 0 ? changeItemBaseList : null;
    }
}
