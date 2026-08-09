namespace Smart.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class SpanReaderExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TValue ReadUnmanaged<TValue>(this ref SpanReader<byte> reader)
        where TValue : unmanaged
    {
        var span = reader.Read(Unsafe.SizeOf<TValue>());
        return Unsafe.ReadUnaligned<TValue>(ref MemoryMarshal.GetReference(span));
    }
}
