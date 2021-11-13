namespace Smart;

using System;
using System.Runtime.CompilerServices;

public static class ArrayExtensions
{
    //--------------------------------------------------------------------------------
    // Combine
    //--------------------------------------------------------------------------------

    public static T[] Combine<T>(this T[] array, params T[]?[] others)
    {
        var length = array.Length;
        for (var i = 0; i < others.Length; i++)
        {
            var other = others[i];
            if (other is not null)
            {
                length += other.Length;
            }
        }

        if (length == 0)
        {
            return array;
        }

        var result = new T[length];

        array.AsSpan().CopyTo(result.AsSpan());
        var offset = array.Length;

        for (var i = 0; i < others.Length; i++)
        {
            var other = others[i];
            if (other is not null)
            {
                other.AsSpan().CopyTo(result.AsSpan(offset));
                offset += other.Length;
            }
        }

        return result;
    }

    //--------------------------------------------------------------------------------
    // RemoveAt
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] RemoveAt<T>(this T[] array, int offset) => RemoveRange(array, offset, 1);

    public static T[] RemoveRange<T>(this T[] array, int start, int length)
    {
        if ((array.Length == 0) || (length <= 0) || (start >= array.Length))
        {
            return array;
        }

        var remainStart = start + length;
        var remainLength = remainStart > array.Length ? 0 : array.Length - remainStart;
        var result = new T[start + remainLength];

        if (start > 0)
        {
            array.AsSpan(0, start).CopyTo(result);
        }

        if (remainLength > 0)
        {
            array.AsSpan(remainStart).CopyTo(result.AsSpan(start));
        }

        return result;
    }
}
