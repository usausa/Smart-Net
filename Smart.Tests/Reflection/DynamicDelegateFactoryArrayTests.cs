namespace Smart.Reflection;

public sealed class DynamicDelegateFactoryArrayTests
{
    [Fact]
    public void ArrayAllocator()
    {
        var func = DynamicDelegateFactory.Default.CreateArrayAllocator(typeof(MemberData));

        var array = func(2);

        Assert.Equal(typeof(MemberData[]), array.GetType());
    }

    [Fact]
    public void ArrayAllocatorForInternal()
    {
        var func = DynamicDelegateFactory.Default.CreateArrayAllocator(typeof(InternalData));

        var array = func(2);

        Assert.Equal(typeof(InternalData[]), array.GetType());
    }
}
