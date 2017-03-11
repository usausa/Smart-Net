namespace Smart.IO
{
    using System.IO;
    using System.Runtime.InteropServices;

    /// <summary>
    ///
    /// </summary>
    public static class BinaryReaderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static T ReadStruct<T>(this BinaryReader reader)
            where T : struct
        {
            var bytes = new byte[Marshal.SizeOf<T>()];
            reader.Read(bytes, 0, bytes.Length);

            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }
    }
}
