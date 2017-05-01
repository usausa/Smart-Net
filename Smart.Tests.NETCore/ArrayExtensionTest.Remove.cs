namespace Smart
{
    using Xunit;

    public class ArrayExtensionTest
    {
        [Fact]

        public static void TestArrayRemoveRange()
        {
            var array = new[] { 1, 2, 3, 4 };

            Assert.Equal(new[] { 1, 4 }, array.RemoveRange(1, 2));
        }
    }
}
