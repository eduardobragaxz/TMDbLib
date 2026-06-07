using TMDbLib.Utilities;

namespace TMDbLib.Objects.General;

/// <summary>
/// Represents the type of credit.
/// </summary>
public enum CreditType
{
    /// <summary>
    /// Unknown credit type.
    /// </summary>
    Unknown,

    /// <summary>
    /// Crew member credit.
    /// </summary>
    [JsonStringEnumMemberName("crew")]
    Crew = 1,

    /// <summary>
    /// Cast member credit.
    /// </summary>
    [JsonStringEnumMemberName("cast")]
    Cast = 2
}
