namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    public class AssignableConverterFactoryTest
    {
        [Fact]
        public void Assignable()
        {
            var converter = new TestObjectConverter();
            var instance = new TestDeliveredClass();
            Assert.Same(instance, converter.Convert(instance, typeof(TestBaseClass)));
            Assert.True(converter.UsedOnly<AssignableConverterFactory>());
        }

        [Fact]
        public void NotAssignable()
        {
            var converter = new TestObjectConverter();
            Assert.Throws<ObjectConverterException>(() => converter.Convert(new TestBaseClass(), typeof(TestDeliveredClass)));
        }
    }
}
