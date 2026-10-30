namespace Smart;

using System.Collections.ObjectModel;

// ReSharper disable StaticMemberInGenericType
#pragma warning disable CA1000
public static class Enums<T>
    where T : struct, Enum
{
#pragma warning disable CA1810
    private static readonly Dictionary<T, string> ValueToNames;

    private static readonly Dictionary<string, T> NameToValues;

#if NET9_0_OR_GREATER
    private static readonly Dictionary<string, T>.AlternateLookup<ReadOnlySpan<char>> NameToValuesLookup;
#endif

    public static ReadOnlyCollection<T> Values { get; }

    public static ReadOnlyCollection<string> Names { get; }

    public static Type UnderlyingType { get; }

    static Enums()
    {
        var type = typeof(T);
        var values = Enum.GetValues<T>();
        var names = Enum.GetNames<T>();

        UnderlyingType = Enum.GetUnderlyingType(type);
        Values = new ReadOnlyCollection<T>(values);
        Names = new ReadOnlyCollection<string>(names);

        ValueToNames = new Dictionary<T, string>(values.Length);
        NameToValues = new Dictionary<string, T>(values.Length);

        for (var i = 0; i < values.Length; i++)
        {
            ValueToNames[values[i]] = names[i];
            NameToValues[names[i]] = values[i];
        }

#if NET9_0_OR_GREATER
        NameToValuesLookup = NameToValues.GetAlternateLookup<ReadOnlySpan<char>>();
#endif
    }
#pragma warning restore CA1810

    public static string GetName(T value)
    {
        return ValueToNames.TryGetValue(value, out var name) ? name : value.ToString();
    }

    public static T ParseValue(string name)
    {
        return NameToValues.TryGetValue(name, out var value) ? value : Enum.Parse<T>(name);
    }

    public static bool TryParseValue(string name, out T value)
    {
        return NameToValues.TryGetValue(name, out value) || Enum.TryParse(name, out value);
    }

    public static T ParseValue(ReadOnlySpan<char> name)
    {
#if NET9_0_OR_GREATER
        return NameToValuesLookup.TryGetValue(name, out var value) ? value : Enum.Parse<T>(name);
#else
        return Enum.Parse<T>(name);
#endif
    }

    public static bool TryParseValue(ReadOnlySpan<char> name, out T value)
    {
#if NET9_0_OR_GREATER
        return NameToValuesLookup.TryGetValue(name, out value) || Enum.TryParse(name, out value);
#else
        return Enum.TryParse(name, out value);
#endif
    }
}
#pragma warning restore CA1000
// ReSharper restore StaticMemberInGenericType
