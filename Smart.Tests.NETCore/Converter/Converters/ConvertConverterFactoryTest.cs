namespace Smart.Converter.Converters
{
    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class ConvertConverterFactoryTest
    {
        [Fact]
        public void ConvertStringToIntFailed()
        {
            var converter = new MatchingObjectConverter();
            Assert.Throws<ObjectConverterException>(
                () => converter.Convert<int>(string.Empty));
        }

        [Fact]
        public void ConvertStringToIntNullableFailed()
        {
            var converter = new MatchingObjectConverter();
            Assert.Throws<ObjectConverterException>(
                () => converter.Convert<int?>(string.Empty));
        }

        [Fact]
        public void ConvertStringToBoolFalse()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<bool>("false"), false);
            Assert.Equal(converter.FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [Fact]
        public void ConvertStringToBoolTrue()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<bool>("true"), true);
            Assert.Equal(converter.FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [Fact]
        public void ConvertStringToByte()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<byte>("1"), 1);
            Assert.Equal(converter.FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [Fact]
        public void ConvertStringToChar()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<char>("1"), '1');
            Assert.Equal(converter.FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }

        [Fact]
        public void ConvertStringToInt()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<int>("1"), 1);
            Assert.Equal(converter.FindMatchngFactory()?.GetType(), typeof(ConvertConverterFactory));
        }
    }
}
