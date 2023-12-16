namespace Smart.Linq;

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
