namespace Smart;

#pragma warning disable CA1815
public readonly struct DelegateDisposable : IDisposable
{
    private readonly Action action;

    public DelegateDisposable(Action action)
    {
        this.action = action;
    }

    public void Dispose() => action();
}
#pragma warning restore CA1815

#pragma warning disable CA1815
public readonly struct AsyncDelegateDisposable : IAsyncDisposable
{
    private readonly Func<ValueTask> func;

    public AsyncDelegateDisposable(Func<ValueTask> func)
    {
        this.func = func;
    }

    public ValueTask DisposeAsync() => func();
}
#pragma warning restore CA1815
