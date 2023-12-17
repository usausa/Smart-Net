namespace Smart;

public sealed class EventArgs<T> : EventArgs
{
    public T Data { get; }

    public EventArgs(T data)
    {
        Data = data;
    }
}
