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
            Assert.Equal(converter.Convert<string>(new StructType { Value1 = 1, Value2 = 2 }), "(1, 2)");
            Assert.Equal(converter.FindMatchngFactory()?.GetType(), typeof(ToStringConverterFactory));
        }
    }
}
