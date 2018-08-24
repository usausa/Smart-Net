namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class ConversionOperatorConverterFactoryTest
    {
        [Fact]
        public void ConvertImplicitToInt()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int>(new ImplicitType { Value = 1 }));
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertImplicitToIntNullable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(new ImplicitType { Value = 1 }));
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertIntToImplicit()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<ImplicitType>(1).Value);
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertIntToImplicitNullable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<ImplicitType?>(1)?.Value);
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertExplicitToInt()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int>(new ExplicitType { Value = 1 }));
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertExplicitToIntNullable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(new ExplicitType { Value = 1 }));
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertIntToExplicit()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<ExplicitType>(1).Value);
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }

        [Fact]
        public void ConvertIntToExplicitNullable()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<ExplicitType?>(1)?.Value);
            Assert.Equal(typeof(ConversionOperatorConverterFactory), converter.FindMatchingFactory()?.GetType());
        }
    }
}
