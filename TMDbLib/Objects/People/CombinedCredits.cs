using System.Collections.Generic;
using System.Text.Json.Serialization;
using TMDbLib.Utilities.Converters;

namespace TMDbLib.Objects.People;

/// <summary>
/// Represents combined movie and TV credits for a person.
/// </summary>
public class CombinedCredits
{
    /// <summary>
    /// Gets or sets the list of combined cast roles (both movie and TV).
    /// </summary>
    [JsonPropertyName("cast")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    [JsonConverter(typeof(CombinedCreditsCastConverter))]
    public List<CombinedCreditsCastBase>? Cast { get; set; }

    /// <summary>
    /// Gets or sets the list of combined crew jobs (both movie and TV).
    /// </summary>
    [JsonPropertyName("crew")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    [JsonConverter(typeof(CombinedCreditsCrewConverter))]
    public List<CombinedCreditsCrewBase>? Crew { get; set; }

    /// <summary>
    /// Gets or sets the person ID.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }
}
