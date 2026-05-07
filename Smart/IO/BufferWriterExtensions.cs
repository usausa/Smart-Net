namespace Smart.IO;

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class BufferWriterExtensions
{
    //--------------------------------------------------------------------------------
    // Unmanaged
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<T>(this IBufferWriter<byte> writer, T value)
        where T : unmanaged
    {
        var size = Unsafe.SizeOf<T>();
        var span = writer.GetSpan(size);
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(span), value);
        writer.Advance(size);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(this IBufferWriter<byte> writer, ReadOnlySpan<byte> source)
    {
        var span = writer.GetSpan(source.Length);
        source.CopyTo(span);
        writer.Advance(source.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(this IBufferWriter<byte> writer, ReadOnlyMemory<byte> source) =>
        writer.Write(source.Span);

    //--------------------------------------------------------------------------------
    // Generic
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteElement<T>(this IBufferWriter<T> writer, T value)
    {
        var span = writer.GetSpan(1);
        span[0] = value;
        writer.Advance(1);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteElements<T>(this IBufferWriter<T> writer, ReadOnlySpan<T> source)
    {
        var span = writer.GetSpan(source.Length);
        source.CopyTo(span);
        writer.Advance(source.Length);
    }
}
