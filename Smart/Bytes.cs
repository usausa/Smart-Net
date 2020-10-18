namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class Bytes
    {
        public static byte[] FromHex(string hex)
        {
            if (hex is null)
            {
                throw new ArgumentNullException(nameof(hex));
            }

            var bytes = new byte[hex.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        [Obsolete]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void FastCopy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int length)
        {
            if (length > 0)
            {
                fixed (byte* pSource = &src[srcOffset])
                fixed (byte* pDestination = &dst[dstOffset])
                {
                    Buffer.MemoryCopy(pSource, pDestination, length, length);
                }
            }
        }
    }
}
