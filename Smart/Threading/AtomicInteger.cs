namespace Smart.Threading;

using Smart.ComponentModel;

public sealed class AtomicInteger : IValueHolder<int>
{
    private int currentValue;

    public int Value
    {
        get => Interlocked.Exchange(ref currentValue, currentValue);
        set => Interlocked.Exchange(ref currentValue, value);
    }

    public AtomicInteger()
    {
    }

    public AtomicInteger(int initialValue)
    {
        currentValue = initialValue;
    }

    public int GetAndSet(int value)
    {
        return Interlocked.Exchange(ref currentValue, value);
    }

    public bool TrySet(int value, int comparand)
    {
        return Interlocked.CompareExchange(ref currentValue, value, comparand) == comparand;
    }
}
