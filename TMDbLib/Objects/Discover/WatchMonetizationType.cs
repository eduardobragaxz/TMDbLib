using System.Collections.Generic;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Discover;

/// <summary>
/// Specifies the monetization type for watch provider filtering.
/// </summary>
public enum WatchMonetizationType
{
    /// <summary>
    /// Subscription-based streaming (e.g., Netflix, Disney+).
    /// </summary>
    [JsonStringEnumMemberName("flatrate")]
    Flatrate,

    /// <summary>
    /// Free to watch (may include ads).
    /// </summary>
    [JsonStringEnumMemberName("free")]
    Free,

    /// <summary>
    /// Ad-supported streaming.
    /// </summary>
    [JsonStringEnumMemberName("ads")]
    Ads,

    /// <summary>
    /// Available for rental.
    /// </summary>
    [JsonStringEnumMemberName("rent")]
    Rent,

    /// <summary>
    /// Available for purchase.
    /// </summary>
    [JsonStringEnumMemberName("buy")]
    Buy
}
