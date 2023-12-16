namespace Smart;

using System.Buffers;
using System.Runtime.CompilerServices;

public static class ArrayPoolExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] RentWithClear<T>(this ArrayPool<T> pool, int length)
    {
        var buffer = pool.Rent(length);
        buffer.AsSpan().Clear();
        return buffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReturnIfNotNull<T>(this ArrayPool<T> pool, T[]? buffer)
    {
        if (buffer is not null)
        {
            pool.Return(buffer);
        }
    }
}
