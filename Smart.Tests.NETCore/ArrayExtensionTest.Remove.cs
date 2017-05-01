namespace Smart
{
    using Xunit;

    public class ArrayExtensionTest
    {
        [Fact]

        public static void TestArrayRemoveAt()
        {
            Assert.Equal(null, ((int[])null).RemoveAt(0));
            Assert.Equal(new[] { 2, 3 }, new[] { 1, 2, 3 }.RemoveAt(0));
            Assert.Equal(new[] { 1, 3 }, new[] { 1, 2, 3 }.RemoveAt(1));
            Assert.Equal(new[] { 1, 2 }, new[] { 1, 2, 3 }.RemoveAt(2));
            Assert.Equal(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }.RemoveAt(3));
        }

        [Fact]

        public static void TestArrayRemoveRange()
        {
            Assert.Equal(null, ((int[])null).RemoveRange(0, 1));
            Assert.Equal(new[] { 3, 4 }, new[] { 1, 2, 3, 4 }.RemoveRange(0, 2));
            Assert.Equal(new[] { 1, 4 }, new[] { 1, 2, 3, 4 }.RemoveRange(1, 2));
            Assert.Equal(new[] { 1, 2 }, new[] { 1, 2, 3, 4 }.RemoveRange(2, 2));
            Assert.Equal(new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4 }.RemoveRange(3, 2));
        }
    }
}
