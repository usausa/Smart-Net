namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class AssignableConverterFactoryTest
    {
        [Fact]
        public void ConvertAssignable()
        {
            var converter = new MatchingObjectConverter();
            var source = new DeliverdType();
            Assert.Equal(converter.Convert<BaseType>(source), source);
            Assert.Equal(typeof(AssignableConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertNotAssignable()
        {
            var converter = new MatchingObjectConverter();
            var source = new BaseType();
            Assert.Throws<ObjectConverterException>(
                () => converter.Convert<DeliverdType>(source));
        }
    }
}
