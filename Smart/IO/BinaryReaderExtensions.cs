namespace Smart.IO
{
    using System.IO;
    using System.Runtime.InteropServices;

    public static class BinaryReaderExtensions
    {
        public static T ReadStruct<T>(this BinaryReader reader)
            where T : struct
        {
            var type = typeof(T);

            var bytes = new byte[Marshal.SizeOf(type)];
            reader.Read(bytes, 0, bytes.Length);

            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), type);
            }
            finally
            {
                handle.Free();
            }
        }
    }
}
