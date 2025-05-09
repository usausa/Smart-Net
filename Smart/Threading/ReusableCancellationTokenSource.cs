namespace Smart.Threading;

public sealed class ReusableCancellationTokenSource : IDisposable
{
    private CancellationTokenSource cts = new();

    public bool IsCancellationRequested => cts.IsCancellationRequested;

    public CancellationToken Token => cts.Token;

    public void Dispose()
    {
        cts.Dispose();
    }

    public void Reset()
    {
        if (!cts.TryReset())
        {
            cts.Dispose();
            cts = new CancellationTokenSource();
        }
    }

    public void Cancel() => cts.Cancel();

    public void Cancel(bool throwOnFirstException) => cts.Cancel(throwOnFirstException);

    public Task CancelAsync() => cts.CancelAsync();

    public void CancelAfter(TimeSpan delay) => cts.CancelAfter(delay);

    public void CancelAfter(int millisecondsDelay) => cts.CancelAfter(millisecondsDelay);
}
