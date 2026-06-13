using System.Collections.Generic;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Defines the types of TV show lists available.
/// </summary>
public enum TvShowListType
{
    /// <summary>
    /// TV shows currently on the air.
    /// </summary>
    [JsonStringEnumMemberName("on_the_air")]
    OnTheAir,

    /// <summary>
    /// TV shows airing today.
    /// </summary>
    [JsonStringEnumMemberName("airing_today")]
    AiringToday,

    /// <summary>
    /// Top rated TV shows.
    /// </summary>
    [JsonStringEnumMemberName("top_rated")]
    TopRated,

    /// <summary>
    /// Popular TV shows.
    /// </summary>
    [JsonStringEnumMemberName("popular")]
    Popular
}

public class TvShowListTypeClass
{
    public static Dictionary<TvShowListType, string> TvShowListTypeDescriptions => new ()
    {
        [TvShowListType.OnTheAir] = "on_the_air",
        [TvShowListType.AiringToday] = "airing_today",
        [TvShowListType.TopRated] = "top_rated",
        [TvShowListType.Popular] = "popular",
    };
}
