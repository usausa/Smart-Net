namespace Smart.Threading.Tasks;

using System.Threading.Tasks.Sources;

public sealed class TaskExtensionsTests
{
    //--------------------------------------------------------------------------------
    // Forget
    //--------------------------------------------------------------------------------

    [Fact]
    public void ForgetCompletedTaskDoesNotThrow()
    {
        Task.CompletedTask.Forget();
        Task.FromException(new InvalidOperationException()).Forget();
    }

    [Fact]
    public async Task ForgetCallsHandlerOnException()
    {
        var tcs = new TaskCompletionSource<Exception>(TaskCreationOptions.RunContinuationsAsynchronously);

        FailAsync().Forget(ex => tcs.TrySetResult(ex));

        var exception = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);
        Assert.IsType<InvalidOperationException>(exception);

        static async Task FailAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public async Task ForgetCallsHandlerOnCancel()
    {
        var tcs = new TaskCompletionSource<Exception>(TaskCreationOptions.RunContinuationsAsynchronously);

        Task.FromCanceled(new CancellationToken(true)).Forget(ex => tcs.TrySetResult(ex));

        var exception = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);
        Assert.IsType<TaskCanceledException>(exception);
    }

    [Fact]
    public async Task ForgetCallsHandlerWithState()
    {
        var tcs = new TaskCompletionSource<(Exception Exception, string State)>(TaskCreationOptions.RunContinuationsAsynchronously);

        FailAsync().Forget("state", (ex, s) => tcs.TrySetResult((ex, s)));

        var (exception, state) = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);
        Assert.IsType<InvalidOperationException>(exception);
        Assert.Equal("state", state);

        static async Task FailAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public async Task ForgetValueTaskCallsHandlerOnException()
    {
        var tcs = new TaskCompletionSource<Exception>(TaskCreationOptions.RunContinuationsAsynchronously);

        FailAsync().Forget(ex => tcs.TrySetResult(ex));

        var exception = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);
        Assert.IsType<InvalidOperationException>(exception);

        static async ValueTask FailAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public async Task ForgetValueTaskWithResultCallsHandlerOnException()
    {
        var tcs = new TaskCompletionSource<Exception>(TaskCreationOptions.RunContinuationsAsynchronously);

        FailAsync().Forget(ex => tcs.TrySetResult(ex));

        var exception = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);
        Assert.IsType<InvalidOperationException>(exception);

        static async ValueTask<int> FailAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException();
        }
    }

    [Fact]
    public void ForgetCompletedValueTaskWithResultDoesNotAllocate()
    {
        ForgetAll(0);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            ForgetAll(i);
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);

        static void ForgetAll(int state)
        {
            new ValueTask<int>(123).Forget();
            new ValueTask<int>(123).Forget(static _ => { });
            new ValueTask<int>(123).Forget(state, static (_, _) => { });
        }
    }

    [Fact]
    public void ForgetCompletedValueTaskWithResultConsumesSource()
    {
        var source = new ResultSource();

        source.Complete(1).Forget();
        source.Complete(2).Forget(static _ => { });
        source.Complete(3).Forget(0, static (_, _) => { });

        Assert.Equal(3, source.GetResultCount);
    }

    [Fact]
    public void ForgetFaultedValueTaskWithResultCallsHandler()
    {
        var exceptions = new List<Exception>();

        new ValueTask<int>(Task.FromException<int>(new InvalidOperationException())).Forget();
        new ValueTask<int>(Task.FromException<int>(new InvalidOperationException())).Forget(exceptions.Add);
        new ValueTask<int>(Task.FromException<int>(new InvalidOperationException())).Forget(exceptions, static (ex, list) => list.Add(ex));

        Assert.Equal(2, exceptions.Count);
        Assert.All(exceptions, static ex => Assert.IsType<InvalidOperationException>(ex));
    }

    private sealed class ResultSource : IValueTaskSource<int>
    {
        private ManualResetValueTaskSourceCore<int> core;

        public int GetResultCount { get; private set; }

        public ValueTask<int> Complete(int result)
        {
            core.Reset();
            core.SetResult(result);
            return new ValueTask<int>(this, core.Version);
        }

        public int GetResult(short token)
        {
            GetResultCount++;
            return core.GetResult(token);
        }

        public ValueTaskSourceStatus GetStatus(short token) => core.GetStatus(token);

        public void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags) => core.OnCompleted(continuation, state, token, flags);
    }

    //--------------------------------------------------------------------------------
    // TryWaitAsync
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task TryWaitAsyncReturnsTrueWhenCompletedBeforeTimeout()
    {
        var result = await Task.Delay(10, TestContext.Current.CancellationToken).TryWaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);

        Assert.True(result);
    }

    [Fact]
    public async Task TryWaitAsyncReturnsTrueWhenAlreadyCompleted()
    {
        var result = await Task.CompletedTask.TryWaitAsync(TimeSpan.Zero, TestContext.Current.CancellationToken).ConfigureAwait(true);

        Assert.True(result);
    }

    [Fact]
    public async Task TryWaitAsyncReturnsFalseWhenTimeout()
    {
        var tcs = new TaskCompletionSource();

        var result = await tcs.Task.TryWaitAsync(TimeSpan.FromMilliseconds(50), TestContext.Current.CancellationToken).ConfigureAwait(true);

        Assert.False(result);
    }

    [Fact]
    public async Task TryWaitAsyncPropagatesTaskException()
    {
        var task = Task.FromException(new TimeoutException("inner"));

        var exception = await Assert.ThrowsAsync<TimeoutException>(() => task.TryWaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken)).ConfigureAwait(true);
        Assert.Equal("inner", exception.Message);
    }

    [Fact]
    public async Task TryWaitAsyncThrowsWhenCanceled()
    {
        using var cts = new CancellationTokenSource(20);
        var tcs = new TaskCompletionSource();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => tcs.Task.TryWaitAsync(TimeSpan.FromSeconds(10), cts.Token)).ConfigureAwait(true);
    }

    [Fact]
    public async Task TryWaitAsyncWithResultReturnsValue()
    {
        var (success, result) = await Task.FromResult(123).TryWaitAsync(TimeSpan.FromSeconds(5), TestContext.Current.CancellationToken).ConfigureAwait(true);

        Assert.True(success);
        Assert.Equal(123, result);
    }

    [Fact]
    public async Task TryWaitAsyncWithResultReturnsDefaultWhenTimeout()
    {
        var tcs = new TaskCompletionSource<int>();

        var (success, result) = await tcs.Task.TryWaitAsync(TimeSpan.FromMilliseconds(50), TestContext.Current.CancellationToken).ConfigureAwait(true);

        Assert.False(success);
        Assert.Equal(0, result);
    }

    [Fact]
    public async Task TryWaitAsyncPropagatesLaterTaskException()
    {
        var tcs = new TaskCompletionSource();

        var wait = tcs.Task.TryWaitAsync(TimeSpan.FromSeconds(10), TestContext.Current.CancellationToken);
        tcs.SetException(new InvalidOperationException("later"));

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => wait).ConfigureAwait(true);
        Assert.Equal("later", exception.Message);
    }

    [Fact]
    public async Task TryWaitAsyncWithResultPropagatesLaterTaskException()
    {
        var tcs = new TaskCompletionSource<int>();

        var wait = tcs.Task.TryWaitAsync(TimeSpan.FromSeconds(10), TestContext.Current.CancellationToken);
        tcs.SetException(new InvalidOperationException("later"));

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => wait).ConfigureAwait(true);
        Assert.Equal("later", exception.Message);
    }

    [Fact]
    public async Task TryWaitAsyncWithResultReturnsLaterValue()
    {
        var tcs = new TaskCompletionSource<int>();

        var wait = tcs.Task.TryWaitAsync(TimeSpan.FromSeconds(10), TestContext.Current.CancellationToken);
        tcs.SetResult(42);

        var (success, result) = await wait.ConfigureAwait(true);
        Assert.True(success);
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task TryWaitAsyncThrowsWithCallerTokenWhenCanceled()
    {
        using var cts = new CancellationTokenSource();
        var tcs = new TaskCompletionSource<int>();

        var wait = tcs.Task.TryWaitAsync(TimeSpan.FromSeconds(10), cts.Token);
        await cts.CancelAsync().ConfigureAwait(true);

        var exception = await Assert.ThrowsAsync<OperationCanceledException>(() => wait).ConfigureAwait(true);
        Assert.Equal(cts.Token, exception.CancellationToken);
    }

    [Fact]
    public async Task TryWaitAsyncThrowsForInvalidTimeout()
    {
        var tcs = new TaskCompletionSource();

        var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => tcs.Task.TryWaitAsync(TimeSpan.FromMilliseconds(-2), TestContext.Current.CancellationToken)).ConfigureAwait(true);
        Assert.Equal("timeout", exception.ParamName);
    }
}
