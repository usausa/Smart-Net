namespace Smart;

using Xunit;

#pragma warning disable IDE0300
public class ArrayExtensionTest
{
    [Fact]
    public void TestArrayRemoveAt()
    {
        Assert.Equal(new[] { 2, 3 }, new[] { 1, 2, 3 }.RemoveAt(0));
        Assert.Equal(new[] { 1, 3 }, new[] { 1, 2, 3 }.RemoveAt(1));
        Assert.Equal(new[] { 1, 2 }, new[] { 1, 2, 3 }.RemoveAt(2));
        Assert.Equal(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }.RemoveAt(3));
    }

    [Fact]
    public void TestArrayRemoveRange()
    {
        Assert.Equal(new[] { 3, 4 }, new[] { 1, 2, 3, 4 }.RemoveRange(0, 2));
        Assert.Equal(new[] { 1, 4 }, new[] { 1, 2, 3, 4 }.RemoveRange(1, 2));
        Assert.Equal(new[] { 1, 2 }, new[] { 1, 2, 3, 4 }.RemoveRange(2, 2));
        Assert.Equal(new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4 }.RemoveRange(3, 2));
    }
}
#pragma warning restore IDE0300
