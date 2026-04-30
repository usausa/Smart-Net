namespace Smart.Threading;

using Smart.ComponentModel;

public sealed class AtomicReference<T> : IValueHolder<T>
    where T : class
{
    private T currentValue = default!;

    public T Value
    {
        get => Volatile.Read(ref currentValue);
        set => Volatile.Write(ref currentValue, value);
    }

    public AtomicReference()
    {
    }

    public AtomicReference(T initialValue)
    {
        currentValue = initialValue;
    }

    public T GetAndSet(T value)
    {
        return Interlocked.Exchange(ref currentValue, value);
    }

    public bool TrySet(T value, T comparand)
    {
        return Interlocked.CompareExchange(ref currentValue, value, comparand) == comparand;
    }
}
