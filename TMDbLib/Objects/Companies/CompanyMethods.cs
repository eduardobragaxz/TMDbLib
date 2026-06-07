using System;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Companies;

/// <summary>
/// Specifies additional methods to include when retrieving company information.
/// </summary>
[Flags]
public enum CompanyMethods
{
    /// <summary>
    /// No additional methods specified.
    /// </summary>
    [JsonStringEnumMemberName("Undefined")]
    Undefined = 0,

    /// <summary>
    /// Include movies associated with the company.
    /// </summary>
    [JsonStringEnumMemberName("movies")]
    Movies = 1
}
