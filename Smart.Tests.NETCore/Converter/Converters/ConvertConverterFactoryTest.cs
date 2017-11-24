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
            Assert.False(converter.Convert<bool>("false"));
            Assert.Equal(typeof(ConvertConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertStringToBoolTrue()
        {
            var converter = new MatchingObjectConverter();
            Assert.True(converter.Convert<bool>("true"));
            Assert.Equal(typeof(ConvertConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertStringToByte()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<byte>("1"));
            Assert.Equal(typeof(ConvertConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertStringToChar()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal('1', converter.Convert<char>("1"));
            Assert.Equal(typeof(ConvertConverterFactory), converter.FindMatchngFactory()?.GetType());
        }

        [Fact]
        public void ConvertStringToInt()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(1, converter.Convert<int>("1"));
            Assert.Equal(typeof(ConvertConverterFactory), converter.FindMatchngFactory()?.GetType());
        }
    }
}
