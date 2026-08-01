using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Account;
using TMDbLib.Objects.Collections;
using TMDbLib.Objects.Companies;
using TMDbLib.Objects.Discover;
using TMDbLib.Objects.Find;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Trending;
using TMDbLib.Objects.TvShows;
using static TMDbLib.Client.TMDbClient;

namespace TMDbLib.Utilities;

/// <summary>
/// Extension methods for enum types.
/// </summary>
internal static class EnumExtensions
{
    private static readonly Dictionary<AccountListsMethods, string> _accountListsDescriptions = new ()
    {
        [AccountListsMethods.FavoriteMovies] = "favorite/movies",
        [AccountListsMethods.FavoriteTv] = "favorite/tv",
        [AccountListsMethods.RatedMovies] = "rated/movies",
        [AccountListsMethods.RatedTv] = "rated/tv",
        [AccountListsMethods.RatedTvEpisodes] = "rated/tv/episodes",
        [AccountListsMethods.MovieWatchlist] = "watchlist/movies",
        [AccountListsMethods.TvWatchlist] = "watchlist/tv",
    };

    private static readonly Dictionary<TimeWindow, string> _timeWindowDescriptions = new ()
    {
        [TimeWindow.Day] = "day",
        [TimeWindow.Week] = "week",
    };

    private static readonly Dictionary<AccountSortBy, string> _accountSortByDescriptions = new ()
    {
        [AccountSortBy.Undefined] = "Undefined",
        [AccountSortBy.CreatedAt] = "created_at",
    };

    private static readonly Dictionary<SortOrder, string> _sortOrderDescriptions = new ()
    {
        [SortOrder.Undefined] = "Undefined",
        [SortOrder.Ascending] = "asc",
        [SortOrder.Descending] = "desc"
    };

    private static readonly Dictionary<MediaType, string> _mediaTypeDescriptions = new ()
    {
        [MediaType.Unknown] = "Unknown",
        [MediaType.Movie] = "Movie",
        [MediaType.Tv] = "Tv",
        [MediaType.Person] = "Person",
        [MediaType.Episode] = "Episode",
        [MediaType.TvEpisode] = "tv_episode",
        [MediaType.Season] = "Season",
        [MediaType.TvSeason] = "tv_season",
        [MediaType.Collection] = "Collection"
    };

    private static readonly Dictionary<CollectionMethods, string> _collectionDescriptions = new ()
    {
        [CollectionMethods.Undefined] = "Undefined",
        [CollectionMethods.Images] = "images",
        [CollectionMethods.Undefined] = "translations"
    };

    private static readonly Dictionary<CompanyMethods, string> _companyMethodsDescriptions = new ()
    {
        [CompanyMethods.Undefined] = "Undefined",
        [CompanyMethods.Movies] = "movies",
    };

    private static readonly Dictionary<FindExternalSource, string> _findExternalSourceDescriptions = new ()
    {
        [FindExternalSource.Imdb] = "imdb_id",
        [FindExternalSource.TvDb] = "tvdb_id"
    };

    private static readonly Dictionary<MovieMethods, string> _movieMethodsDescriptions = new ()
    {
        [MovieMethods.Undefined] = "Undefined",
        [MovieMethods.AlternativeTitles] = "alternative_titles",
        [MovieMethods.Credits] = "credits",
        [MovieMethods.Images] = "images",
        [MovieMethods.Keywords] = "keywords",
        [MovieMethods.Releases] = "releases",
        [MovieMethods.Videos] = "videos",
        [MovieMethods.Translations] = "translations",
        [MovieMethods.Similar] = "similar",
        [MovieMethods.Reviews] = "reviews",
        [MovieMethods.Lists] = "lists",
        [MovieMethods.AccountStates] = "account_states",
        [MovieMethods.ReleaseDates] = "release_dates",
        [MovieMethods.Recommendations] = "recommendations",
        [MovieMethods.ExternalIds] = "external_ids",
        [MovieMethods.WatchProviders] = "watch/providers"
    };

    private static readonly Dictionary<PersonMethods, string> _personMethodsDescriptions = new ()
    {
        [PersonMethods.Undefined] = "Undefined",
        [PersonMethods.MovieCredits] = "movie_credits",
        [PersonMethods.TvCredits] = "tv_credits",
        [PersonMethods.ExternalIds] = "external_ids",
        [PersonMethods.Images] = "images",
        [PersonMethods.TaggedImages] = "tagged_images",
        [PersonMethods.Changes] = "changes",
        [PersonMethods.Translations] = "translations",
        [PersonMethods.CombinedCredits] = "combined_credits"
    };

    private static readonly Dictionary<TvEpisodeMethods, string> _tvEpisodeMethodsDescriptions = new ()
    {
        [TvEpisodeMethods.Undefined] = "Undefined",
        [TvEpisodeMethods.Credits] = "credits",
        [TvEpisodeMethods.Images] = "images",
        [TvEpisodeMethods.ExternalIds] = "external_ids",
        [TvEpisodeMethods.Videos] = "videos",
        [TvEpisodeMethods.AccountStates] = "account_states",
        [TvEpisodeMethods.Translations] = "translations",
    };

    private static readonly Dictionary<TvSeasonMethods, string> _tvSeasonMethodsDescriptions = new ()
    {
        [TvSeasonMethods.Undefined] = "Undefined",
        [TvSeasonMethods.Credits] = "credits",
        [TvSeasonMethods.Images] = "images",
        [TvSeasonMethods.ExternalIds] = "external_ids",
        [TvSeasonMethods.Videos] = "videos",
        [TvSeasonMethods.AccountStates] = "account_states",
        [TvSeasonMethods.Translations] = "translations",
    };

    private static readonly Dictionary<TvShowMethods, string> _tvShowMethodsDescriptions = new ()
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

    private static readonly Dictionary<TvShowListType, string> _tvShowListTypeDescriptions = new ()
    {
        [TvShowListType.OnTheAir] = "on_the_air",
        [TvShowListType.AiringToday] = "airing_today",
        [TvShowListType.TopRated] = "top_rated",
        [TvShowListType.Popular] = "popular",
    };

    private static readonly Dictionary<DiscoverMovieSortBy, string> _discoverMovieSortByDescriptions = new ()
    {
        [DiscoverMovieSortBy.Undefined] = "Undefined",
        [DiscoverMovieSortBy.Popularity] = "popularity.asc",
        [DiscoverMovieSortBy.PopularityDesc] = "popularity.desc",
        [DiscoverMovieSortBy.ReleaseDate] = "release_date.asc",
        [DiscoverMovieSortBy.ReleaseDateDesc] = "release_date.desc",
        [DiscoverMovieSortBy.Revenue] = "revenue.asc",
        [DiscoverMovieSortBy.RevenueDesc] = "revenue.desc",
        [DiscoverMovieSortBy.PrimaryReleaseDate] = "primary_release_date.asc",
        [DiscoverMovieSortBy.PrimaryReleaseDateDesc] = "primary_release_date.desc",
        [DiscoverMovieSortBy.OriginalTitle] = "original_title.asc",
        [DiscoverMovieSortBy.OriginalTitleDesc] = "original_title.desc",
        [DiscoverMovieSortBy.VoteAverage] = "vote_average.asc",
        [DiscoverMovieSortBy.VoteAverageDesc] = "vote_average.desc",
        [DiscoverMovieSortBy.VoteCount] = "vote_count.asc",
        [DiscoverMovieSortBy.VoteCountDesc] = "vote_count.desc",
    };

    private static readonly Dictionary<WatchMonetizationType, string> _watchMonetizationTypeDescriptions = new ()
    {
        [WatchMonetizationType.Flatrate] = "flatrate",
        [WatchMonetizationType.Free] = "free",
        [WatchMonetizationType.Ads] = "ads",
        [WatchMonetizationType.Rent] = "rent",
        [WatchMonetizationType.Buy] = "buy",
    };

    private static readonly Dictionary<DiscoverTvShowSortBy, string> _discoverTvShowSortByDescriptions = new ()
    {
        [DiscoverTvShowSortBy.Undefined] = "Undefined",
        [DiscoverTvShowSortBy.VoteAverage] = "vote_average.asc",
        [DiscoverTvShowSortBy.VoteAverageDesc] = "vote_average.desc",
        [DiscoverTvShowSortBy.FirstAirDate] = "first_air_date.asc",
        [DiscoverTvShowSortBy.FirstAirDateDesc] = "first_air_date.desc",
        [DiscoverTvShowSortBy.Popularity] = "popularity.asc",
        [DiscoverTvShowSortBy.PopularityDesc] = "popularity.desc",
        [DiscoverTvShowSortBy.Revenue] = "revenue.asc",
        [DiscoverTvShowSortBy.RevenueDesc] = "revenue.desc",
        [DiscoverTvShowSortBy.PrimaryReleaseDate] = "primary_release_date.asc",
        [DiscoverTvShowSortBy.PrimaryReleaseDateDesc] = "primary_release_date.desc",
        [DiscoverTvShowSortBy.VoteCount] = "vote_count.asc",
        [DiscoverTvShowSortBy.VoteCountDesc] = "vote_count.desc",
    };

    /// <summary>
    /// Gets the description of an enum value from its associated Dictionary, or the enum name if no Dictionary is present.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="enumerationValue">The enum value.</param>
    /// <returns>The description string from the attribute, or the enum value name.</returns>
    public static string GetDescription<T>(this Enum enumerationValue)
    {
        var type = typeof(T);

        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
        }

        return type switch
        {
            Type _ when type == typeof(AccountListsMethods) => _accountListsDescriptions[(AccountListsMethods)enumerationValue],
            Type _ when type == typeof(TimeWindow) => _timeWindowDescriptions[(TimeWindow)enumerationValue],
            Type _ when type == typeof(AccountSortBy) => _accountSortByDescriptions[(AccountSortBy)enumerationValue],
            Type _ when type == typeof(SortOrder) => _sortOrderDescriptions[(SortOrder)enumerationValue],
            Type _ when type == typeof(MediaType) => _mediaTypeDescriptions[(MediaType)enumerationValue],
            Type _ when type == typeof(CollectionMethods) => _collectionDescriptions[(CollectionMethods)enumerationValue],
            Type _ when type == typeof(CompanyMethods) => _companyMethodsDescriptions[(CompanyMethods)enumerationValue],
            Type _ when type == typeof(FindExternalSource) => _findExternalSourceDescriptions[(FindExternalSource)enumerationValue],
            Type _ when type == typeof(MovieMethods) => _movieMethodsDescriptions[(MovieMethods)enumerationValue],
            Type _ when type == typeof(PersonMethods) => _personMethodsDescriptions[(PersonMethods)enumerationValue],
            Type _ when type == typeof(TvEpisodeMethods) => _tvEpisodeMethodsDescriptions[(TvEpisodeMethods)enumerationValue],
            Type _ when type == typeof(TvSeasonMethods) => _tvSeasonMethodsDescriptions[(TvSeasonMethods)enumerationValue],
            Type _ when type == typeof(TvShowMethods) => _tvShowMethodsDescriptions[(TvShowMethods)enumerationValue],
            Type _ when type == typeof(TvShowListType) => _tvShowListTypeDescriptions[(TvShowListType)enumerationValue],
            Type _ when type == typeof(DiscoverMovieSortBy) => _discoverMovieSortByDescriptions[(DiscoverMovieSortBy)enumerationValue],
            Type _ when type == typeof(WatchMonetizationType) => _watchMonetizationTypeDescriptions[(WatchMonetizationType)enumerationValue],
            Type _ when type == typeof(DiscoverTvShowSortBy) => _discoverTvShowSortByDescriptions[(DiscoverTvShowSortBy)enumerationValue],
            _ => $"{enumerationValue}"
        };
    }
}
