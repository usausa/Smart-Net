namespace Smart.Threading.Tasks;

#pragma warning disable CA2008
public static class AsyncHelper
{
    private static readonly TaskFactory TaskFactory =
        new(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

    public static void RunSync(Func<Task> task) =>
        TaskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();

    public static TResult RunSync<TResult>(Func<Task<TResult>> task) =>
        TaskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
}
#pragma warning restore CA2008
