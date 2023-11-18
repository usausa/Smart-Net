namespace Smart.Threading.Tasks;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2008:DoNotCreateTasksWithoutPassingATaskScheduler", Justification = "Ignore")]
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
