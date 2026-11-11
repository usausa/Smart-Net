namespace Smart;

public sealed class TypeExtensionsTests
{
    private static int createdCount;

    private readonly struct Counted
    {
        public Counted()
        {
            Interlocked.Increment(ref createdCount);
        }
    }

    private readonly struct WithConstructor
    {
        public WithConstructor()
        {
            X = 1;
        }

        public int X { get; }
    }

    [Fact]
    public void GetDefaultValueReturnsNullForReferenceType()
    {
        Assert.Null(typeof(string).GetDefaultValue());
    }

    [Fact]
    public void GetDefaultValueReturnsZeroForInt()
    {
        Assert.Equal(0, Assert.IsType<int>(typeof(int).GetDefaultValue()));
    }

    [Fact]
    public void GetDefaultValueReturnsNullForNullable()
    {
        Assert.Null(typeof(int?).GetDefaultValue());
    }

    [Fact]
    public void GetDefaultValueReturnsDefaultForStruct()
    {
        Assert.Equal(Guid.Empty, Assert.IsType<Guid>(typeof(Guid).GetDefaultValue()));
    }

    [Fact]
    public void GetDefaultValueRunsParameterlessConstructorOfStruct()
    {
        Assert.Equal(1, Assert.IsType<WithConstructor>(typeof(WithConstructor).GetDefaultValue()).X);
    }

    [Fact]
    public void GetDefaultValueCreatesValueOnceForConcurrentCalls()
    {
        using var start = new ManualResetEventSlim();
        var results = new object?[32];
        var threads = Enumerable.Range(0, results.Length)
            .Select(i => new Thread(state =>
            {
                ((ManualResetEventSlim)state!).Wait();
                results[i] = typeof(Counted).GetDefaultValue();
            }))
            .ToArray();
        foreach (var thread in threads)
        {
            thread.Start(start);
        }

        start.Set();
        foreach (var thread in threads)
        {
            thread.Join();
        }

        Assert.Equal(1, createdCount);
        Assert.All(results, x => Assert.Same(results[0], x));
    }
}
