namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///
    /// </summary>
    public static class Bytes
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Ignore")]
        public static byte[] Empty { get; } = new byte[0];

        /// <summary>
        ///
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="src"></param>
        /// <param name="srcOffset"></param>
        /// <param name="dst"></param>
        /// <param name="dstOffset"></param>
        /// <param name="length"></param>
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
