using System.Collections.Generic;
using TMDbLib.Objects.Collections;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Find;

/// <summary>
/// Represents the external sources that can be used for finding content.
/// </summary>

public enum FindExternalSource
{
    /// <summary>
    /// IMDb external ID source.
    /// </summary>
    [JsonStringEnumMemberName("imdb_id")]
    Imdb,

    /// <summary>
    /// TVDb external ID source.
    /// </summary>
    [JsonStringEnumMemberName("tvdb_id")]
    TvDb,

    /// <summary>
    /// Wikidata external ID source.
    /// </summary>
    [JsonStringEnumMemberName("wikidata_id")]
    Wikidata,

    /// <summary>
    /// Facebook external ID source.
    /// </summary>
    [JsonStringEnumMemberName("facebook_id")]
    Facebook,

    /// <summary>
    /// Instagram external ID source.
    /// </summary>
    [JsonStringEnumMemberName("instagram_id")]
    Instagram,

    /// <summary>
    /// Twitter external ID source.
    /// </summary>
    [JsonStringEnumMemberName("twitter_id")]
    Twitter,

    /// <summary>
    /// YouTube external ID source.
    /// </summary>
    [JsonStringEnumMemberName("youtube_id")]
    YouTube,

    /// <summary>
    /// TikTok external ID source.
    /// </summary>
    [JsonStringEnumMemberName("tiktok_id")]
    TikTok,
}
