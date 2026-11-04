using System;
using System.Collections.Generic;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Additional TV season data to retrieve from the API.
/// </summary>

[Flags]
public enum TvSeasonMethods
{
    /// <summary>
    /// No additional data.
    /// </summary>
    [JsonStringEnumMemberName("Undefined")]
    Undefined = 0,

    /// <summary>
    /// Include credits information.
    /// </summary>
    [JsonStringEnumMemberName("credits")]
    Credits = 1,

    /// <summary>
    /// Include images.
    /// </summary>
    [JsonStringEnumMemberName("images")]
    Images = 2,

    /// <summary>
    /// Include external IDs.
    /// </summary>
    [JsonStringEnumMemberName("external_ids")]
    ExternalIds = 4,

    /// <summary>
    /// Include videos.
    /// </summary>
    [JsonStringEnumMemberName("videos")]
    Videos = 8,

    /// <summary>
    /// Include account states.
    /// </summary>
    [JsonStringEnumMemberName("account_states")]
    AccountStates = 16,

    /// <summary>
    /// Include translations.
    /// </summary>
    [JsonStringEnumMemberName("translations")]
    Translations = 32,

    /// <summary>
    /// Include aggregated credits.
    /// </summary>
    [JsonStringEnumMemberName("aggregate_credits")]
    CreditsAggregate = 64,

    /// <summary>
    /// Include watch providers.
    /// </summary>
    [JsonStringEnumMemberName("watch/providers")]
    WatchProviders = 128,
}
