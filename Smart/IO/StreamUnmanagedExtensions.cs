namespace Smart.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class StreamUnmanagedExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<T>(this Stream stream, T value)
        where T : unmanaged
    {
        Span<byte> buffer = stackalloc byte[Unsafe.SizeOf<T>()];
        Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(buffer), value);
        stream.Write(buffer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Read<T>(this Stream stream)
        where T : unmanaged
    {
        Span<byte> buffer = stackalloc byte[Unsafe.SizeOf<T>()];
        stream.ReadExactly(buffer);
        return Unsafe.ReadUnaligned<T>(ref MemoryMarshal.GetReference(buffer));
    }

    public static ValueTask WriteAsync<T>(this Stream stream, T value, CancellationToken cancellationToken = default)
        where T : unmanaged
    {
        var size = Unsafe.SizeOf<T>();
        var buffer = new byte[size];
        Unsafe.WriteUnaligned(ref buffer[0], value);
        return stream.WriteAsync(buffer.AsMemory(), cancellationToken);
    }

    public static async ValueTask<T> ReadAsync<T>(this Stream stream, CancellationToken cancellationToken = default)
        where T : unmanaged
    {
        var size = Unsafe.SizeOf<T>();
        var buffer = new byte[size];
        await stream.ReadExactlyAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false);
        return Unsafe.ReadUnaligned<T>(ref buffer[0]);
    }
}
