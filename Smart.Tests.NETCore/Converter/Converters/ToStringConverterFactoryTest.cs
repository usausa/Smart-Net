namespace Smart.Converter.Converters
{
    using Smart.Converter.Types;

    using Xunit;

    /// <summary>
    ///
    /// </summary>
    public class ToStringConverterFactoryTest
    {
        [Fact]
        public void ConvertToString()
        {
            var converter = new MatchingObjectConverter();
            Assert.Equal("(1, 2)", converter.Convert<string>(new StructType { Value1 = 1, Value2 = 2 }));
            Assert.Equal(typeof(ToStringConverterFactory), converter.FindMatchngFactory()?.GetType());
        }
    }
}
