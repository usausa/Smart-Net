namespace Smart;

using Smart.ComponentModel;
using Smart.Reflection;

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

    [Fact]
    public void IsValueHolderTypeFindsImplementedInterface()
    {
        Assert.True(typeof(IValueHolder<int>).IsValueHolderType());
        Assert.True(typeof(NotificationValue<string>).IsValueHolderType());
        Assert.True(typeof(ExplicitValueHolder).IsValueHolderType());
        Assert.False(typeof(int).IsValueHolderType());
    }

    [Fact]
    public void GetValueHolderTypeReturnsImplementedInterface()
    {
        Assert.Equal(typeof(IValueHolder<int>), typeof(IValueHolder<int>).GetValueHolderType());
        Assert.Equal(typeof(IValueHolder<string>), typeof(NotificationValue<string>).GetValueHolderType());
        Assert.Equal(typeof(IValueHolder<int>), typeof(ExplicitValueHolder).GetValueHolderType());
        Assert.Null(typeof(int).GetValueHolderType());
        Assert.Equal(typeof(IValueHolder<int>), typeof(ValueHolderData).GetProperty(nameof(ValueHolderData.ClassIntValue))!.GetValueHolderType());
        Assert.Null(typeof(ValueHolderData).GetProperty(nameof(ValueHolderData.IntValue))!.GetValueHolderType());
    }

    [Fact]
    public void GetValueHolderPropertyReturnsValueOfInterface()
    {
        var pi = typeof(ExplicitValueHolder).GetValueHolderProperty()!;
        Assert.Equal(typeof(IValueHolder<int>), pi.DeclaringType);
        Assert.Equal(typeof(int), pi.PropertyType);
        Assert.True(pi.CanRead);
        Assert.True(pi.CanWrite);
        Assert.Equal(typeof(string), typeof(NotificationValue<string>).GetValueHolderProperty()!.PropertyType);
        Assert.Equal(typeof(MyStruct), typeof(IValueHolder<MyStruct>).GetValueHolderProperty()!.PropertyType);
        Assert.Null(typeof(int).GetValueHolderProperty());
        Assert.Equal(typeof(int), typeof(ValueHolderData).GetProperty(nameof(ValueHolderData.ClassIntValue))!.PropertyType.GetValueHolderProperty()!.PropertyType);
        Assert.Null(typeof(ValueHolderData).GetProperty(nameof(ValueHolderData.IntValue))!.PropertyType.GetValueHolderProperty());
    }
}
