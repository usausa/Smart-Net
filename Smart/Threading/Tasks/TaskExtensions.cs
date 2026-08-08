namespace Smart.Threading.Tasks;

public static class TaskExtensions
{
    //--------------------------------------------------------------------------------
    // Forget
    //--------------------------------------------------------------------------------

    public static void Forget(this Task task)
    {
        if (task.IsCompleted)
        {
            _ = task.Exception;
            return;
        }

        _ = Awaited(task);

        static async Task Awaited(Task task)
        {
            await task.ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
            _ = task.Exception;
        }
    }

    public static void Forget(this Task task, Action<Exception> exceptionHandler)
    {
        _ = Awaited(task, exceptionHandler);

        static async Task Awaited(Task task, Action<Exception> handler)
        {
            await task.ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
            if (task.IsFaulted)
            {
                var exception = task.Exception!;
                handler(exception.InnerException ?? exception);
            }
            else if (task.IsCanceled)
            {
                handler(new TaskCanceledException(task));
            }
        }
    }

    public static void Forget<TState>(this Task task, TState state, Action<Exception, TState> exceptionHandler)
    {
        _ = Awaited(task, state, exceptionHandler);

        static async Task Awaited(Task task, TState state, Action<Exception, TState> handler)
        {
            await task.ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
            if (task.IsFaulted)
            {
                var exception = task.Exception!;
                handler(exception.InnerException ?? exception, state);
            }
            else if (task.IsCanceled)
            {
                handler(new TaskCanceledException(task), state);
            }
        }
    }

    public static void Forget(this ValueTask task) =>
        task.AsTask().Forget();

    public static void Forget(this ValueTask task, Action<Exception> exceptionHandler) =>
        task.AsTask().Forget(exceptionHandler);

    public static void Forget<TState>(this ValueTask task, TState state, Action<Exception, TState> exceptionHandler) =>
        task.AsTask().Forget(state, exceptionHandler);

    public static void Forget<TResult>(this ValueTask<TResult> task) =>
        task.AsTask().Forget();

    public static void Forget<TResult>(this ValueTask<TResult> task, Action<Exception> exceptionHandler) =>
        task.AsTask().Forget(exceptionHandler);

    public static void Forget<TResult, TState>(this ValueTask<TResult> task, TState state, Action<Exception, TState> exceptionHandler) =>
        task.AsTask().Forget(state, exceptionHandler);

    //--------------------------------------------------------------------------------
    // TryWaitAsync
    //--------------------------------------------------------------------------------

    public static async Task<bool> TryWaitAsync(this Task task, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (task.IsCompleted)
        {
            await task.ConfigureAwait(false);
            return true;
        }

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var delay = Task.Delay(timeout, cts.Token);
        var completed = await Task.WhenAny(task, delay).ConfigureAwait(false);
        if (completed == task)
        {
            await cts.CancelAsync().ConfigureAwait(false);
            await task.ConfigureAwait(false);
            return true;
        }

        cancellationToken.ThrowIfCancellationRequested();
        return false;
    }

    public static async Task<(bool Success, TResult? Result)> TryWaitAsync<TResult>(this Task<TResult> task, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (task.IsCompleted)
        {
            return (true, await task.ConfigureAwait(false));
        }

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var delay = Task.Delay(timeout, cts.Token);
        var completed = await Task.WhenAny(task, delay).ConfigureAwait(false);
        if (completed == task)
        {
            await cts.CancelAsync().ConfigureAwait(false);
            return (true, await task.ConfigureAwait(false));
        }

        cancellationToken.ThrowIfCancellationRequested();
        return (false, default);
    }
}
