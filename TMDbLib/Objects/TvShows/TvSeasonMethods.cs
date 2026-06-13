using System;
using System.Collections.Generic;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Defines the optional data that can be retrieved along with TV season details.
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
}

public class TvSeasonMethodsClass
{
    public static Dictionary<TvSeasonMethods, string> TvSeasonMethodsDescriptions => new()
    {
        [TvSeasonMethods.Undefined] = "Undefined",
        [TvSeasonMethods.Credits] = "credits",
        [TvSeasonMethods.Images] = "images",
        [TvSeasonMethods.ExternalIds] = "external_ids",
        [TvSeasonMethods.Videos] = "videos",
        [TvSeasonMethods.AccountStates] = "account_states",
        [TvSeasonMethods.Translations] = "translations",
    };
}
