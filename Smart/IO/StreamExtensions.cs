namespace Smart.IO
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public static class StreamExtensions
    {
        public static byte[] ReadAllBytes(this Stream stream)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }

        public static byte[] ReadAllBytes(this Stream stream, int bufferSize)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            using var ms = new MemoryStream();
            stream.CopyTo(ms, bufferSize);
            return ms.ToArray();
        }

        public static async ValueTask<byte[]> ReadAllBytesAsync(this Stream stream)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            await using var ms = new MemoryStream();
            await stream.CopyToAsync(ms).ConfigureAwait(false);
            return ms.ToArray();
        }

        public static async ValueTask<byte[]> ReadAllBytesAsync(this Stream stream, CancellationToken cancel)
        {
            if (stream is MemoryStream memoryStream)
            {
                return memoryStream.ToArray();
            }

            await using var ms = new MemoryStream();
            await stream.CopyToAsync(ms, cancel).ConfigureAwait(false);
            return ms.ToArray();
        }

        public static byte[]? ReadBytes(this Stream stream, int size)
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

        public static async ValueTask<byte[]?> ReadBytesAsync(this Stream stream, int size)
        {
            var buffer = new byte[size];
            var offset = 0;
            while (offset < size)
            {
                var read = await stream.ReadAsync(buffer.AsMemory(offset, size - offset)).ConfigureAwait(false);
                if (read == 0)
                {
                    return null;
                }

                offset += read;
            }

            return buffer;
        }

        public static async ValueTask<byte[]?> ReadBytesAsync(this Stream stream, int size, CancellationToken cancel)
        {
            var buffer = new byte[size];
            var offset = 0;
            while (offset < size)
            {
                var read = await stream.ReadAsync(buffer.AsMemory(offset, size - offset), cancel).ConfigureAwait(false);
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
