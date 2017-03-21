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
            Assert.Equal(converter.Convert<int>(null), 0);
            Assert.Equal(converter.FindMatchngFactory(), null);
        }

        [Fact]
        public void ConvertMatchSame()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal(converter.Convert<int>(0), 0);
            Assert.Equal(converter.FindMatchngFactory(), null);
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
