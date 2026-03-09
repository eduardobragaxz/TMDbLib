using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TMDbLib.Objects.General;
using TMDbLib.Objects.TvShows;

namespace TMDbLib.Utilities.Converters;

internal class AccountStateConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(AccountState) ||
                objectType == typeof(TvAccountState) ||
                objectType == typeof(TvEpisodeAccountState) ||
                objectType == typeof(TvEpisodeAccountStateWithNumber);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(AccountState))
        {
            return new AccountStateConverter();
        }
        else if (typeToConvert == typeof(TvAccountState))
        {
            return new TVAccountStateConverter();
        }
        else if (typeToConvert == typeof(TvEpisodeAccountState))
        {
            return new TvEpisodeAccountStateConverter();
        }
        else
        {
            return new TvEpisodeAccountStateWithNumberConverter();
        }
    }
}
