using System.Text.Json.Serialization;

namespace TMDbLib.Objects.Account;

/// <summary>
/// Represents an avatar associated with an account.
/// </summary>
public class Avatar
{
    /// <summary>
    /// Gets or sets the Gravatar information.
    /// </summary>
    [JsonPropertyName("gravatar")]
    public Gravatar? Gravatar { get; set; }

    /// <summary>
    /// Gets or sets the TMDb avatar.
    /// </summary>
    [JsonPropertyName("tmdb")]
    public TMDbAvatar? TMDbAvatar { get; set; }
}
