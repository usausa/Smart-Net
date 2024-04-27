namespace Smart.Linq;

using System.Collections;
using System.Runtime.CompilerServices;

#pragma warning disable CA1815
public readonly struct Indexed<T>
{
    public T Item { get; }

    public int Index { get; }

    public Indexed(T item, int index)
    {
        Item = item;
        Index = index;
    }

    public override int GetHashCode()
    {
        return Item is null ? Index : Item.GetHashCode() ^ Index;
    }
}
#pragma warning restore CA1815

public static partial class EnumerableExtensions
{
    private sealed class IndexedEnumerator<T> : IEnumerator<Indexed<T>>
    {
        private readonly IEnumerator<T> ie;

        private int index;

        internal IndexedEnumerator(IEnumerator<T> ie)
        {
            this.ie = ie;
            index = -1;
        }

        public void Dispose()
        {
            ie.Dispose();
        }

        public Indexed<T> Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new(ie.Current, index);
        }

        object IEnumerator.Current => Current;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            index++;
            return ie.MoveNext();
        }

        public void Reset() => throw new NotSupportedException();
    }

    private readonly struct IndexedEnumerable<T> : IEnumerable<Indexed<T>>
    {
        private readonly IEnumerable<T> ie;

        public IndexedEnumerable(IEnumerable<T> ie)
        {
            this.ie = ie;
        }

        IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Indexed<T>> Indexed<T>(this IEnumerable<T> source)
    {
        return new IndexedEnumerable<T>(source);
    }
}
