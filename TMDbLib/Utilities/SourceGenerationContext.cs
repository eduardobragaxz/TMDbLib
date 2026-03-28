using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Account;
using TMDbLib.Objects.Authentication;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.Exceptions;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Lists;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;
using static TMDbLib.Rest.RestRequest;

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
[JsonSerializable(typeof(ChangeItemAdded))]
[JsonSerializable(typeof(ChangeItemCreated))]
[JsonSerializable(typeof(ChangeItemUpdated))]
[JsonSerializable(typeof(ChangeItemDeleted))]
[JsonSerializable(typeof(ChangeItemDestroyed))]
[JsonSerializable(typeof(CombinedCreditsCastMovie))]
[JsonSerializable(typeof(CombinedCreditsCrewMovie))]
[JsonSerializable(typeof(CombinedCreditsCastTv), TypeInfoPropertyName = "TMDbLib_Objects_People_CombinedCreditsCastTv")]
[JsonSerializable(typeof(CombinedCreditsCrewTv), TypeInfoPropertyName = "TMDbLib_Objects_People_CombinedCreditsCrewTv")]
[JsonSerializable(typeof(KnownForBase))]
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
[JsonSerializable(typeof(Objects.TvShows.Credits), TypeInfoPropertyName = "TMDbLib_Objects_TvShows_Credits")]
[JsonSerializable(typeof(Objects.TvShows.Cast), TypeInfoPropertyName = "TMDbLib_Objects_TvShows_Cast")]
[JsonSerializable(typeof(List<Objects.TvShows.Cast>), TypeInfoPropertyName = "List_TMDbLib_Objects_TvShows_Cast")]
[JsonSerializable(typeof(Person))]
[JsonSerializable(typeof(SearchContainerWithId<TaggedImage>))]
[JsonSerializable(typeof(TvEpisodeAccountState))]
[JsonSerializable(typeof(TvEpisodeAccountStateWithNumber))]
[JsonSerializable(typeof(Objects.Collections.Collection))]
[JsonSerializable(typeof(object))]
[JsonSerializable(typeof(TvEpisode))]
[JsonSerializable(typeof(TMDbLib.Objects.Authentication.Token))]
[JsonSerializable(typeof(UserSession))]
[JsonSerializable(typeof(AccountDetails))]
[JsonSerializable(typeof(SearchContainer<AccountList>))]
[JsonSerializable(typeof(SearchContainer<SearchMovieWithRating>))]
[JsonSerializable(typeof(SearchContainerWithId<ListResult>))]
[JsonSerializable(typeof(MemoryStream))]
[JsonSerializable(typeof(WatchListBody))]
[JsonSerializable(typeof(FavoriteListBody))]
[JsonSerializable(typeof(ListBody))]
[JsonSerializable(typeof(RatingBody))]
[JsonSerializable(typeof(ManipulateListBody))]
[JsonSerializable(typeof(PostReply))]
[JsonSerializable(typeof(TMDbConfig))]
[JsonSerializable(typeof(SearchContainer<AccountSearchTv>))]
[JsonSerializable(typeof(ListCreateReply))]
[JsonSerializable(typeof(GenericList))]
[JsonSerializable(typeof(GuestSession))]
[JsonSerializable(typeof(SearchContainerWithId<ReviewBase>))]
[JsonSerializable(typeof(ReviewBase))]
[JsonSerializable(typeof(Review))]
[JsonSerializable(typeof(SearchContainer<AccountSearchTvEpisode>))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
