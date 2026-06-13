using System.Collections.Generic;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Trending;
using TMDbLib.Utilities;
using TMDbLib.Utilities.Converters;

namespace TMDbLib.Objects.General;

/// <summary>
/// Represents the type of media.
/// </summary>
public enum MediaType
{
    /// <summary>
    /// Unknown media type.
    /// </summary>
    Unknown,

    /// <summary>
    /// Movie media type.
    /// </summary>
    Movie = 1,

    /// <summary>
    /// TV show media type.
    /// </summary>
    Tv = 2,

    /// <summary>
    /// Person media type.
    /// </summary>
    Person = 3,

    /// <summary>
    /// Episode media type.
    /// </summary>
    Episode = 4,

    /// <summary>
    /// TV episode media type.
    /// </summary>
    [JsonStringEnumMemberName("tv_episode")]
    TvEpisode = 5,

    /// <summary>
    /// Season media type.
    /// </summary>
    Season = 6,

    /// <summary>
    /// TV season media type.
    /// </summary>
    [JsonStringEnumMemberName("tv_season")]
    TvSeason = 7,

    /// <summary>
    /// Collection media type.
    /// </summary>
    Collection = 8
}
