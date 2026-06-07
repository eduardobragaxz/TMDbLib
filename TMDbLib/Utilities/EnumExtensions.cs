using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace TMDbLib.Utilities;

/// <summary>
/// Extension methods for enum types.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Gets the description of an enum value from its <see cref="JsonStringEnumMemberNameAttribute"/>, or the enum name if no attribute is present.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="enumerationValue">The enum value.</param>
    /// <returns>The description string from the attribute, or the enum value name.</returns>
    public static string GetDescription<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(this T enumerationValue)
        where T : struct
    {
        var type = typeof(T);

        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
        }

        var requestedName = $"{enumerationValue}";
        var fieldMember = type.GetField(requestedName);

        if (fieldMember is not null)
        {
            var attributes = fieldMember.CustomAttributes;

            foreach (var attributeData in attributes)
            {
                if (attributeData.AttributeType != typeof(JsonStringEnumMemberNameAttribute))
                {
                    continue;
                }

                // Pull out the Value
                if (attributeData.ConstructorArguments.Count == 0)
                {
                    break;
                }

                var argument = attributeData.ConstructorArguments[0];

                if (argument.Value is string stringValue)
                {
                    return stringValue;
                }

                break;
            }
        }

        return requestedName;
    }
}
