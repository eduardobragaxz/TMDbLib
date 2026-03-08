using System.Text.Json.Serialization;

namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Represents the account state for a TV show or episode.
/// </summary>
public class TvAccountState
{
    /// <summary>
    /// Gets or sets the user rating.
    /// </summary>
    [JsonPropertyName("rating")]
    public double? Rating { get; set; }
}
