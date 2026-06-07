using System;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.People;

/// <summary>
/// Specifies additional person data to retrieve from the API.
/// </summary>
[Flags]
public enum PersonMethods
{
    /// <summary>
    /// Undefined or no additional data.
    /// </summary>
    [JsonStringEnumMemberName("Undefined")]
    Undefined = 0,

    /// <summary>
    /// Include movie credits.
    /// </summary>
    [JsonStringEnumMemberName("movie_credits")]
    MovieCredits = 1,

    /// <summary>
    /// Include TV credits.
    /// </summary>
    [JsonStringEnumMemberName("tv_credits")]
    TvCredits = 2,

    /// <summary>
    /// Include external IDs.
    /// </summary>
    [JsonStringEnumMemberName("external_ids")]
    ExternalIds = 4,

    /// <summary>
    /// Include profile images.
    /// </summary>
    [JsonStringEnumMemberName("images")]
    Images = 8,

    /// <summary>
    /// Include tagged images.
    /// </summary>
    [JsonStringEnumMemberName("tagged_images")]
    TaggedImages = 16,

    /// <summary>
    /// Include change history.
    /// </summary>
    [JsonStringEnumMemberName("changes")]
    Changes = 32,

    /// <summary>
    /// Include translations.
    /// </summary>
    [JsonStringEnumMemberName("translations")]
    Translations = 64,

    /// <summary>
    /// Include combined movie and TV credits.
    /// </summary>
    [JsonStringEnumMemberName("combined_credits")]
    CombinedCredits = 128,
}
