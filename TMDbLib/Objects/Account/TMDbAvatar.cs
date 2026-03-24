using System.Text.Json.Serialization;

namespace TMDbLib.Objects.Account;

/// <summary>
/// Represents the avatar set in TDMb.
/// </summary>
public class TMDbAvatar
{
    /// <summary>
    /// Gets or sets the profile avatar image path.
    /// </summary>
    [JsonPropertyName("avatar_path")]
    public string? AvatarPath { get; set; }
}
