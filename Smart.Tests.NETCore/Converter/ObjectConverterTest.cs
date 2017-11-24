namespace Smart.Converter
{
    using Smart.Converter.Types;

    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class ObjectConverterTest
    {
        [Fact]
        public void ConvertMatchNullToDefault()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(0, converter.Convert<int>(null));
            Assert.Null(converter.FindMatchngFactory());
        }

        [Fact]
        public void ConvertMatchSame()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(0, converter.Convert<int>(0));
            Assert.Null(converter.FindMatchngFactory());
        }

        [Fact]
        public void ConvertUnmatch()
        {
            var converter = new MatchingObjectConverter();
            Assert.Throws<ObjectConverterException>(
                () => converter.Convert<StructType>(string.Empty));
        }
    }
}
