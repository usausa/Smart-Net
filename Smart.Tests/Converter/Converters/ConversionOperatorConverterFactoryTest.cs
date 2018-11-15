namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    public class ConversionOperatorConverterFactoryTest
    {
        //--------------------------------------------------------------------------------
        // Implicit
        //--------------------------------------------------------------------------------

        [Fact]
        public void ConvertImplicitToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<int>(new ImplicitType { Value = 1 }));
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertImplicitToIntNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(new ImplicitType { Value = 1 }));
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToImplicit()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<ImplicitType>(1).Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToImplicitNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<ImplicitType?>(1)?.Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertNullableImplicitToIntNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(new NullableImplicitType { Value = 1 }));
            Assert.Null(converter.Convert<int?>(new NullableImplicitType { Value = null }));
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToNullableImplicit()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<NullableImplicitType>(1).Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToNullableImplicitNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<NullableImplicitType?>(1)?.Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        //--------------------------------------------------------------------------------
        // Explicit
        //--------------------------------------------------------------------------------

        [Fact]
        public void ConvertExplicitToInt()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<int>(new ExplicitType { Value = 1 }));
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertExplicitToIntNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(new ExplicitType { Value = 1 }));
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToExplicit()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<ExplicitType>(1).Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToExplicitNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<ExplicitType?>(1)?.Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertNullableExplicitToIntNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<int?>(new NullableExplicitType { Value = 1 }));
            Assert.Null(converter.Convert<int?>(new NullableExplicitType { Value = null }));
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToNullableExplicit()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<NullableExplicitType>(1).Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }

        [Fact]
        public void ConvertIntToNullableExplicitNullable()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert<NullableExplicitType?>(1)?.Value);
            Assert.True(converter.UsedOnly<ConversionOperatorConverterFactory>());
        }
    }
}
