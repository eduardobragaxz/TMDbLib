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
    TvDb
}
