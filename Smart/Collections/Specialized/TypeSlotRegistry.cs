namespace Smart.Collections.Specialized;

using System.Runtime.CompilerServices;

public static class TypeSlotRegistry
{
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, int> Slots = new();

    private static int nextIndex;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Get(Type type) => Slots.GetOrAdd(type, _ => Interlocked.Increment(ref nextIndex) - 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int AllocateNext() => Interlocked.Increment(ref nextIndex) - 1;
}
