namespace Smart.Converter.Converters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public sealed partial class EnumerableConverterFactory
    {
        //--------------------------------------------------------------------------------
        // ArrayConvertEnumerator
        //--------------------------------------------------------------------------------

        private sealed class ArrayConvertEnumerator<TSource, TDestination> : IEnumerator<TDestination>
        {
            private readonly TSource[] source;

            private readonly Func<object, object> converter;

            private int index;

            public ArrayConvertEnumerator(TSource[] source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
                index = -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                index++;
                return index < source.Length;
            }

            public void Reset() => index = -1;

            public TDestination Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => (TDestination)converter(source[index]);
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        private readonly struct ArrayConvertList<TSource, TDestination> : IList<TDestination>
        {
            private readonly TSource[] source;

            private readonly Func<object, object> converter;

            public ArrayConvertList(TSource[] source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
            }

            public IEnumerator<TDestination> GetEnumerator() => new ArrayConvertEnumerator<TSource, TDestination>(source, converter);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public void Add(TDestination item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TDestination item) => throw new NotSupportedException();

            public void CopyTo(TDestination[] array, int arrayIndex)
            {
                for (var i = 0; i < source.Length; i++)
                {
                    array[arrayIndex + i] = (TDestination)converter(source[i]);
                }
            }

            public bool Remove(TDestination item) => throw new NotSupportedException();

            public int Count => source.Length;

            public bool IsReadOnly => true;

            public int IndexOf(TDestination item) => throw new NotSupportedException();

            public void Insert(int index, TDestination item) => throw new NotSupportedException();

            public void RemoveAt(int index) => throw new NotSupportedException();

            public TDestination this[int index]
            {
                get => (TDestination)converter(source[index]);
                set => throw new NotSupportedException();
            }
        }

        //--------------------------------------------------------------------------------
        // ListConvertList
        //--------------------------------------------------------------------------------

        private sealed class ListConvertEnumerator<TSource, TDestination> : IEnumerator<TDestination>
        {
            private readonly IList<TSource> source;

            private readonly Func<object, object> converter;

            private int index;

            public ListConvertEnumerator(IList<TSource> source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
                index = -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                index++;
                return index < source.Count;
            }

            public void Reset() => index = -1;

            public TDestination Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => (TDestination)converter(source[index]);
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        private readonly struct ListConvertList<TSource, TDestination> : IList<TDestination>
        {
            private readonly IList<TSource> source;

            private readonly Func<object, object> converter;

            public ListConvertList(IList<TSource> source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
            }

            public IEnumerator<TDestination> GetEnumerator() => new ListConvertEnumerator<TSource, TDestination>(source, converter);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public void Add(TDestination item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TDestination item) => throw new NotSupportedException();

            public void CopyTo(TDestination[] array, int arrayIndex)
            {
                for (var i = 0; i < source.Count; i++)
                {
                    array[arrayIndex + i] = (TDestination)converter(source[i]);
                }
            }

            public bool Remove(TDestination item) => throw new NotSupportedException();

            public int Count => source.Count;

            public bool IsReadOnly => true;

            public int IndexOf(TDestination item) => throw new NotSupportedException();

            public void Insert(int index, TDestination item) => throw new NotSupportedException();

            public void RemoveAt(int index) => throw new NotSupportedException();

            public TDestination this[int index]
            {
                get => (TDestination)converter(source[index]);
                set => throw new NotSupportedException();
            }
        }

        //--------------------------------------------------------------------------------
        // CollectionConvertCollection
        //--------------------------------------------------------------------------------

        private readonly struct CollectionConvertCollection<TSource, TDestination> : ICollection<TDestination>
        {
            private readonly ICollection<TSource> source;

            private readonly Func<object, object> converter;

            public CollectionConvertCollection(ICollection<TSource> source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
            }

            public IEnumerator<TDestination> GetEnumerator() => new EnumerableConvertEnumerator<TSource, TDestination>(source.GetEnumerator(), converter);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public void Add(TDestination item) => throw new NotSupportedException();

            public void Clear() => throw new NotSupportedException();

            public bool Contains(TDestination item) => throw new NotSupportedException();

            public void CopyTo(TDestination[] array, int arrayIndex)
            {
                var i = 0;
                foreach (var value in source)
                {
                    array[arrayIndex + i] = (TDestination)converter(value);
                    i++;
                }
            }

            public bool Remove(TDestination item) => throw new NotSupportedException();

            public int Count => source.Count;

            public bool IsReadOnly => true;
        }

        //--------------------------------------------------------------------------------
        // EnumerableConvertEnumerable
        //--------------------------------------------------------------------------------

        private sealed class EnumerableConvertEnumerator<TSource, TDestination> : IEnumerator<TDestination>
        {
            private readonly IEnumerator<TSource> source;

            private readonly Func<object, object> converter;

            public EnumerableConvertEnumerator(IEnumerator<TSource> source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => source.MoveNext();

            public void Reset() => source.Reset();

            public TDestination Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => (TDestination)converter(source.Current);
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                source.Dispose();
            }
        }

        private readonly struct EnumerableConvertEnumerable<TSource, TDestination> : IEnumerable<TDestination>
        {
            private readonly IEnumerable<TSource> source;

            private readonly Func<object, object> converter;

            public EnumerableConvertEnumerable(IEnumerable<TSource> source, Func<object, object> converter)
            {
                this.source = source;
                this.converter = converter;
            }

            public IEnumerator<TDestination> GetEnumerator() => new EnumerableConvertEnumerator<TSource, TDestination>(source.GetEnumerator(), converter);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
