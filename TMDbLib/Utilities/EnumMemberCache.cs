using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace TMDbLib.Utilities;

internal static class EnumMemberCache
{
    private static readonly Dictionary<Type, Dictionary<object, string?>> _memberCache = [];

    private static Dictionary<object, string?> GetOrPrepareCache([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors
        | DynamicallyAccessedMemberTypes.PublicConstructors
        | DynamicallyAccessedMemberTypes.PublicMethods
        | DynamicallyAccessedMemberTypes.NonPublicMethods
        | DynamicallyAccessedMemberTypes.PublicFields
        | DynamicallyAccessedMemberTypes.PublicNestedTypes
        | DynamicallyAccessedMemberTypes.NonPublicNestedTypes
        | DynamicallyAccessedMemberTypes.PublicProperties
        | DynamicallyAccessedMemberTypes.NonPublicProperties
        | DynamicallyAccessedMemberTypes.PublicEvents
        | DynamicallyAccessedMemberTypes.NonPublicEvents
        | DynamicallyAccessedMemberTypes.NonPublicFields)] Type type)
    {
        if (!type.GetTypeInfo().IsEnum)
        {
            throw new ArgumentException(nameof(_memberCache));
        }

        Dictionary<object, string?>? cache;
        lock (_memberCache)
        {
            if (_memberCache.TryGetValue(type, out cache))
            {
                return cache;
            }
        }

        cache = [];

        foreach (var fieldInfo in type.GetTypeInfo().DeclaredMembers.OfType<FieldInfo>().Where(s => s.IsStatic))
        {
            var value = fieldInfo.GetValue(null);
            if (value is null)
            {
                continue;
            }

            var attrib = fieldInfo.CustomAttributes.FirstOrDefault(s => s.AttributeType == typeof(JsonStringEnumMemberNameAttribute));

            if (attrib is null)
            {
                cache[value] = value.ToString();
            }
            else
            {
                var arg = attrib.ConstructorArguments.FirstOrDefault();
                var JsonStringEnumMemberName = arg.Value as string;

                cache[value] = JsonStringEnumMemberName;
            }
        }

        lock (_memberCache)
        {
            _memberCache[type] = cache;
        }

        return cache;
    }

    public static T? GetValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors
        | DynamicallyAccessedMemberTypes.NonPublicConstructors
        | DynamicallyAccessedMemberTypes.PublicMethods
        | DynamicallyAccessedMemberTypes.NonPublicMethods
        | DynamicallyAccessedMemberTypes.PublicFields
        | DynamicallyAccessedMemberTypes.NonPublicFields
        | DynamicallyAccessedMemberTypes.PublicNestedTypes
        | DynamicallyAccessedMemberTypes.NonPublicNestedTypes
        | DynamicallyAccessedMemberTypes.PublicProperties
        | DynamicallyAccessedMemberTypes.NonPublicProperties
        | DynamicallyAccessedMemberTypes.PublicEvents
        | DynamicallyAccessedMemberTypes.NonPublicEvents)] T>(string input)
    {
        var cache = GetOrPrepareCache(typeof(T));

        foreach (var pair in cache)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(pair.Value, input))
            {
                return (T)pair.Key;
            }
        }

        return default;
    }

    public static object? GetValue(string? input, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.NonPublicConstructors
        | DynamicallyAccessedMemberTypes.PublicConstructors
        | DynamicallyAccessedMemberTypes.PublicMethods
        | DynamicallyAccessedMemberTypes.NonPublicMethods
        | DynamicallyAccessedMemberTypes.PublicFields
        | DynamicallyAccessedMemberTypes.PublicNestedTypes
        | DynamicallyAccessedMemberTypes.NonPublicNestedTypes
        | DynamicallyAccessedMemberTypes.PublicProperties
        | DynamicallyAccessedMemberTypes.NonPublicProperties
        | DynamicallyAccessedMemberTypes.PublicEvents
        | DynamicallyAccessedMemberTypes.NonPublicEvents
        | DynamicallyAccessedMemberTypes.NonPublicFields)] Type type)
    {
        var cache = GetOrPrepareCache(type);

        foreach (var pair in cache)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(pair.Value, input))
            {
                return pair.Key;
            }
        }

        return null;
    }

    public static string? GetString(object? value)
    {
        if (value is null)
        {
            return null;
        }

        var cache = GetOrPrepareCache(typeof(object));

        cache.TryGetValue(value, out var str);

        return str;
    }
}
