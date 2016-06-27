namespace Smart.IO
{
    using System.IO;

    /// <summary>
    ///
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static byte[] ReadAllBytes(this Stream stream)
        {
            var memoryStream = stream as MemoryStream;
            if (memoryStream != null)
            {
                return memoryStream.ToArray();
            }

            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static byte[] ReadBytes(this Stream stream, int size)
        {
            var buffer = new byte[size];
            var offset = 0;
            while (offset < size)
            {
                var read = stream.Read(buffer, offset, size - offset);
                if (read == 0)
                {
                    return null;
                }

                offset += read;
            }

            return buffer;
        }
    }
}
