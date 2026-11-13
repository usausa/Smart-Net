namespace Smart;

using System.ComponentModel;

public sealed class EnumsTests
{
    private enum Described
    {
        [Description("First Item")]
        First,
        Second,
        [Description("")]
        Empty
    }

    [Flags]
    private enum Permission
    {
        None = 0,
        [Description("Read")]
        Read = 1,
        [Description("Write")]
        Write = 2,
        [Description("Exec")]
        Exec = 4
    }

    private enum Same1
    {
        [Description("S1")]
        X = 1
    }

    private enum Same2
    {
        [Description("S2")]
        Y = 1
    }

    private enum Concurrent
    {
        [Description("Concurrent")]
        Value
    }

    [Fact]
    public void GetDescription()
    {
        Assert.Equal("First Item", Enums.GetDescription(Described.First));
        Assert.Equal("Second", Enums.GetDescription(Described.Second));
        Assert.Equal(String.Empty, Enums.GetDescription(Described.Empty));
        Assert.Equal("5", Enums.GetDescription((Described)5));
    }

    [Fact]
    public void GetDescriptionOfFlags()
    {
        Assert.Equal("None", Enums.GetDescription(Permission.None));
        Assert.Equal("Read", Enums.GetDescription(Permission.Read));
        Assert.Equal("Read, Exec", Enums.GetDescription(Permission.Read | Permission.Exec));
        Assert.Equal("8", Enums.GetDescription((Permission)8));
    }

    [Fact]
    public void GetDescriptionDistinguishesTypes()
    {
        Assert.Equal("S1", Enums.GetDescription(Same1.X));
        Assert.Equal("S2", Enums.GetDescription(Same2.Y));
        Assert.Equal("S1", Enums.GetDescription(Same1.X));
    }

    [Fact]
    public void GetDescriptionFromCacheDoesNotAllocate()
    {
        Enum value = Described.First;
        _ = Enums.GetDescription(value);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            _ = Enums.GetDescription(value);
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);
    }

    [Fact]
    public void GetDescriptionConcurrentFirstCallReturnsSameInstance()
    {
        const int count = 16;
        var results = new string[count];
        using var barrier = new Barrier(count);
        var threads = new Thread[count];
        for (var i = 0; i < count; i++)
        {
            threads[i] = new Thread(static state =>
            {
                var (values, gate, index) = ((string[], Barrier, int))state!;
                gate.SignalAndWait();
                values[index] = Enums.GetDescription(Concurrent.Value);
            });
            threads[i].Start((results, barrier, i));
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Assert.Equal("Concurrent", results[0]);
        foreach (var result in results)
        {
            Assert.Same(results[0], result);
        }
    }
}
