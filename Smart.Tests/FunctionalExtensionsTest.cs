namespace Smart;

public sealed class FunctionalExtensionsTest
{
    //--------------------------------------------------------------------------------
    // IfNotNull — class
    //--------------------------------------------------------------------------------

    [Fact]
    public void IfNotNullClassCallsActionWhenNotNull()
    {
        var called = false;
        var value = "hello";
        value.IfNotNull(v => { called = v == "hello"; });
        Assert.True(called);
    }

    [Fact]
    public void IfNotNullClassDoesNotCallActionWhenNull()
    {
        var called = false;
        string? value = null;
        value.IfNotNull(_ => { called = true; });
        Assert.False(called);
    }

    //--------------------------------------------------------------------------------
    // IfNotNull — struct (nullable)
    //--------------------------------------------------------------------------------

    [Fact]
    public void IfNotNullStructCallsActionWhenHasValue()
    {
        var received = 0;
        int? value = 42;
        value.IfNotNull(v => { received = v; });
        Assert.Equal(42, received);
    }

    [Fact]
    public void IfNotNullStructDoesNotCallActionWhenNull()
    {
        var called = false;
        int? value = null;
        value.IfNotNull(_ => { called = true; });
        Assert.False(called);
    }

    //--------------------------------------------------------------------------------
    // IfNotNull with state — class
    //--------------------------------------------------------------------------------

    [Fact]
    public void IfNotNullWithStateClassCallsAction()
    {
        var result = 0;
        var value = "hello";
        value.IfNotNull(10, (v, state) => { result = v.Length + state; });
        Assert.Equal(15, result);
    }

    [Fact]
    public void IfNotNullWithStateClassSkipsWhenNull()
    {
        var called = false;
        string? value = null;
        value.IfNotNull(0, (_, _) => { called = true; });
        Assert.False(called);
    }

    //--------------------------------------------------------------------------------
    // IfNotNull with state — struct
    //--------------------------------------------------------------------------------

    [Fact]
    public void IfNotNullWithStateStructCallsAction()
    {
        var result = 0;
        int? value = 5;
        value.IfNotNull(10, (v, state) => { result = v + state; });
        Assert.Equal(15, result);
    }

    //--------------------------------------------------------------------------------
    // IfNotNullAsync — class (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task IfNotNullAsyncClassCallsAction()
    {
        var called = false;
        var value = "hello";

        async Task Action(string v)
        {
            await Task.Yield();
            called = v.Length == 5;
        }

        await value.IfNotNullAsync(Action).ConfigureAwait(true);
        Assert.True(called);
    }

    [Fact]
    public async Task IfNotNullAsyncClassReturnsCompletedTaskWhenNull()
    {
        string? value = null;

        static async Task Action(string unused)
        {
            await Task.Yield();
            _ = unused;
        }

        var task = value.IfNotNullAsync(Action);
        await task.ConfigureAwait(true);
    }

    //--------------------------------------------------------------------------------
    // IfNotNullAsync — struct (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task IfNotNullAsyncStructCallsAction()
    {
        var received = 0;
        int? value = 7;

        async Task Action(int v)
        {
            await Task.Yield();
            received = v;
        }

        await value.IfNotNullAsync(Action).ConfigureAwait(true);
        Assert.Equal(7, received);
    }

    //--------------------------------------------------------------------------------
    // IfNotNullAsync — class (ValueTask)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task IfNotNullAsyncValueTaskClassCallsAction()
    {
        var called = false;
        var value = "hi";

        async ValueTask Action(string unused)
        {
            await Task.Yield();
            called = unused.Length > 0;
        }

        await value.IfNotNullAsync(Action).ConfigureAwait(true);
        Assert.True(called);
    }

    [Fact]
    public async Task IfNotNullAsyncValueTaskClassSkipsWhenNull()
    {
        var called = false;
        string? value = null;

        async ValueTask Action(string unused)
        {
            await Task.Yield();
            called = unused.Length > 0;
        }

        await value.IfNotNullAsync(Action).ConfigureAwait(true);
        Assert.False(called);
    }

    //--------------------------------------------------------------------------------
    // Also
    //--------------------------------------------------------------------------------

    [Fact]
    public void AlsoCallsActionAndReturnsOriginal()
    {
        var called = false;
        var result = "test".Also(v => { called = v == "test"; });
        Assert.True(called);
        Assert.Equal("test", result);
    }

    [Fact]
    public void AlsoWithValueType()
    {
        var sideEffect = 0;
        var result = 42.Also(v => { sideEffect = v; });
        Assert.Equal(42, sideEffect);
        Assert.Equal(42, result);
    }

    //--------------------------------------------------------------------------------
    // AlsoIf
    //--------------------------------------------------------------------------------

    [Fact]
    public void AlsoIfCallsActionWhenConditionTrue()
    {
        var called = false;
        var result = 10.AlsoIf(static x => x > 5, _ => { called = true; });
        Assert.True(called);
        Assert.Equal(10, result);
    }

    [Fact]
    public void AlsoIfSkipsActionWhenConditionFalse()
    {
        var called = false;
        var result = 3.AlsoIf(static x => x > 5, _ => { called = true; });
        Assert.False(called);
        Assert.Equal(3, result);
    }

    //--------------------------------------------------------------------------------
    // Also with state
    //--------------------------------------------------------------------------------

    [Fact]
    public void AlsoWithStateCallsAction()
    {
        var sum = 0;
        var result = 5.Also(10, (v, state) => { sum = v + state; });
        Assert.Equal(15, sum);
        Assert.Equal(5, result);
    }

    //--------------------------------------------------------------------------------
    // AlsoIf with state — condition overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void AlsoIfWithStateConditionOnValue()
    {
        var called = false;
        var result = 10.AlsoIf("unused", static x => x > 5, (_, _) => { called = true; });
        Assert.True(called);
        Assert.Equal(10, result);
    }

    [Fact]
    public void AlsoIfWithStateBothInCondition()
    {
        var called = false;
        var result = 10.AlsoIf(3, static (x, s) => x > s, _ => { called = true; });
        Assert.True(called);
        Assert.Equal(10, result);
    }

    [Fact]
    public void AlsoIfWithStateBothInConditionAndAction()
    {
        var called = false;
        var result = 10.AlsoIf(3, static (x, s) => x > s, (x, _) => { called = x == 10; });
        Assert.True(called);
        Assert.Equal(10, result);
    }

    //--------------------------------------------------------------------------------
    // AlsoAsync (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task AlsoAsyncTaskCallsActionAndReturnsValue()
    {
        var called = false;

        async Task Action(string v)
        {
            await Task.Yield();
            called = v.Length == 5;
        }

        var result = await "hello".AlsoAsync(Action).ConfigureAwait(true);
        Assert.True(called);
        Assert.Equal("hello", result);
    }

    //--------------------------------------------------------------------------------
    // AlsoIfAsync (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task AlsoIfAsyncTaskCallsWhenConditionTrue()
    {
        var called = false;

        async Task Action(int unused)
        {
            await Task.Yield();
            called = unused >= 0;
        }

        var result = await 10.AlsoIfAsync(static x => x > 5, Action).ConfigureAwait(true);
        Assert.True(called);
        Assert.Equal(10, result);
    }

    [Fact]
    public async Task AlsoIfAsyncTaskSkipsWhenConditionFalse()
    {
        var called = false;

        async Task Action(int unused)
        {
            await Task.Yield();
            called = unused >= 0;
        }

        var result = await 3.AlsoIfAsync(static x => x > 5, Action).ConfigureAwait(true);
        Assert.False(called);
        Assert.Equal(3, result);
    }

    //--------------------------------------------------------------------------------
    // AlsoAsync (ValueTask)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task AlsoAsyncValueTaskCallsAction()
    {
        var called = false;

        async ValueTask Action(int v)
        {
            await Task.Yield();
            called = v == 7;
        }

        var result = await 7.AlsoAsync(Action).ConfigureAwait(true);
        Assert.True(called);
        Assert.Equal(7, result);
    }

    //--------------------------------------------------------------------------------
    // Apply
    //--------------------------------------------------------------------------------

    [Fact]
    public void ApplyCallsAction()
    {
        var called = false;
        "test".Apply(_ => { called = true; });
        Assert.True(called);
    }

    //--------------------------------------------------------------------------------
    // ApplyIf
    //--------------------------------------------------------------------------------

    [Fact]
    public void ApplyIfCallsWhenTrue()
    {
        var called = false;
        10.ApplyIf(static x => x > 5, _ => { called = true; });
        Assert.True(called);
    }

    [Fact]
    public void ApplyIfSkipsWhenFalse()
    {
        var called = false;
        3.ApplyIf(static x => x > 5, _ => { called = true; });
        Assert.False(called);
    }

    //--------------------------------------------------------------------------------
    // Apply with state
    //--------------------------------------------------------------------------------

    [Fact]
    public void ApplyWithStateCallsAction()
    {
        var sum = 0;
        5.Apply(10, (v, state) => { sum = v + state; });
        Assert.Equal(15, sum);
    }

    //--------------------------------------------------------------------------------
    // ApplyIf with state — all overloads
    //--------------------------------------------------------------------------------

    [Fact]
    public void ApplyIfWithStateValueCondition()
    {
        var called = false;
        10.ApplyIf("s", static x => x > 5, (_, _) => { called = true; });
        Assert.True(called);
    }

    [Fact]
    public void ApplyIfWithStateBothInConditionActionNoState()
    {
        var called = false;
        10.ApplyIf(3, static (x, s) => x > s, _ => { called = true; });
        Assert.True(called);
    }

    [Fact]
    public void ApplyIfWithStateBothInConditionAndAction()
    {
        var called = false;
        10.ApplyIf(3, static (x, s) => x > s, (_, s) => { called = s == 3; });
        Assert.True(called);
    }

    //--------------------------------------------------------------------------------
    // ApplyAsync (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task ApplyAsyncTaskCallsAction()
    {
        var called = false;

        async Task Action(string unused)
        {
            await Task.Yield();
            called = true;
        }

        await "test".ApplyAsync(Action).ConfigureAwait(true);
        Assert.True(called);
    }

    [Fact]
    public async Task ApplyIfAsyncTaskCallsWhenTrue()
    {
        var called = false;

        async Task Action(int unused)
        {
            await Task.Yield();
            called = unused >= 0;
        }

        await 10.ApplyIfAsync(static x => x > 5, Action).ConfigureAwait(true);
        Assert.True(called);
    }

    [Fact]
    public async Task ApplyIfAsyncTaskSkipsWhenFalse()
    {
        var called = false;

        async Task Action(int unused)
        {
            await Task.Yield();
            called = unused >= 0;
        }

        await 3.ApplyIfAsync(static x => x > 5, Action).ConfigureAwait(true);
        Assert.False(called);
    }

    //--------------------------------------------------------------------------------
    // ApplyAsync (ValueTask)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task ApplyAsyncValueTaskCallsAction()
    {
        var called = false;

        async ValueTask Action(string unused)
        {
            await Task.Yield();
            called = true;
        }

        await "test".ApplyAsync(Action).ConfigureAwait(true);
        Assert.True(called);
    }

    //--------------------------------------------------------------------------------
    // Map
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapTransformsValue()
    {
        var result = "hello".Map(static v => v.Length);
        Assert.Equal(5, result);
    }

    [Fact]
    public void MapWithStateTransformsValue()
    {
        var result = 5.Map("!", static (v, state) => $"{v}{state}");
        Assert.Equal("5!", result);
    }

    //--------------------------------------------------------------------------------
    // MapOrDefault — class
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapOrDefaultClassReturnsResultWhenNotNull()
    {
        var result = "hello".MapOrDefault(static v => v.Length);
        Assert.Equal(5, result);
    }

    [Fact]
    public void MapOrDefaultClassReturnsDefaultWhenNull()
    {
        string? value = null;
        var result = value.MapOrDefault(static v => v.Length);
        Assert.Equal(0, result);
    }

    [Fact]
    public void MapOrDefaultClassWithExplicitDefault()
    {
        string? value = null;
        var result = value.MapOrDefault(static v => v.Length, -1);
        Assert.Equal(-1, result);
    }

    //--------------------------------------------------------------------------------
    // MapOrDefault — struct
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapOrDefaultStructReturnsResultWhenHasValue()
    {
        int? value = 42;
        var result = value.MapOrDefault(static v => v * 2);
        Assert.Equal(84, result);
    }

    [Fact]
    public void MapOrDefaultStructReturnsDefaultWhenNull()
    {
        int? value = null;
        var result = value.MapOrDefault(static v => v * 2);
        Assert.Equal(0, result);
    }

    [Fact]
    public void MapOrDefaultStructWithExplicitDefault()
    {
        int? value = null;
        var result = value.MapOrDefault(static v => v * 2, -99);
        Assert.Equal(-99, result);
    }

    //--------------------------------------------------------------------------------
    // MapIfOrDefault
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapIfOrDefaultReturnsResultWhenConditionTrue()
    {
        var result = 10.MapIfOrDefault(static x => x > 5, static x => x * 2);
        Assert.Equal(20, result);
    }

    [Fact]
    public void MapIfOrDefaultReturnsDefaultWhenConditionFalse()
    {
        var result = 3.MapIfOrDefault(static x => x > 5, static x => x * 2);
        Assert.Equal(0, result);
    }

    [Fact]
    public void MapIfOrDefaultWithExplicitDefault()
    {
        var result = 3.MapIfOrDefault(static x => x > 5, static x => x * 2, -1);
        Assert.Equal(-1, result);
    }

    //--------------------------------------------------------------------------------
    // MapOrDefault with state
    //--------------------------------------------------------------------------------

    [Fact]
    public void MapOrDefaultWithStateClass()
    {
        var result = "hello".MapOrDefault(10, static (v, s) => v.Length + s);
        Assert.Equal(15, result);
    }

    [Fact]
    public void MapOrDefaultWithStateClassNull()
    {
        string? value = null;
        var result = value.MapOrDefault(10, static (v, s) => v.Length + s);
        Assert.Equal(0, result);
    }

    //--------------------------------------------------------------------------------
    // MapAsync (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task MapAsyncTaskReturnsResult()
    {
        static async Task<int> Selector(string v)
        {
            await Task.Yield();
            return v.Length;
        }

        var result = await "hello".MapAsync(Selector).ConfigureAwait(true);
        Assert.Equal(5, result);
    }

    //--------------------------------------------------------------------------------
    // MapOrDefaultAsync (Task)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task MapOrDefaultAsyncTaskClassReturnsResult()
    {
        static async Task<int> Selector(string v)
        {
            await Task.Yield();
            return v.Length;
        }

        var result = await "hello".MapOrDefaultAsync(Selector).ConfigureAwait(true);
        Assert.Equal(5, result);
    }

    [Fact]
    public async Task MapOrDefaultAsyncTaskClassReturnsDefaultWhenNull()
    {
        string? value = null;

        static async Task<int> Selector(string v)
        {
            await Task.Yield();
            return v.Length;
        }

        var result = await value.MapOrDefaultAsync(Selector).ConfigureAwait(true);
        Assert.Equal(0, result);
    }

    //--------------------------------------------------------------------------------
    // MapAsync (ValueTask)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task MapAsyncValueTaskReturnsResult()
    {
        static async ValueTask<int> Selector(int v)
        {
            await Task.Yield();
            return v * 2;
        }

        var result = await 7.MapAsync(Selector).ConfigureAwait(true);
        Assert.Equal(14, result);
    }

    //--------------------------------------------------------------------------------
    // MapOrDefaultAsync (ValueTask)
    //--------------------------------------------------------------------------------

    [Fact]
    public async Task MapOrDefaultAsyncValueTaskClassReturnsResult()
    {
        static async ValueTask<int> Selector(string v)
        {
            await Task.Yield();
            return v.Length;
        }

        var result = await "hi".MapOrDefaultAsync(Selector).ConfigureAwait(true);
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task MapOrDefaultAsyncValueTaskStructReturnsDefault()
    {
        int? value = null;

        static async ValueTask<int> Selector(int v)
        {
            await Task.Yield();
            return v;
        }

        var result = await value.MapOrDefaultAsync(Selector).ConfigureAwait(true);
        Assert.Equal(0, result);
    }

    //--------------------------------------------------------------------------------
    // FlatOrEmpty — class
    //--------------------------------------------------------------------------------

    [Fact]
    public void FlatOrEmptyClassYieldsSingleElement()
    {
        var result = "hello".FlatOrEmpty().ToList();
        Assert.Single(result);
        Assert.Equal("hello", result[0]);
    }

    [Fact]
    public void FlatOrEmptyClassYieldsEmptyWhenNull()
    {
        string? value = null;
        var result = value.FlatOrEmpty().ToList();
        Assert.Empty(result);
    }

    //--------------------------------------------------------------------------------
    // FlatOrEmpty — struct
    //--------------------------------------------------------------------------------

    [Fact]
    public void FlatOrEmptyStructYieldsSingleElement()
    {
        int? value = 42;
        var result = value.FlatOrEmpty().ToList();
        Assert.Single(result);
        Assert.Equal(42, result[0]);
    }

    [Fact]
    public void FlatOrEmptyStructYieldsEmptyWhenNull()
    {
        int? value = null;
        var result = value.FlatOrEmpty().ToList();
        Assert.Empty(result);
    }
}
