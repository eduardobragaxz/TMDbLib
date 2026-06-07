using System;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Movies;

/// <summary>
/// Specifies additional movie data to retrieve from the API.
/// </summary>
[Flags]
public enum MovieMethods
{
    /// <summary>
    /// Undefined or no additional data.
    /// </summary>
    [JsonStringEnumMemberName("Undefined")]
    Undefined = 0,

    /// <summary>
    /// Include alternative titles.
    /// </summary>
    [JsonStringEnumMemberName("alternative_titles")]
    AlternativeTitles = 1 << 0,

    /// <summary>
    /// Include cast and crew credits.
    /// </summary>
    [JsonStringEnumMemberName("credits")]
    Credits = 1 << 1,

    /// <summary>
    /// Include images.
    /// </summary>
    [JsonStringEnumMemberName("images")]
    Images = 1 << 2,

    /// <summary>
    /// Include keywords.
    /// </summary>
    [JsonStringEnumMemberName("keywords")]
    Keywords = 1 << 3,

    /// <summary>
    /// Include releases information.
    /// </summary>
    [JsonStringEnumMemberName("releases")]
    Releases = 1 << 4,

    /// <summary>
    /// Include videos.
    /// </summary>
    [JsonStringEnumMemberName("videos")]
    Videos = 1 << 5,

    /// <summary>
    /// Include translations.
    /// </summary>
    [JsonStringEnumMemberName("translations")]
    Translations = 1 << 6,

    /// <summary>
    /// Include similar movies.
    /// </summary>
    [JsonStringEnumMemberName("similar")]
    Similar = 1 << 7,

    /// <summary>
    /// Include user reviews.
    /// </summary>
    [JsonStringEnumMemberName("reviews")]
    Reviews = 1 << 8,

    /// <summary>
    /// Include lists containing this movie.
    /// </summary>
    [JsonStringEnumMemberName("lists")]
    Lists = 1 << 9,

    /// <summary>
    /// Include change history.
    /// </summary>
    [JsonStringEnumMemberName("changes")]
    Changes = 1 << 10,

    /// <summary>
    /// Requires a valid user session to be set on the client object.
    /// </summary>
    [JsonStringEnumMemberName("account_states")]
    AccountStates = 1 << 11,

    /// <summary>
    /// Include release dates by country.
    /// </summary>
    [JsonStringEnumMemberName("release_dates")]
    ReleaseDates = 1 << 12,

    /// <summary>
    /// Include recommended movies.
    /// </summary>
    [JsonStringEnumMemberName("recommendations")]
    Recommendations = 1 << 13,

    /// <summary>
    /// Include external IDs.
    /// </summary>
    [JsonStringEnumMemberName("external_ids")]
    ExternalIds = 1 << 14,

    /// <summary>
    /// Include watch provider information.
    /// </summary>
    [JsonStringEnumMemberName("watch/providers")]
    WatchProviders = 1 << 15
}
