namespace Smart.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class SpanWriterExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUnmanaged<TValue>(this ref SpanWriter<byte> writer, TValue value)
        where TValue : unmanaged
    {
        var span = writer.Slide(Unsafe.SizeOf<TValue>());
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
    }
}
