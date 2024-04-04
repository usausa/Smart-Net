namespace Smart.Text.Json;

using System;
using System.Text.Json;

public sealed class JsonKeyCamelCaseNamingPolicy : JsonNamingPolicy
{
    public static JsonKeyCamelCaseNamingPolicy Instance => new();

    private JsonKeyCamelCaseNamingPolicy()
    {
    }

    public override string ConvertName(string name)
    {
        if (String.IsNullOrEmpty(name))
        {
            return name;
        }

        return String.Create(name.Length, name, static (chars, source) =>
        {
            source.CopyTo(chars);

            var toLower = true;
            for (var i = 0; i < chars.Length; i++)
            {
                if (toLower)
                {
                    chars[i] = Char.ToLowerInvariant(chars[i]);
                    toLower = false;
                }
                else if (chars[i] == '.')
                {
                    toLower = true;
                }
            }
        });
    }
}
