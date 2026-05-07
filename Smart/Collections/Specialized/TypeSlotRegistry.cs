namespace Smart.Collections.Specialized;

using System.Runtime.CompilerServices;

internal static class TypeSlotRegistry
{
    internal static int NextIndex;

    internal static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, int> Slots = new();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int Get(Type type) => Slots.GetOrAdd(type, _ => Interlocked.Increment(ref NextIndex) - 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int AllocateNext() => Interlocked.Increment(ref NextIndex) - 1;
}

internal static class TypeSlot<T>
{
    internal static readonly int Index;

    static TypeSlot()
    {
        Index = TypeSlotRegistry.Slots.GetOrAdd(typeof(T), _ => TypeSlotRegistry.AllocateNext());
    }
}
