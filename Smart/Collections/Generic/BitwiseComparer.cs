namespace Smart.Collections.Generic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public sealed class BitwiseComparer<T> : IEqualityComparer<T>, IComparer<T>
    where T : unmanaged
{
    /// <summary>Gets the singleton instance.</summary>
    public static readonly BitwiseComparer<T> Instance = new();

    private BitwiseComparer()
    {
    }

    //--------------------------------------------------------------------------------
    // Static helper
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsStatic(in T x, in T y) => MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in x, 1))
            .SequenceEqual(MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in y, 1)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CompareStatic(in T x, in T y) =>
        MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in x, 1)).SequenceCompareTo(MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in y, 1)));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetHashCodeStatic(in T value)
    {
        var bytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in value, 1));
        var hash = new HashCode();
        hash.AddBytes(bytes);
        return hash.ToHashCode();
    }

    //--------------------------------------------------------------------------------
    // IEqualityComparer<T>
    //--------------------------------------------------------------------------------

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(T x, T y) => EqualsStatic(in x, in y);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetHashCode(T obj) => GetHashCodeStatic(in obj);

    //--------------------------------------------------------------------------------
    // IComparer<T>
    //--------------------------------------------------------------------------------

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Compare(T x, T y) => CompareStatic(in x, in y);
}
