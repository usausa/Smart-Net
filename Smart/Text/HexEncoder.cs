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

        var length = bytes.Length << 1;
        var buffer = length < 2048 ? stackalloc char[length] : new char[length];
        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (char* pBuffer = buffer)
        {
            var p = pBuffer;
            for (var i = 0; i < bytes.Length; i++)
            {
                var b = bytes[i];
                *p = (char)Unsafe.Add(ref hex, b >> 4);
                p++;
                *p = (char)Unsafe.Add(ref hex, b & 0xF);
                p++;
            }

            return new string(pBuffer, 0, length);
        }
    }

    public static unsafe int Encode(ReadOnlySpan<byte> bytes, Span<char> buffer)
    {
        if (bytes.IsEmpty)
        {
            return 0;
        }

        var length = bytes.Length << 1;
        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (char* ptr = buffer)
        {
            var p = ptr;
            for (var i = 0; i < bytes.Length; i++)
            {
                var b = bytes[i];
                *p = (char)Unsafe.Add(ref hex, b >> 4);
                p++;
                *p = (char)Unsafe.Add(ref hex, b & 0xF);
                p++;
            }
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

    public static unsafe int Decode(ReadOnlySpan<char> code, Span<byte> buffer)
    {
        if (code.IsEmpty)
        {
            return 0;
        }

        var length = code.Length >> 1;

        fixed (char* pCode = code)
        fixed (byte* pBuffer = buffer)
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
