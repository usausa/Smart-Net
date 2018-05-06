namespace Smart.Reflection
{
    using Xunit;

    public class ReflectionDelegateFactoryArrayTest
    {
        [Fact]
        public void ArrayAlocator()
        {
            var func = ReflectionDelegateFactory.Default.CreateArrayAllocator(typeof(Data));

            var array = func(2);

            Assert.Equal(typeof(Data[]), array.GetType());
        }

        [Fact]
        public void ArrayAlocatorForInternal()
        {
            var func = ReflectionDelegateFactory.Default.CreateArrayAllocator(typeof(InternalData));

            var array = func(2);

            Assert.Equal(typeof(InternalData[]), array.GetType());
        }
    }
}