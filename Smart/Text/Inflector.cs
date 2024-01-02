namespace Smart.Text;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class Inflector
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Pascalize(ReadOnlySpan<char> word) => Camelize(word, true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Camelize(ReadOnlySpan<char> word) => Camelize(word, false);

    [SkipLocalsInit]
    public static unsafe string Camelize(ReadOnlySpan<char> word, bool toUpper)
    {
        if (word.IsEmpty)
        {
            return string.Empty;
        }

        var length = word.Length;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];

        ref var start = ref MemoryMarshal.GetReference(buffer);
        ref var b = ref start;

        ref var c = ref MemoryMarshal.GetReference(word);
        ref var end = ref Unsafe.Add(ref c, length);

        var isLowerPrevious = false;
        do
        {
            if (c == '_')
            {
                toUpper = true;
            }
            else
            {
                if (toUpper)
                {
                    b = Char.ToUpperInvariant(c);
                    b = ref Unsafe.Add(ref b, 1);
                    toUpper = false;
                }
                else if (isLowerPrevious)
                {
                    b = c;
                    b = ref Unsafe.Add(ref b, 1);
                }
                else
                {
                    b = Char.ToLowerInvariant(c);
                    b = ref Unsafe.Add(ref b, 1);
                }

                isLowerPrevious = Char.IsLower(c);
            }

            c = ref Unsafe.Add(ref c, 1);
        }
        while (Unsafe.IsAddressLessThan(ref c, ref end));

        return new string(buffer[..((int)Unsafe.ByteOffset(ref start, ref b) >> 1)]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Underscore(ReadOnlySpan<char> word) => Underscore(word, false);

    [SkipLocalsInit]
    public static unsafe string Underscore(ReadOnlySpan<char> word, bool toUpper)
    {
        if (word.IsEmpty)
        {
            return string.Empty;
        }

        var length = word.Length;
        var bufferSize = length << 1;
        var buffer = bufferSize < 512 ? stackalloc char[bufferSize] : new char[bufferSize];

        ref var start = ref MemoryMarshal.GetReference(buffer);
        ref var b = ref start;

        ref var c = ref MemoryMarshal.GetReference(word);
        ref var end = ref Unsafe.Add(ref c, length);

        if (toUpper)
        {
            if (Char.IsUpper(c))
            {
                b = c;
                b = ref Unsafe.Add(ref b, 1);
            }
            else
            {
                b = Char.ToUpperInvariant(c);
                b = ref Unsafe.Add(ref b, 1);
            }

            c = ref Unsafe.Add(ref c, 1);

            while (Unsafe.IsAddressLessThan(ref c, ref end))
            {
                if (Char.IsUpper(c))
                {
                    b = '_';
                    b = ref Unsafe.Add(ref b, 1);
                    b = c;
                    b = ref Unsafe.Add(ref b, 1);
                }
                else
                {
                    b = Char.ToUpperInvariant(c);
                    b = ref Unsafe.Add(ref b, 1);
                }

                c = ref Unsafe.Add(ref c, 1);
            }
        }
        else
        {
            if (Char.IsUpper(c))
            {
                b = Char.ToLowerInvariant(c);
                b = ref Unsafe.Add(ref b, 1);
            }
            else
            {
                b = c;
                b = ref Unsafe.Add(ref b, 1);
            }

            c = ref Unsafe.Add(ref c, 1);

            while (Unsafe.IsAddressLessThan(ref c, ref end))
            {
                if (Char.IsUpper(c))
                {
                    b = '_';
                    b = ref Unsafe.Add(ref b, 1);
                    b = Char.ToLowerInvariant(c);
                    b = ref Unsafe.Add(ref b, 1);
                }
                else
                {
                    b = c;
                    b = ref Unsafe.Add(ref b, 1);
                }

                c = ref Unsafe.Add(ref c, 1);
            }
        }

        return new string(buffer[..((int)Unsafe.ByteOffset(ref start, ref b) >> 1)]);
    }
}
