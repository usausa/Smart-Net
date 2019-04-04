namespace Smart
{
    using System.Threading.Tasks;

    public static class Empty<T>
    {
        public static Task<T> Task { get; } = System.Threading.Tasks.Task.FromResult(default(T));
    }
}
