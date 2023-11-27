namespace Smart;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:DoNotExposeGenericLists", Justification = "Ignore")]
public static partial class BinarySearch
{
    //--------------------------------------------------------------------------------
    // Func version
    //--------------------------------------------------------------------------------

    // List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(List<T> list, Func<T, int> comparer) =>
        Find(CollectionsMarshal.AsSpan(list), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(List<T> list, int start, int length, Func<T, int> comparer) =>
        Find(CollectionsMarshal.AsSpan(list).Slice(start, length), comparer);

    // Array

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(T[] array, Func<T, int> comparer) =>
        Find(array.AsSpan(), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(T[] array, int start, int length, Func<T, int> comparer) =>
        Find(array.AsSpan(start, length), comparer);

    // Span

    public static int Find<T>(Span<T> span, Func<T, int> comparer)
    {
        var lo = 0;
        var hi = span.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + ((hi - lo) >> 1);

            var c = comparer(span[mid]);

            if (c == 0)
            {
                return mid;
            }

            if (c < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return ~lo;
    }

    // List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(List<T> list, Func<T, int> comparer) =>
        FindFirst(CollectionsMarshal.AsSpan(list), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(List<T> list, int start, int length, Func<T, int> comparer) =>
        FindFirst(CollectionsMarshal.AsSpan(list).Slice(start, length), comparer);

    // Array

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(T[] array, Func<T, int> comparer) =>
        FindFirst(array.AsSpan(), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(T[] array, int start, int length, Func<T, int> comparer) =>
        FindFirst(array.AsSpan(start, length), comparer);

    // Span

    public static int FindFirst<T>(Span<T> span, Func<T, int> comparer)
    {
        var find = -1;
        var lo = 0;
        var hi = span.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + ((hi - lo) >> 1);

            var c = comparer(span[mid]);

            if (c == 0)
            {
                find = mid;
                hi = mid - 1;
            }
            else if (c < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return find >= 0 ? find : ~lo;
    }

    // List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(List<T> list, Func<T, int> comparer) =>
        FindLast(CollectionsMarshal.AsSpan(list), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(List<T> list, int start, int length, Func<T, int> comparer) =>
        FindLast(CollectionsMarshal.AsSpan(list).Slice(start, length), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(T[] array, Func<T, int> comparer) =>
        FindLast(array.AsSpan(), comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(T[] array, int start, int length, Func<T, int> comparer) =>
        FindLast(array.AsSpan(start, length), comparer);

    public static int FindLast<T>(Span<T> span, Func<T, int> comparer)
    {
        var find = -1;
        var lo = 0;
        var hi = span.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + ((hi - lo) >> 1);

            var c = comparer(span[mid]);

            if (c == 0)
            {
                find = mid;
                lo = mid + 1;
            }
            else if (c < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return find >= 0 ? find : ~lo;
    }

    //--------------------------------------------------------------------------------
    // IComparer version Find
    //--------------------------------------------------------------------------------

    // List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(List<T> list, T key) =>
        Find(CollectionsMarshal.AsSpan(list), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(List<T> list, T key, IComparer<T> comparer) =>
        Find(CollectionsMarshal.AsSpan(list), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(List<T> list, TKey? key, Func<T, TKey?> selector) =>
        Find(CollectionsMarshal.AsSpan(list), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(List<T> list, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        Find(CollectionsMarshal.AsSpan(list), key, selector, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(List<T> list, int start, int length, T key) =>
        Find(CollectionsMarshal.AsSpan(list).Slice(start, length), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(List<T> list, int start, int length, T key, IComparer<T> comparer) =>
        Find(CollectionsMarshal.AsSpan(list).Slice(start, length), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(List<T> list, int start, int length, TKey? key, Func<T, TKey?> selector) =>
        Find(CollectionsMarshal.AsSpan(list).Slice(start, length), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(List<T> list, int start, int length, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        Find(CollectionsMarshal.AsSpan(list).Slice(start, length), key, selector, comparer);

    // Array

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(T[] array, T key) =>
        Find(array.AsSpan(), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(T[] array, T key, IComparer<T> comparer) =>
        Find(array.AsSpan(), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(T[] array, TKey? key, Func<T, TKey?> selector) =>
        Find(array.AsSpan(), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(T[] array, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        Find(array.AsSpan(), key, selector, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(T[] array, int start, int length, T key) =>
        Find(array.AsSpan(start, length), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(T[] array, int start, int length, T key, IComparer<T> comparer) =>
        Find(array.AsSpan(start, length), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(T[] array, int start, int length, TKey? key, Func<T, TKey?> selector) =>
        Find(array.AsSpan(start, length), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(T[] array, int start, int length, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        Find(array.AsSpan(start, length), key, selector, comparer);

    // Span

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(Span<T> span, T key) =>
        Find(span, key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T>(Span<T> span, T key, IComparer<T> comparer) =>
        Find(span, key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Find<T, TKey>(Span<T> span, TKey? key, Func<T, TKey?> selector) =>
        Find(span, key, selector, Comparer<TKey>.Default);

    public static int Find<T, TKey>(Span<T> span, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer)
    {
        var lo = 0;
        var hi = span.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + ((hi - lo) >> 1);
            var c = comparer.Compare(selector(span[mid]), key);

            if (c == 0)
            {
                return mid;
            }

            if (c < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return ~lo;
    }

    //--------------------------------------------------------------------------------
    // IComparer version FindFirst
    //--------------------------------------------------------------------------------

    // List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(List<T> list, T key) =>
        FindFirst(CollectionsMarshal.AsSpan(list), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(List<T> list, T key, IComparer<T> comparer) =>
        FindFirst(CollectionsMarshal.AsSpan(list), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(List<T> list, TKey? key, Func<T, TKey?> selector) =>
        FindFirst(CollectionsMarshal.AsSpan(list), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(List<T> list, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindFirst(CollectionsMarshal.AsSpan(list), key, selector, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(List<T> list, int start, int length, T key) =>
        FindFirst(CollectionsMarshal.AsSpan(list).Slice(start, length), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(List<T> list, int start, int length, T key, IComparer<T> comparer) =>
        FindFirst(CollectionsMarshal.AsSpan(list).Slice(start, length), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(List<T> list, int start, int length, TKey? key, Func<T, TKey?> selector) =>
        FindFirst(CollectionsMarshal.AsSpan(list).Slice(start, length), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(List<T> list, int start, int length, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindFirst(CollectionsMarshal.AsSpan(list).Slice(start, length), key, selector, comparer);

    // Array

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(T[] array, T key) =>
        FindFirst(array.AsSpan(), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(T[] array, T key, IComparer<T> comparer) =>
        FindFirst(array.AsSpan(), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(T[] array, TKey? key, Func<T, TKey?> selector) =>
        FindFirst(array.AsSpan(), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(T[] array, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindFirst(array.AsSpan(), key, selector, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(T[] array, int start, int length, T key) =>
        FindFirst(array.AsSpan(start, length), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(T[] array, int start, int length, T key, IComparer<T> comparer) =>
        FindFirst(array.AsSpan(start, length), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(T[] array, int start, int length, TKey? key, Func<T, TKey?> selector) =>
        FindFirst(array.AsSpan(start, length), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(T[] array, int start, int length, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindFirst(array.AsSpan(start, length), key, selector, comparer);

    // Span

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(Span<T> span, T key) =>
        FindFirst(span, key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T>(Span<T> span, T key, IComparer<T> comparer) =>
        FindFirst(span, key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindFirst<T, TKey>(Span<T> span, TKey? key, Func<T, TKey?> selector) =>
        FindFirst(span, key, selector, Comparer<TKey>.Default);

    public static int FindFirst<T, TKey>(Span<T> span, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer)
    {
        var find = -1;
        var lo = 0;
        var hi = span.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + ((hi - lo) >> 1);
            var c = comparer.Compare(selector(span[mid]), key);

            if (c == 0)
            {
                find = mid;
                hi = mid - 1;
            }
            else if (c < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return find >= 0 ? find : ~lo;
    }

    //--------------------------------------------------------------------------------
    // IComparer version FindLast
    //--------------------------------------------------------------------------------

    // List

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(List<T> list, T key) =>
        FindLast(CollectionsMarshal.AsSpan(list), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(List<T> list, T key, IComparer<T> comparer) =>
        FindLast(CollectionsMarshal.AsSpan(list), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(List<T> list, TKey? key, Func<T, TKey?> selector) =>
        FindLast(CollectionsMarshal.AsSpan(list), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(List<T> list, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindLast(CollectionsMarshal.AsSpan(list), key, selector, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(List<T> list, int start, int length, T key) =>
        FindLast(CollectionsMarshal.AsSpan(list).Slice(start, length), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(List<T> list, int start, int length, T key, IComparer<T> comparer) =>
        FindLast(CollectionsMarshal.AsSpan(list).Slice(start, length), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(List<T> list, int start, int length, TKey? key, Func<T, TKey?> selector) =>
        FindLast(CollectionsMarshal.AsSpan(list).Slice(start, length), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(List<T> list, int start, int length, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindLast(CollectionsMarshal.AsSpan(list).Slice(start, length), key, selector, comparer);

    // Array

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(T[] array, T key) =>
        FindLast(array.AsSpan(), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(T[] array, T key, IComparer<T> comparer) =>
        FindLast(array.AsSpan(), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(T[] array, TKey? key, Func<T, TKey?> selector) =>
        FindLast(array.AsSpan(), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(T[] array, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindLast(array.AsSpan(), key, selector, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(T[] array, int start, int length, T key) =>
        FindLast(array.AsSpan(start, length), key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(T[] array, int start, int length, T key, IComparer<T> comparer) =>
        FindLast(array.AsSpan(start, length), key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(T[] array, int start, int length, TKey? key, Func<T, TKey?> selector) =>
        FindLast(array.AsSpan(start, length), key, selector, Comparer<TKey>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(T[] array, int start, int length, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer) =>
        FindLast(array.AsSpan(start, length), key, selector, comparer);

    // SPan

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(Span<T> span, T key) =>
        FindLast(span, key, Functions<T>.Identify, Comparer<T>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T>(Span<T> span, T key, IComparer<T> comparer) =>
        FindLast(span, key, Functions<T>.Identify, comparer);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FindLast<T, TKey>(Span<T> span, TKey? key, Func<T, TKey?> selector) =>
        FindLast(span, key, selector, Comparer<TKey>.Default);

    public static int FindLast<T, TKey>(Span<T> span, TKey? key, Func<T, TKey?> selector, IComparer<TKey> comparer)
    {
        var find = -1;
        var lo = 0;
        var hi = span.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + ((hi - lo) >> 1);
            var c = comparer.Compare(selector(span[mid]), key);

            if (c == 0)
            {
                find = mid;
                lo = mid + 1;
            }
            else if (c < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return find >= 0 ? find : ~lo;
    }
}
