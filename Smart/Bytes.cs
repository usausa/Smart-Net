namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static class Bytes
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2105:ArrayFieldsShouldNotBeReadOnly", Justification = "Ignore")]
        public static readonly byte[] Empty = new byte[0];

        /// <summary>
        ///
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static byte[] FromHex(string hex)
        {
            var bytes = new byte[hex.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
    }
}
