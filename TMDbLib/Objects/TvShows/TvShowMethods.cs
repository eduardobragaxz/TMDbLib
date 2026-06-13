using System;
using System.Collections.Generic;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Defines the optional data that can be retrieved along with TV show details.
/// </summary>
[Flags]
public enum TvShowMethods
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
    Credits = 1 << 0,

    /// <summary>
    /// Include images.
    /// </summary>
    [JsonStringEnumMemberName("images")]
    Images = 1 << 1,

    /// <summary>
    /// Include external IDs.
    /// </summary>
    [JsonStringEnumMemberName("external_ids")]
    ExternalIds = 1 << 2,

    /// <summary>
    /// Include content ratings.
    /// </summary>
    [JsonStringEnumMemberName("content_ratings")]
    ContentRatings = 1 << 3,

    /// <summary>
    /// Include alternative titles.
    /// </summary>
    [JsonStringEnumMemberName("alternative_titles")]
    AlternativeTitles = 1 << 4,

    /// <summary>
    /// Include keywords.
    /// </summary>
    [JsonStringEnumMemberName("keywords")]
    Keywords = 1 << 5,

    /// <summary>
    /// Include similar TV shows.
    /// </summary>
    [JsonStringEnumMemberName("similar")]
    Similar = 1 << 6,

    /// <summary>
    /// Include videos.
    /// </summary>
    [JsonStringEnumMemberName("videos")]
    Videos = 1 << 7,

    /// <summary>
    /// Include translations.
    /// </summary>
    [JsonStringEnumMemberName("translations")]
    Translations = 1 << 8,

    /// <summary>
    /// Include account states.
    /// </summary>
    [JsonStringEnumMemberName("account_states")]
    AccountStates = 1 << 9,

    /// <summary>
    /// Include changes.
    /// </summary>
    [JsonStringEnumMemberName("changes")]
    Changes = 1 << 10,

    /// <summary>
    /// Include recommendations.
    /// </summary>
    [JsonStringEnumMemberName("recommendations")]
    Recommendations = 1 << 11,

    /// <summary>
    /// Include reviews.
    /// </summary>
    [JsonStringEnumMemberName("reviews")]
    Reviews = 1 << 12,

    /// <summary>
    /// Include watch providers.
    /// </summary>
    [JsonStringEnumMemberName("watch/providers")]
    WatchProviders = 1 << 13,

    /// <summary>
    /// Include episode groups.
    /// </summary>
    [JsonStringEnumMemberName("episode_groups")]
    EpisodeGroups = 1 << 14,

    /// <summary>
    /// Include aggregated credits.
    /// </summary>
    [JsonStringEnumMemberName("aggregate_credits")]
    CreditsAggregate = 1 << 15,
}

public class TvShowMethodsClass
{
    public static Dictionary<TvShowMethods, string> TvShowMethodsDescriptions => new ()
    {
        [TvShowMethods.Undefined] = "Undefined",
        [TvShowMethods.Credits] = "credits",
        [TvShowMethods.Images] = "images",
        [TvShowMethods.ExternalIds] = "external_ids",
        [TvShowMethods.ContentRatings] = "content_ratings",
        [TvShowMethods.AlternativeTitles] = "alternative_titles",
        [TvShowMethods.Keywords] = "keywords",
        [TvShowMethods.Similar] = "similar",
        [TvShowMethods.Videos] = "videos",
        [TvShowMethods.Translations] = "translations",
        [TvShowMethods.AccountStates] = "account_states",
        [TvShowMethods.Changes] = "changes",
        [TvShowMethods.Recommendations] = "recommendations",
        [TvShowMethods.Reviews] = "reviews",
        [TvShowMethods.WatchProviders] = "watch/providers",
        [TvShowMethods.EpisodeGroups] = "episode_groups",
        [TvShowMethods.CreditsAggregate] = "aggregate_credits",
    };
}
