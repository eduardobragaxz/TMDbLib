using System.Text.Json.Serialization;

namespace TMDbLib.Objects.Account;

/// <summary>
/// Represents the avatar set in TDMb.
/// </summary>
public class TMDbAvatar
{
    [JsonPropertyName("avatar_path")]
    public string? AvatarPath { get; set; }
}
