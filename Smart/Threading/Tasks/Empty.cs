namespace Smart.Threading.Tasks
{
    using System.Threading.Tasks;

    public static class Tasks<T>
    {
        public static Task<T> DefaultResult { get; } = System.Threading.Tasks.Task.FromResult(default(T));
    }
}
