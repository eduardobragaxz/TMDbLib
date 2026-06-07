using System.Text.Json.Serialization;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Trending;

/// <summary>
/// Represents the time window for trending content.
/// </summary>
public enum TimeWindow
{
    /// <summary>
    /// Trending content for the current day.
    /// </summary>
    [JsonStringEnumMemberName("day")]
    Day,

    /// <summary>
    /// Trending content for the current week.
    /// </summary>
    // [JsonStringEnumMemberName("week")]
    [JsonStringEnumMemberName("week")]
    Week
}
