namespace Smart.Text.Tasks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory =
            new TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

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
}
