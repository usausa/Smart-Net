namespace Smart.ComponentModel;

public abstract class DisposableObject : IDisposable
{
#if NET9_0_OR_GREATER
    private readonly Lock sync = new();
#else
    private readonly object sync = new();
#endif

    public bool IsDisposed { get; private set; }

    ~DisposableObject()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        lock (sync)
        {
            if (disposing && !IsDisposed)
            {
                IsDisposed = true;
            }
        }
    }
}
