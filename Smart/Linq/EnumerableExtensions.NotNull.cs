namespace Smart.Linq;

using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

public static partial class EnumerableExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> SelectNotNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult?> selector)
        where TResult : class =>
        (IEnumerable<TResult>)source.Select(selector).Where(static x => x is not null);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> SelectNotNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult?> selector)
        where TResult : struct
    {
        if (source is List<TSource> list)
        {
            return new SelectNotNullListIterator<TSource, TResult>(list, selector);
        }

        if (source is TSource[] array)
        {
            return new SelectNotNullArrayIterator<TSource, TResult>(array, selector);
        }

        return SelectNotNullIterator(source, selector);
    }

    private static IEnumerable<TResult> SelectNotNullIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult?> selector)
        where TResult : struct
    {
        foreach (var item in source)
        {
            var value = selector(item);
            if (value.HasValue)
            {
                yield return value.GetValueOrDefault();
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> WhereNotNull<TResult>(this IEnumerable<TResult?> source)
        where TResult : class =>
        (IEnumerable<TResult>)source.Where(static x => x is not null);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TResult> WhereNotNull<TResult>(this IEnumerable<TResult?> source)
        where TResult : struct
    {
        if (source is List<TResult?> list)
        {
            return new WhereNotNullListIterator<TResult>(list);
        }

        if (source is TResult?[] array)
        {
            return new WhereNotNullArrayIterator<TResult>(array);
        }

        return WhereNotNullIterator(source);
    }

    private static IEnumerable<TResult> WhereNotNullIterator<TResult>(IEnumerable<TResult?> source)
        where TResult : struct
    {
        foreach (var value in source)
        {
            if (value.HasValue)
            {
                yield return value.GetValueOrDefault();
            }
        }
    }

    //--------------------------------------------------------------------------------
    // Iterator
    //--------------------------------------------------------------------------------

    private sealed class SelectNotNullListIterator<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
        where TResult : struct
    {
        private readonly List<TSource> source;

        private readonly Func<TSource, TResult?> selector;

        private readonly int threadId;

        private int state;

        private List<TSource>.Enumerator enumerator;

        public SelectNotNullListIterator(List<TSource> source, Func<TSource, TResult?> selector)
        {
            this.source = source;
            this.selector = selector;
            threadId = Environment.CurrentManagedThreadId;
        }

        public TResult Current { get; private set; }

        object IEnumerator.Current => Current;

        public IEnumerator<TResult> GetEnumerator()
        {
            if ((state == 0) && (threadId == Environment.CurrentManagedThreadId))
            {
                state = 1;
                enumerator = source.GetEnumerator();
                return this;
            }

            return new SelectNotNullListIterator<TSource, TResult>(source, selector) { state = 1, enumerator = source.GetEnumerator() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool MoveNext()
        {
            while (enumerator.MoveNext())
            {
                var value = selector(enumerator.Current);
                if (value.HasValue)
                {
                    Current = value.GetValueOrDefault();
                    return true;
                }
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();

        public void Dispose() => enumerator.Dispose();
    }

    private sealed class SelectNotNullArrayIterator<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
        where TResult : struct
    {
        private readonly TSource[] source;

        private readonly Func<TSource, TResult?> selector;

        private readonly int threadId;

        private int state;

        private int index;

        public SelectNotNullArrayIterator(TSource[] source, Func<TSource, TResult?> selector)
        {
            this.source = source;
            this.selector = selector;
            threadId = Environment.CurrentManagedThreadId;
        }

        public TResult Current { get; private set; }

        object IEnumerator.Current => Current;

        public IEnumerator<TResult> GetEnumerator()
        {
            if ((state == 0) && (threadId == Environment.CurrentManagedThreadId))
            {
                state = 1;
                return this;
            }

            return new SelectNotNullArrayIterator<TSource, TResult>(source, selector) { state = 1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool MoveNext()
        {
            var array = source;
            for (var i = index; (uint)i < (uint)array.Length; i++)
            {
                var value = selector(array[i]);
                if (value.HasValue)
                {
                    index = i + 1;
                    Current = value.GetValueOrDefault();
                    return true;
                }
            }

            index = array.Length;
            return false;
        }

        public void Reset() => throw new NotSupportedException();

        public void Dispose()
        {
        }
    }

    private sealed class WhereNotNullListIterator<TResult> : IEnumerable<TResult>, IEnumerator<TResult>
        where TResult : struct
    {
        private readonly List<TResult?> source;

        private readonly int threadId;

        private int state;

        private List<TResult?>.Enumerator enumerator;

        public WhereNotNullListIterator(List<TResult?> source)
        {
            this.source = source;
            threadId = Environment.CurrentManagedThreadId;
        }

        public TResult Current { get; private set; }

        object IEnumerator.Current => Current;

        public IEnumerator<TResult> GetEnumerator()
        {
            if ((state == 0) && (threadId == Environment.CurrentManagedThreadId))
            {
                state = 1;
                enumerator = source.GetEnumerator();
                return this;
            }

            return new WhereNotNullListIterator<TResult>(source) { state = 1, enumerator = source.GetEnumerator() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool MoveNext()
        {
            while (enumerator.MoveNext())
            {
                var value = enumerator.Current;
                if (value.HasValue)
                {
                    Current = value.GetValueOrDefault();
                    return true;
                }
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();

        public void Dispose() => enumerator.Dispose();
    }

    private sealed class WhereNotNullArrayIterator<TResult> : IEnumerable<TResult>, IEnumerator<TResult>
        where TResult : struct
    {
        private readonly TResult?[] source;

        private readonly int threadId;

        private int state;

        private int index;

        public WhereNotNullArrayIterator(TResult?[] source)
        {
            this.source = source;
            threadId = Environment.CurrentManagedThreadId;
        }

        public TResult Current { get; private set; }

        object IEnumerator.Current => Current;

        public IEnumerator<TResult> GetEnumerator()
        {
            if ((state == 0) && (threadId == Environment.CurrentManagedThreadId))
            {
                state = 1;
                return this;
            }

            return new WhereNotNullArrayIterator<TResult>(source) { state = 1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool MoveNext()
        {
            var array = source;
            for (var i = index; (uint)i < (uint)array.Length; i++)
            {
                var value = array[i];
                if (value.HasValue)
                {
                    index = i + 1;
                    Current = value.GetValueOrDefault();
                    return true;
                }
            }

            index = array.Length;
            return false;
        }

        public void Reset() => throw new NotSupportedException();

        public void Dispose()
        {
        }
    }
}
