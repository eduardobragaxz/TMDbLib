using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.Exceptions;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace TMDbLib.Utilities;

[JsonSerializable(typeof(AccountState))]
[JsonSerializable(typeof(TvAccountState))]
[JsonSerializable(typeof(TvEpisodeAccountState))]
[JsonSerializable(typeof(TvEpisodeAccountStateWithNumber))]
[JsonSerializable(typeof(MediaType))]
[JsonSerializable(typeof(SearchMovie))]
[JsonSerializable(typeof(SearchTv))]
[JsonSerializable(typeof(SearchTvEpisode))]
[JsonSerializable(typeof(SearchTvSeason))]
[JsonSerializable(typeof(SearchPerson))]
[JsonSerializable(typeof(SearchCollection))]
[JsonSerializable(typeof(SearchBase))]
[JsonSerializable(typeof(ChangeItemBase))]
[JsonSerializable(typeof(CombinedCreditsCastMovie))]
[JsonSerializable(typeof(CombinedCreditsCrewMovie))]
[JsonSerializable(typeof(CombinedCreditsCastTv), TypeInfoPropertyName = "TMDbLib_Objects_People_CombinedCreditsCastTv")]
[JsonSerializable(typeof(CombinedCreditsCrewTv), TypeInfoPropertyName = "TMDbLib_Objects_People_CombinedCreditsCrewTv")]
[JsonSerializable(typeof(KnownForMovie))]
[JsonSerializable(typeof(KnownForTv))]
[JsonSerializable(typeof(TaggedImage))]
[JsonSerializable(typeof(List<int>))]
[JsonSerializable(typeof(TMDbStatusMessage))]
[JsonSerializable(typeof(SearchContainer<SearchBase>))]
[JsonSerializable(typeof(Movie))]
[JsonSerializable(typeof(TvShow))]
[JsonSerializable(typeof(TvSeason))]
[JsonSerializable(typeof(Objects.Movies.Credits))]
[JsonSerializable(typeof(Objects.Movies.Cast))]
[JsonSerializable(typeof(TMDbLib.Objects.TvShows.Credits), TypeInfoPropertyName = "TMDbLib_Objects_TvShows_Credits")]
[JsonSerializable(typeof(Objects.TvShows.Cast), TypeInfoPropertyName = "TMDbLib_Objects_TvShows_Cast")]
[JsonSerializable(typeof(List<Objects.TvShows.Cast>), TypeInfoPropertyName = "List_TMDbLib_Objects_TvShows_Cast")]
[JsonSerializable(typeof(Person))]
[JsonSerializable(typeof(SearchContainerWithId<TaggedImage>))]
[JsonSerializable(typeof(TvEpisodeAccountState))]
[JsonSerializable(typeof(TvEpisodeAccountStateWithNumber))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
