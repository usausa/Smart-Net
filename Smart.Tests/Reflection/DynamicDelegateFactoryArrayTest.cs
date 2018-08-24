namespace Smart.Reflection
{
    using Xunit;

    public class DynamicDelegateFactoryArrayTest
    {
        [Fact]
        public void ArrayAllocator()
        {
            var func = DynamicDelegateFactory.Default.CreateArrayAllocator(typeof(Data));

            var array = func(2);

            Assert.Equal(typeof(Data[]), array.GetType());
        }

        [Fact]
        public void ArrayAllocatorForInternal()
        {
            var func = DynamicDelegateFactory.Default.CreateArrayAllocator(typeof(InternalData));

            var array = func(2);

            Assert.Equal(typeof(InternalData[]), array.GetType());
        }
    }
}