namespace Smart.ComponentModel;

public abstract class DisposableObject : IDisposable
{
    private bool disposed;

    public bool IsDisposed => Volatile.Read(ref disposed);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Volatile.Write(ref disposed, true);
        }
    }
}
