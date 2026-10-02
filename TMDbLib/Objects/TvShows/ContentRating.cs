namespace TMDbLib.Objects.TvShows;

/// <summary>
/// Represents a content rating for a TV show in a specific country.
/// </summary>
public record ContentRating
{
    /// <summary>
    /// Gets or sets a country code, e.g. US.
    /// </summary>
    [JsonPropertyName("iso_3166_1")]
    public string Iso_3166_1 { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the content rating value.
    /// </summary>
    [JsonPropertyName("rating")]
    public string Rating { get; init; } = string.Empty;
}
