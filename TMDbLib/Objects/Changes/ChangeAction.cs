using System.Text.Json.Serialization;
using TMDbLib.Utilities;
using TMDbLib.Utilities.Converters;

namespace TMDbLib.Objects.Changes;

/// <summary>
/// Specifies the type of change action that occurred.
/// </summary>
public enum ChangeAction
{
    /// <summary>
    /// Unknown or unspecified change action.
    /// </summary>
    Unknown,

    /// <summary>
    /// An item was added.
    /// </summary>
    // [JsonStringEnumMemberName("added")]
    Added = 1,

    /// <summary>
    /// An item was created.
    /// </summary>
    // [JsonStringEnumMemberName("created")]
    Created = 2,

    /// <summary>
    /// An item was updated.
    /// </summary>
    // [JsonStringEnumMemberName("updated")]
    Updated = 3,

    /// <summary>
    /// An item was deleted.
    /// </summary>
    // [JsonStringEnumMemberName("deleted")]
    Deleted = 4,

    /// <summary>
    /// An item was destroyed.
    /// </summary>
    // [JsonStringEnumMemberName("destroyed")]
    Destroyed = 5
}
