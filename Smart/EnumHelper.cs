namespace Smart
{
    using System;
    using System.Collections.Generic;

    public static class EnumHelper<T>
        where T : struct
    {
        private static readonly Type EnumType = typeof(T);

        private static readonly Dictionary<T, string> ValueToNames;

        private static readonly Dictionary<string, T> NameToValues;

        static EnumHelper()
        {
            var values = (T[])Enum.GetValues(typeof(T));
            var names = Enum.GetNames(typeof(T));

            ValueToNames = new Dictionary<T, string>(values.Length);
            NameToValues = new Dictionary<string, T>(values.Length);

            for (var i = 0; i < values.Length; i++)
            {
                ValueToNames[values[i]] = names[i];
                NameToValues[names[i]] = values[i];
            }
        }

        public static string GetName(T value)
        {
            return ValueToNames.TryGetValue(value, out var name) ? name : value.ToString();
        }

        public static T ParseValue(string name)
        {
            return NameToValues.TryGetValue(name, out var value) ? value : (T)Enum.Parse(EnumType, name);
        }

        public static bool TryParseValue(string name, out T value)
        {
            return NameToValues.TryGetValue(name, out value) || Enum.TryParse(name, out value);
        }
    }
}
