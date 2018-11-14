namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    public class AssignableConvertTest
    {
        [Fact]
        public void Assignable()
        {
            var converter = new TestObjectConverter();
            var instance = new TestDeliveredClass();
            Assert.Same(instance, converter.Convert(instance, typeof(TestBaseClass)));
            Assert.True(converter.UsedOnly<AssignableConverterFactory>());
        }
    }
}
