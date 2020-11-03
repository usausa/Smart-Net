namespace Smart.Text
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class HexEncoder
    {
        // TODO Separator
        // TODO (LineSeparator?)

        // TODO Decode with separator

        // TODO Span to Span * 2

        [Obsolete("Use Encode")]
        public static string ToHex(byte[] bytes, int start, int length, string prefix, string separator, int lineSize, string lineSeparator)
        {
            var addPrefix = !String.IsNullOrEmpty(prefix);
            var addSeparator = !String.IsNullOrEmpty(separator);

            var bufferSize = length * 2;
            var lines = lineSize > 0 ? (length - 1) / lineSize : 0;
            if (lineSize > 0)
            {
                bufferSize += lines * lineSeparator.Length;
            }

            if (addPrefix)
            {
                bufferSize += prefix.Length * length;
            }

            if (addSeparator)
            {
                bufferSize += (length - lines - 1) * separator.Length;
            }

            var sb = new StringBuilder(bufferSize);
            var count = 0;
            for (var i = start; i < start + length; i++)
            {
                if (count != 0)
                {
                    if (count == lineSize)
                    {
                        sb.Append(lineSeparator);
                        count = 0;
                    }
                    else if (addSeparator)
                    {
                        sb.Append(separator);
                    }
                }

                if (addPrefix)
                {
                    sb.Append(prefix);
                }

                var b = bytes[i];
                sb.Append(ToHex(b >> 4));
                sb.Append(ToHex(b & 0x0F));
                count++;
            }

            return sb.ToString();
        }

        private static char ToHex(int x)
        {
            return x < 10 ? (char)(x + '0') : (char)(x + 'A' - 10);
        }

        //--------------------------------------------------------------------------------

        private static ReadOnlySpan<byte> HexTable => new[]
        {
            (byte)'0', (byte)'1', (byte)'2', (byte)'3',
            (byte)'4', (byte)'5', (byte)'6', (byte)'7',
            (byte)'8', (byte)'9', (byte)'A', (byte)'B',
            (byte)'C', (byte)'D', (byte)'E', (byte)'F'
        };

        public static unsafe string Encode(ReadOnlySpan<byte> bytes)
        {
            var length = bytes.Length * 2;
            var temp = length < 2048 ? stackalloc char[length] : new char[length];
            ref var hex = ref MemoryMarshal.GetReference(HexTable);

            fixed (char* ptr = temp)
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

                return new string(ptr, 0, length);
            }
        }

        public static unsafe byte[] Decode(ReadOnlySpan<char> code)
        {
            var bytes = new byte[code.Length / 2];

            fixed (byte* pBytes = &bytes[0])
            fixed (char* pCode = code)
            {
                var pb = pBytes;
                var pc = pCode;
                for (var i = 0; i < bytes.Length; i++)
                {
                    var b = CharToNumber(*pc) << 4;
                    pc++;
                    *pb = (byte)(b + CharToNumber(*pc));
                    pc++;
                    pb++;
                }
            }

            return bytes;
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

            if ((c <= 'F') && (c >= 'a'))
            {
                return c - 'a' + 10;
            }

            return 0;
        }
    }
}
