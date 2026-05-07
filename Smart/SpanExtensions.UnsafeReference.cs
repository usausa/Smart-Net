namespace Smart;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static partial class SpanExtensions
{
    //--------------------------------------------------------------------------------
    // Unsafe reference : Remove boundary check with Unsafe.Add
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetUnsafeReference<T>(this Span<T> span) => ref MemoryMarshal.GetReference(span);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetUnsafeReference<T>(this ReadOnlySpan<T> span) => ref Unsafe.AsRef(in MemoryMarshal.GetReference(span));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetUnsafeReference<T>(this T[] array) => ref MemoryMarshal.GetArrayDataReference(array);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetUnsafeReferenceAt<T>(this Span<T> span, int index) => ref Unsafe.Add(ref MemoryMarshal.GetReference(span), index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetUnsafeReferenceAt<T>(this ReadOnlySpan<T> span, int index) => ref Unsafe.Add(ref Unsafe.AsRef(in MemoryMarshal.GetReference(span)), index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetUnsafeReferenceAt<T>(this T[] array, int index) => ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), index);
}
