namespace Smart.Converter.Converters
{
    using Smart.ComponentModel;

    using Xunit;

    public class ConstructorConverterFactoryTest
    {
        [Fact]
        public void IntToTypeHasSameTypeConstructor()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, ((NotificationValue<int>)(converter.Convert(1, typeof(NotificationValue<int>)))).Value);
            Assert.True(converter.UsedOnly<ConstructorConverterFactory>());
        }

        [Fact]
        public void IntToTypeHasSameNullableTypeConstructor()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, ((NotificationValue<int?>)(converter.Convert(1, typeof(NotificationValue<int?>)))).Value);
            Assert.True(converter.UsedOnly<ConstructorConverterFactory>());
        }

        // TODO
    }
}
