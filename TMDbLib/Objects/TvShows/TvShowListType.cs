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
