using System;
using System.Collections.Generic;
using TMDbLib.Objects.General;
using TMDbLib.Utilities;

namespace TMDbLib.Objects.Collections;

/// <summary>
/// Specifies additional methods to include when retrieving collection information.
/// </summary>
[Flags]
public enum CollectionMethods
{
    /// <summary>
    /// No additional methods specified.
    /// </summary>
    [JsonStringEnumMemberName("Undefined")]
    Undefined = 0,

    /// <summary>
    /// Include images for the collection.
    /// </summary>
    [JsonStringEnumMemberName("images")]
    Images = 1,

    /// <summary>
    /// Include translations for the collection.
    /// </summary>
    [JsonStringEnumMemberName("translations")]
    Translations = 2,
}
