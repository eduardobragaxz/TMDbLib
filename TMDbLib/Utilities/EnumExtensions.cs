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
public static class EnumExtensions
{
    /// <summary>
    /// Gets the description of an enum value from its <see cref="JsonStringEnumMemberNameAttribute"/>, or the enum name if no attribute is present.
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
            Type _ when type == typeof(AccountListsMethods) => AccountListsDescriptions[(AccountListsMethods)enumerationValue],
            Type _ when type == typeof(TimeWindow) => TimeWindowClass.TimeWindowDescriptions[(TimeWindow)enumerationValue],
            Type _ when type == typeof(AccountSortBy) => AccountSortByClass.AccountSortByDescriptions[(AccountSortBy)enumerationValue],
            Type _ when type == typeof(SortOrder) => SortOrderClass.SortOrderDescriptions[(SortOrder)enumerationValue],
            Type _ when type == typeof(MediaType) => MediaTypeClass.MediaTypeDescriptions[(MediaType)enumerationValue],
            Type _ when type == typeof(AccountSortBy) => AccountSortByClass.AccountSortByDescriptions[(AccountSortBy)enumerationValue],
            Type _ when type == typeof(CollectionMethods) => CollectionMethodsClass.CollectionDescriptions[(CollectionMethods)enumerationValue],
            Type _ when type == typeof(CompanyMethods) => CompanyMethodsClass.CompanyMethodsDescriptions[(CompanyMethods)enumerationValue],
            Type _ when type == typeof(FindExternalSource) => FindExternalSourceClass.FindExternalSourceDescriptions[(FindExternalSource)enumerationValue],
            Type _ when type == typeof(MovieMethods) => MovieMethodsClass.MovieMethodsDescriptions[(MovieMethods)enumerationValue],
            Type _ when type == typeof(PersonMethods) => PersonMethodsClass.PersonMethodsDescriptions[(PersonMethods)enumerationValue],
            Type _ when type == typeof(TvEpisodeMethods) => TvEpisodeMethodsClass.TvEpisodeMethodsDescriptions[(TvEpisodeMethods)enumerationValue],
            Type _ when type == typeof(TvSeasonMethods) => TvSeasonMethodsClass.TvSeasonMethodsDescriptions[(TvSeasonMethods)enumerationValue],
            Type _ when type == typeof(TvShowMethods) => TvShowMethodsClass.TvShowMethodsDescriptions[(TvShowMethods)enumerationValue],
            Type _ when type == typeof(TvShowListType) => TvShowListTypeClass.TvShowListTypeDescriptions[(TvShowListType)enumerationValue],
            Type _ when type == typeof(DiscoverMovieSortBy) => DiscoverMovieSortByClass.DiscoverMovieSortByDescriptions[(DiscoverMovieSortBy)enumerationValue],
            Type _ when type == typeof(WatchMonetizationType) => WatchMonetizationTypeClass.WatchMonetizationTypeDescriptions[(WatchMonetizationType)enumerationValue],
            Type _ when type == typeof(DiscoverTvShowSortBy) => DiscoverTvShowSortByClass.DiscoverTvShowSortByDescriptions[(DiscoverTvShowSortBy)enumerationValue],
            _ => $"{enumerationValue}"
        };
    }
}
