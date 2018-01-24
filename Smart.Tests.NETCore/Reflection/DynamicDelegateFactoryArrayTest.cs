namespace Smart.Reflection
{
    using Xunit;

    public class DynamicDelegateFactoryArrayTest
    {
        [Fact]
        public void ArrayAlocator()
        {
            var func = DynamicDelegateFactory.Default.CreateArrayAllocator(typeof(Data));

            var array = func(2);

            Assert.Equal(typeof(Data[]), array.GetType());
        }

        [Fact]
        public void ArrayAlocatorForInternal()
        {
            var func = DynamicDelegateFactory.Default.CreateArrayAllocator(typeof(InternalData));

            var array = func(2);

            Assert.Equal(typeof(InternalData[]), array.GetType());
        }
    }
}