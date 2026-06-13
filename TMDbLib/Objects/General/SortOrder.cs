using System.Collections.Generic;
using TMDbLib.Objects.Trending;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.General;

/// <summary>
/// Represents sort order options.
/// </summary>
public enum SortOrder
{
    /// <summary>
    /// Undefined sort order.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// Ascending sort order.
    /// </summary>
    [JsonStringEnumMemberName("asc")]
    Ascending = 1,

    /// <summary>
    /// Descending sort order.
    /// </summary>
    [JsonStringEnumMemberName("desc")]
    Descending = 2
}

public class SortOrderClass
{
    public static Dictionary<SortOrder, string> SortOrderDescriptions => new ()
    {
        [SortOrder.Undefined] = "Undefined",
        [SortOrder.Ascending] = "asc",
        [SortOrder.Descending] = "desc"
    };
}
