using System.Collections.Generic;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Discover;

/// <summary>
/// Specifies the sorting options for TV show discovery queries.
/// </summary>
public enum DiscoverTvShowSortBy
{
    /// <summary>
    /// No specific sorting defined.
    /// </summary>
    Undefined,

    /// <summary>
    /// Sort by vote average in ascending order.
    /// </summary>
    [JsonStringEnumMemberName("vote_average.asc")]
    VoteAverage,

    /// <summary>
    /// Sort by vote average in descending order.
    /// </summary>
    [JsonStringEnumMemberName("vote_average.desc")]
    VoteAverageDesc,

    /// <summary>
    /// Sort by first air date in ascending order.
    /// </summary>
    [JsonStringEnumMemberName("first_air_date.asc")]
    FirstAirDate,

    /// <summary>
    /// Sort by first air date in descending order.
    /// </summary>
    [JsonStringEnumMemberName("first_air_date.desc")]
    FirstAirDateDesc,

    /// <summary>
    /// Sort by popularity in ascending order.
    /// </summary>
    [JsonStringEnumMemberName("popularity.asc")]
    Popularity,

    /// <summary>
    /// Sort by popularity in descending order.
    /// </summary>
    [JsonStringEnumMemberName("popularity.desc")]
    PopularityDesc,

    /// <summary>
    /// Sort by revenue in ascending order.
    /// </summary>
    [JsonStringEnumMemberName("revenue.asc")]
    Revenue,

    /// <summary>
    /// Sort by revenue in descending order.
    /// </summary>
    [JsonStringEnumMemberName("revenue.desc")]
    RevenueDesc,

    /// <summary>
    /// Sort by primary release date in ascending order.
    /// </summary>
    [JsonStringEnumMemberName("primary_release_date.asc")]
    PrimaryReleaseDate,

    /// <summary>
    /// Sort by primary release date in descending order.
    /// </summary>
    [JsonStringEnumMemberName("primary_release_date.desc")]
    PrimaryReleaseDateDesc,

    /// <summary>
    /// Sort by vote count in ascending order.
    /// </summary>
    [JsonStringEnumMemberName("vote_count.asc")]
    VoteCount,

    /// <summary>
    /// Sort by vote count in descending order.
    /// </summary>
    [JsonStringEnumMemberName("vote_count.desc")]
    VoteCountDesc
}
