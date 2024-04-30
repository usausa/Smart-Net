namespace Smart.Text;

using System.Runtime.CompilerServices;
using System.Text;

public static class StringBuilderExtensions
{
    //--------------------------------------------------------------------------------
    // Append
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendIf(this StringBuilder sb, bool condition, Func<object> valueFactory)
    {
        if (condition)
        {
            var value = valueFactory();
            sb.Append(value);
        }

        return sb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLineIf(this StringBuilder sb, bool condition)
    {
        if (condition)
        {
            sb.AppendLine();
        }

        return sb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLineIf(this StringBuilder sb, bool condition, Func<string?> valueFactory)
    {
        if (condition)
        {
            var value = valueFactory();
            if (value is not null)
            {
                sb.AppendLine(value);
            }
        }

        return sb;
    }

    // With state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendIf<TState>(this StringBuilder sb, bool condition, TState state, Func<TState, object> valueFactory)
    {
        if (condition)
        {
            var value = valueFactory(state);
            sb.Append(value);
        }

        return sb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLineIf<TState>(this StringBuilder sb, bool condition, TState state, Func<TState, string?> valueFactory)
    {
        if (condition)
        {
            var value = valueFactory(state);
            if (value is not null)
            {
                sb.AppendLine(value);
            }
        }

        return sb;
    }

    //--------------------------------------------------------------------------------
    // Trim
    //--------------------------------------------------------------------------------

    private static readonly char[] DefaultTrimChars = [' ', '\t'];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder TrimStart(this StringBuilder sb)
    {
        return TrimStart(sb, DefaultTrimChars);
    }

    public static StringBuilder TrimStart(this StringBuilder sb, params char[] trimChars)
    {
        var i = 0;
        while ((i < sb.Length) && Contains(trimChars, sb[i - 1]))
        {
            i++;
        }

        sb.Remove(0, i);
        return sb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder TrimEnd(this StringBuilder sb)
    {
        return TrimEnd(sb, DefaultTrimChars);
    }

    public static StringBuilder TrimEnd(this StringBuilder sb, params char[] trimChars)
    {
        var i = sb.Length;
        while ((i > 0) && Contains(trimChars, sb[i - 1]))
        {
            i--;
        }

        sb.Remove(i, sb.Length - i);
        return sb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Trim(this StringBuilder sb)
    {
        return Trim(sb, DefaultTrimChars);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Trim(this StringBuilder sb, params char[] trimChars)
    {
        return TrimStart(TrimEnd(sb, trimChars), trimChars);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool Contains(char[] chars, char c)
    {
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == c)
            {
                return true;
            }
        }

        return false;
    }
}
