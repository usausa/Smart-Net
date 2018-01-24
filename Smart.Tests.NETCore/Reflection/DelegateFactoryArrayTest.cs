namespace Smart.Reflection
{
    using Xunit;

    public class DelegateFactoryArrayTest
    {
        [Fact]
        public void ArrayAlocator()
        {
            var func = DelegateFactory.Default.CreateArrayAllocator(typeof(Data));

            var array = func(2);

            Assert.Equal(typeof(Data[]), array.GetType());
        }

        [Fact]
        public void ArrayAlocatorForInternal()
        {
            var func = DelegateFactory.Default.CreateArrayAllocator(typeof(InternalData));

            var array = func(2);

            Assert.Equal(typeof(InternalData[]), array.GetType());
        }
    }
}