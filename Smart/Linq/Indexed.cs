namespace Smart.Linq
{
    public readonly struct Indexed<T>
    {
        public T Item { get; }

        public int Index { get; }

        public Indexed(T item, int index)
        {
            Item = item;
            Index = index;
        }

        public override int GetHashCode() => Item.GetHashCode() ^ Index;
    }
}
