using System;
using System.Collections.Generic;
using TMDbLib.Objects.Movies;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Defines the optional data that can be retrieved along with TV episode details.
/// </summary>
[Flags]
public enum TvEpisodeMethods
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
}

public class TvEpisodeMethodsClass
{
    public static Dictionary<TvEpisodeMethods, string> TvEpisodeMethodsDescriptions => new ()
    {
        [TvEpisodeMethods.Undefined] = "Undefined",
        [TvEpisodeMethods.Credits] = "credits",
        [TvEpisodeMethods.Images] = "images",
        [TvEpisodeMethods.ExternalIds] = "external_ids",
        [TvEpisodeMethods.Videos] = "videos",
        [TvEpisodeMethods.AccountStates] = "account_states",
        [TvEpisodeMethods.Translations] = "translations",
    };
}
