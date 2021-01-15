namespace Smart.Linq
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public class OptimizedEnumerableTest
    {
        //--------------------------------------------------------------------------------
        // All
        //--------------------------------------------------------------------------------

        [Fact]
        public void TestAllSpan()
        {
            var source = new Span<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.False(source.All(x => x >= 3));
            Assert.True(source[2..5].All(x => x >= 3));
            Assert.True(source[2..].All(x => x >= 3));
            Assert.False(source[2..5].All(x => x < 5));
        }

        [Fact]
        public void TestAllArray()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.False(source.All(x => x >= 3));
            Assert.True(source.All(2, 3, x => x >= 3));
            Assert.True(source.All(2, 5, x => x >= 3));
            Assert.False(source.All(2, 3, x => x < 5));
        }

        [Fact]
        public void TestAllList()
        {
            var source = new List<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.False(source.All(x => x >= 3));
            Assert.True(source.All(2, 3, x => x >= 3));
            Assert.True(source.All(2, 5, x => x >= 3));
            Assert.False(source.All(2, 3, x => x < 5));
        }

        //--------------------------------------------------------------------------------
        // Any
        //--------------------------------------------------------------------------------

        [Fact]
        public void TestAnySpan()
        {
            var source = new Span<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.True(source.Any(x => x >= 3));
            Assert.True(source[2..5].Any(x => x >= 3));
            Assert.True(source[2..].Any(x => x >= 3));
            Assert.False(source[2..5].Any(x => x < 3));
        }

        [Fact]
        public void TestAnyArray()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            Assert.True(source.Any(x => x >= 3));
            Assert.True(source.Any(2, 3, x => x >= 3));
            Assert.True(source.Any(2, 5, x => x >= 3));
            Assert.False(source.Any(2, 3, x => x < 3));
        }

        [Fact]
        public void TestAnyList()
        {
            var source = new List<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.True(source.Any(x => x >= 3));
            Assert.True(source.Any(2, 3, x => x >= 3));
            Assert.True(source.Any(2, 5, x => x >= 3));
            Assert.False(source.Any(2, 3, x => x < 3));
        }

        //--------------------------------------------------------------------------------
        // TODO Count
        //--------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        // TODO IndexOf
        //--------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        // TODO LastIndexOf
        //--------------------------------------------------------------------------------
    }
}
