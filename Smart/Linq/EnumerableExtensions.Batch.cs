namespace Smart.Linq;

public static partial class EnumerableExtensions
{
    //--------------------------------------------------------------------------------
    // Batch : For bulk insert, pagination, window processing, etc
    //--------------------------------------------------------------------------------

    public static IEnumerable<T[]> Batch<T>(this IEnumerable<T> source, int size)
    {
        return BatchIterator(source, size);

        static IEnumerable<T[]> BatchIterator(IEnumerable<T> source, int size)
        {
            T[]? bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                bucket ??= new T[size];
                bucket[count++] = item;

                if (count == size)
                {
                    yield return bucket;

                    bucket = null;
                    count = 0;
                }
            }

            if (count > 0)
            {
                Array.Resize(ref bucket, count);
                yield return bucket;
            }
        }
    }

    public static IEnumerable<TResult[]> Batch<TSource, TResult>(
        this IEnumerable<TSource> source,
        int size,
        Func<TSource, TResult> selector)
    {
        return BatchWithSelectorIterator(source, size, selector);

        static IEnumerable<TResult[]> BatchWithSelectorIterator(IEnumerable<TSource> source, int size, Func<TSource, TResult> selector)
        {
            TResult[]? bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                bucket ??= new TResult[size];
                bucket[count++] = selector(item);

                if (count == size)
                {
                    yield return bucket;

                    bucket = null;
                    count = 0;
                }
            }

            if (count > 0)
            {
                Array.Resize(ref bucket, count);

                yield return bucket;
            }
        }
    }

    //--------------------------------------------------------------------------------
    // Segment : Conditional splitting version of Batch
    //--------------------------------------------------------------------------------

    public static IEnumerable<IReadOnlyList<T>> Segment<T>(
        this IEnumerable<T> source,
        Func<T, bool> predicate)
    {
        return SegmentByValueIterator(source, predicate);

        static IEnumerable<IReadOnlyList<T>> SegmentByValueIterator(
            IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            using var e = source.GetEnumerator();
            if (!e.MoveNext())
            {
                yield break;
            }

            var segment = new List<T> { e.Current };

            while (e.MoveNext())
            {
                var current = e.Current;
                if (predicate(current))
                {
                    yield return segment;

                    segment = [current];
                }
                else
                {
                    segment.Add(current);
                }
            }

            yield return segment;
        }
    }

    public static IEnumerable<IReadOnlyList<T>> Segment<T>(
        this IEnumerable<T> source,
        Func<T, int, bool> predicate)
    {
        return SegmentByIndexIterator(source, predicate);

        static IEnumerable<IReadOnlyList<T>> SegmentByIndexIterator(
            IEnumerable<T> source,
            Func<T, int, bool> predicate)
        {
            using var e = source.GetEnumerator();
            if (!e.MoveNext())
            {
                yield break;
            }

            var segment = new List<T> { e.Current };

            for (var index = 1; e.MoveNext(); index++)
            {
                var current = e.Current;
                if (predicate(current, index))
                {
                    yield return segment;
                    segment = [current];
                }
                else
                {
                    segment.Add(current);
                }
            }

            yield return segment;
        }
    }

    public static IEnumerable<IReadOnlyList<T>> Segment<T>(
        this IEnumerable<T> source,
        Func<T, T, int, bool> predicate)
    {
        return SegmentIterator(source, predicate);

        static IEnumerable<IReadOnlyList<T>> SegmentIterator(
            IEnumerable<T> source, Func<T, T, int, bool> predicate)
        {
            using var e = source.GetEnumerator();
            if (!e.MoveNext())
            {
                yield break;
            }

            var previous = e.Current;
            var segment = new List<T> { previous };

            for (var index = 1; e.MoveNext(); index++)
            {
                var current = e.Current;
                if (predicate(current, previous, index))
                {
                    yield return segment;

                    segment = [current];
                }
                else
                {
                    segment.Add(current);
                }

                previous = current;
            }

            yield return segment;
        }
    }
}
