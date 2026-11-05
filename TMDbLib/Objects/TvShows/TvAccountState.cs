using System.Text.Json.Serialization;
using TMDbLib.Utilities.Converters;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Account state for a TV show or episode.
/// </summary>
public class TvAccountState
{
    /// <summary>
    /// Gets or sets the user rating.
    /// </summary>
    [JsonPropertyName("rated")]
    [JsonConverter(typeof(AccountStateConverter))]
    public double? Rated { get; set; }
}
