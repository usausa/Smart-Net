namespace Smart.Text;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class HexEncoder
{
    private static ReadOnlySpan<byte> HexTable => "0123456789ABCDEF"u8;

#if NET5_0_OR_GREATER
    [SkipLocalsInit]
#endif
    public static unsafe string Encode(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var length = source.Length << 1;
        var span = length < 512 ? stackalloc char[length] : new char[length];
        ref var buffer = ref MemoryMarshal.GetReference(span);

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        do
        {
            var b = sr;
            buffer = (char)Unsafe.Add(ref hex, b >> 4);
            buffer = ref Unsafe.Add(ref buffer, 1);
            buffer = (char)Unsafe.Add(ref hex, b & 0xF);
            buffer = ref Unsafe.Add(ref buffer, 1);
            sr = ref Unsafe.Add(ref sr, 1);
        }
        while (Unsafe.IsAddressLessThan(ref sr, ref end));

        return new string(span);
    }

    public static int Encode(ReadOnlySpan<byte> source, Span<char> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length << 1;
        if (length > destination.Length)
        {
            return -1;
        }

        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        ref var buffer = ref MemoryMarshal.GetReference(destination);

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        do
        {
            var b = sr;
            buffer = (char)Unsafe.Add(ref hex, b >> 4);
            buffer = ref Unsafe.Add(ref buffer, 1);
            buffer = (char)Unsafe.Add(ref hex, b & 0xF);
            buffer = ref Unsafe.Add(ref buffer, 1);
            sr = ref Unsafe.Add(ref sr, 1);
        }
        while (Unsafe.IsAddressLessThan(ref sr, ref end));

        return length;
    }

#if NET5_0_OR_GREATER
    [SkipLocalsInit]
#endif
    public static byte[] Decode(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return Array.Empty<byte>();
        }

        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var buffer = new byte[source.Length >> 1];
        ref var dr = ref MemoryMarshal.GetReference(buffer.AsSpan());

        do
        {
            var b = CharToNumber(sr) << 4;
            sr = ref Unsafe.Add(ref sr, 1);
            dr = (byte)(b + CharToNumber(sr));
            dr = ref Unsafe.Add(ref dr, 1);
            sr = ref Unsafe.Add(ref sr, 1);
        }
        while (Unsafe.IsAddressLessThan(ref sr, ref end));

        return buffer;
    }

    public static int Decode(ReadOnlySpan<char> source, Span<byte> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length >> 1;
        if (length > destination.Length)
        {
            return -1;
        }

        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        ref var dr = ref MemoryMarshal.GetReference(destination);

        do
        {
            var b = CharToNumber(sr) << 4;
            sr = ref Unsafe.Add(ref sr, 1);
            dr = (byte)(b + CharToNumber(sr));
            dr = ref Unsafe.Add(ref dr, 1);
            sr = ref Unsafe.Add(ref sr, 1);
        }
        while (Unsafe.IsAddressLessThan(ref sr, ref end));

        return length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int CharToNumber(char c)
    {
        if ((c <= '9') && (c >= '0'))
        {
            return c - '0';
        }

        if ((c <= 'F') && (c >= 'A'))
        {
            return c - 'A' + 10;
        }

        if ((c <= 'f') && (c >= 'a'))
        {
            return c - 'a' + 10;
        }

        return 0;
    }
}
