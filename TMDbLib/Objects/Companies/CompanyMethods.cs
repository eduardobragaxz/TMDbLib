using System;
using System.Collections.Generic;
using TMDbLib.Objects.Collections;
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
    /// Include alternative names for the company.
    /// </summary>
    [JsonStringEnumMemberName("alternative_names")]
    AlternativeNames = 2,

    /// <summary>
    /// Include logo images for the company.
    /// </summary>
    [JsonStringEnumMemberName("images")]
    Images = 4,
}
