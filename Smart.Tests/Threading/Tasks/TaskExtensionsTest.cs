namespace Smart.Threading.Tasks;

public sealed class TaskExtensionsTest
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
}
