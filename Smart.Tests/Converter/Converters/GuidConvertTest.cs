namespace Smart.Converter.Converters
{
    using System;

    using Xunit;

    public class GuidConvertTest
    {
        [Fact]
        public void StringToGuid()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(Guid.Empty, converter.Convert("00000000-0000-0000-0000-000000000000", typeof(Guid)));
            Assert.Null(converter.Convert(string.Empty, typeof(Guid?)));
            Assert.True(converter.UsedOnly<GuidConverterFactory>());
        }

        [Fact]
        public void GuidToString()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("00000000-0000-0000-0000-000000000000", converter.Convert(Guid.Empty, typeof(string)));
            Assert.True(converter.UsedOnly<GuidConverterFactory>());
        }
    }
}
