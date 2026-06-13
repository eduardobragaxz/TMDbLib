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

public class FindExternalSourceClass
{
    public static Dictionary<FindExternalSource, string> FindExternalSourceDescriptions => new ()
    {
        [FindExternalSource.Imdb] = "imdb_id",
        [FindExternalSource.TvDb] = "tvdb_id"
    };
}
