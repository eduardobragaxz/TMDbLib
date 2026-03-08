using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.Exceptions;
using TMDbLib.Objects.General;
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
[JsonSerializable(typeof(CombinedCreditsCastTv))]
[JsonSerializable(typeof(CombinedCreditsCrewMovie))]
[JsonSerializable(typeof(CombinedCreditsCrewTv))]
[JsonSerializable(typeof(KnownForMovie))]
[JsonSerializable(typeof(KnownForTv))]
[JsonSerializable(typeof(TaggedImage))]
[JsonSerializable(typeof(List<int>))]
[JsonSerializable(typeof(TMDbStatusMessage))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
