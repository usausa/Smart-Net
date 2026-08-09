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

    public static StringBuilder TrimStart(this StringBuilder sb)
    {
        var i = 0;
        while ((i < sb.Length) && Char.IsWhiteSpace(sb[i]))
        {
            i++;
        }

        sb.Remove(0, i);
        return sb;
    }

    public static StringBuilder TrimStart(this StringBuilder sb, char trimChar)
    {
        var i = 0;
        while ((i < sb.Length) && (sb[i] == trimChar))
        {
            i++;
        }

        sb.Remove(0, i);
        return sb;
    }

    public static StringBuilder TrimStart(this StringBuilder sb, params ReadOnlySpan<char> trimChars)
    {
        if (trimChars.IsEmpty)
        {
            return sb.TrimStart();
        }

        var i = 0;
        while ((i < sb.Length) && trimChars.Contains(sb[i]))
        {
            i++;
        }

        sb.Remove(0, i);
        return sb;
    }

    public static StringBuilder TrimEnd(this StringBuilder sb)
    {
        var i = sb.Length;
        while ((i > 0) && Char.IsWhiteSpace(sb[i - 1]))
        {
            i--;
        }

        sb.Remove(i, sb.Length - i);
        return sb;
    }

    public static StringBuilder TrimEnd(this StringBuilder sb, char trimChar)
    {
        var i = sb.Length;
        while ((i > 0) && (sb[i - 1] == trimChar))
        {
            i--;
        }

        sb.Remove(i, sb.Length - i);
        return sb;
    }

    public static StringBuilder TrimEnd(this StringBuilder sb, params ReadOnlySpan<char> trimChars)
    {
        if (trimChars.IsEmpty)
        {
            return sb.TrimEnd();
        }

        var i = sb.Length;
        while ((i > 0) && trimChars.Contains(sb[i - 1]))
        {
            i--;
        }

        sb.Remove(i, sb.Length - i);
        return sb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Trim(this StringBuilder sb)
    {
        return sb.TrimEnd().TrimStart();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Trim(this StringBuilder sb, char trimChar)
    {
        return sb.TrimEnd(trimChar).TrimStart(trimChar);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Trim(this StringBuilder sb, params ReadOnlySpan<char> trimChars)
    {
        return sb.TrimEnd(trimChars).TrimStart(trimChars);
    }
}
