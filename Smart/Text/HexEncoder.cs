namespace Smart.Text;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class HexEncoder
{
    private static ReadOnlySpan<byte> HexTable => new[]
    {
        (byte)'0', (byte)'1', (byte)'2', (byte)'3',
        (byte)'4', (byte)'5', (byte)'6', (byte)'7',
        (byte)'8', (byte)'9', (byte)'A', (byte)'B',
        (byte)'C', (byte)'D', (byte)'E', (byte)'F'
    };

#if NET5_0_OR_GREATER
    [SkipLocalsInit]
#endif
    public static unsafe string Encode(ReadOnlySpan<byte> bytes)
    {
        if (bytes.IsEmpty)
        {
            return string.Empty;
        }

        var length = bytes.Length * 2;
        var span = length < 512 ? stackalloc char[length] : new char[length];
        ref var buffer = ref MemoryMarshal.GetReference(span);
        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < bytes.Length; i++)
        {
            var b = bytes[i];
            buffer = (char)Unsafe.Add(ref hex, b >> 4);
            buffer = ref Unsafe.Add(ref buffer, 1);
            buffer = (char)Unsafe.Add(ref hex, b & 0xF);
            buffer = ref Unsafe.Add(ref buffer, 1);
        }

        return new string(span);
    }

    public static int Encode(ReadOnlySpan<byte> bytes, Span<char> destination)
    {
        if (bytes.IsEmpty)
        {
            return 0;
        }

        var length = bytes.Length * 2;
        ref var buffer = ref MemoryMarshal.GetReference(destination);
        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < bytes.Length; i++)
        {
            var b = bytes[i];
            buffer = (char)Unsafe.Add(ref hex, b >> 4);
            buffer = ref Unsafe.Add(ref buffer, 1);
            buffer = (char)Unsafe.Add(ref hex, b & 0xF);
            buffer = ref Unsafe.Add(ref buffer, 1);
        }

        return length;
    }

#if NET5_0_OR_GREATER
    [SkipLocalsInit]
#endif
    public static unsafe byte[] Decode(ReadOnlySpan<char> code)
    {
        if (code.IsEmpty)
        {
            return Array.Empty<byte>();
        }

        // TODO
        var buffer = new byte[code.Length >> 1];

        fixed (char* pCode = code)
        fixed (byte* pBuffer = &buffer[0])
        {
            var pb = pBuffer;
            var pc = pCode;
            for (var i = 0; i < buffer.Length; i++)
            {
                var b = CharToNumber(*pc) << 4;
                pc++;
                *pb = (byte)(b + CharToNumber(*pc));
                pc++;
                pb++;
            }
        }

        return buffer;
    }

    public static unsafe int Decode(ReadOnlySpan<char> code, Span<byte> destination)
    {
        if (code.IsEmpty)
        {
            return 0;
        }

        // TODO
        var length = code.Length >> 1;

        fixed (char* pCode = code)
        fixed (byte* pBuffer = destination)
        {
            var pb = pBuffer;
            var pc = pCode;
            for (var i = 0; i < length; i++)
            {
                var b = CharToNumber(*pc) << 4;
                pc++;
                *pb = (byte)(b + CharToNumber(*pc));
                pc++;
                pb++;
            }
        }

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
