namespace Smart.IO
{
    using System.IO;

    public static class StreamExtensions
    {
        public static byte[] ReadAllBytes(this Stream stream)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

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
