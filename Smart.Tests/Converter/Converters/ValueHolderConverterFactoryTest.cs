namespace Smart.Converter.Converters
{
    using System;

    using Smart.ComponentModel;
    using Smart.Converter.Types;

    using Xunit;

    public class ValueHolderConverterFactoryTest
    {
        [Fact]
        public void ValueHolderToSameValueType()
        {
            var converter = new TestObjectConverter();
            Assert.Equal(1, converter.Convert(new NotificationValue<int>(1), typeof(int)));
            Assert.True(converter.UsedOnly<ValueHolderConverterFactory>());
        }

        [Fact]
        public void ValueHolderToDifferentValueType()
        {
            var converter = new TestObjectConverter();
            Assert.Equal("1", converter.Convert(new NotificationValue<int>(1), typeof(string)));
            Assert.True(converter.UsedIn(typeof(ValueHolderConverterFactory), typeof(ToStringConverterFactory)));
        }

        [Fact]
        public void ValueHolderToNotConvertableValueType()
        {
            var converter = new TestObjectConverter();
            Assert.False(converter.CanConvert(new NotificationValue<DateTime>(), typeof(StructType)));
        }
    }
}
