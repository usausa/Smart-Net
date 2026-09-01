namespace Smart.IO;

using System.Buffers;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0032
public sealed class MemoryOwner<T> : IMemoryOwner<T>
{
    private readonly int length;

    private T[]? array;

    public int Length => length;

    public Memory<T> Memory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ObjectDisposedException.ThrowIf(array is null, this);
            return array.AsMemory(0, length);
        }
    }

    public Span<T> Span
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            ObjectDisposedException.ThrowIf(array is null, this);
            return array.AsSpan(0, length);
        }
    }

    private MemoryOwner(T[] array, int length)
    {
        this.array = array;
        this.length = length;
    }

    public void Dispose()
    {
        var toReturn = array;
        array = null;
        if (toReturn is not null)
        {
            ArrayPool<T>.Shared.Return(toReturn, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
        }
    }

    //--------------------------------------------------------------------------------
    // Factory
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MemoryOwner<T> Allocate(int length, bool clear = false)
    {
        var array = ArrayPool<T>.Shared.Rent(length);
        var owner = new MemoryOwner<T>(array, length);
        if (clear)
        {
            owner.Span.Clear();
        }

        return owner;
    }
}
#pragma warning restore IDE0032
