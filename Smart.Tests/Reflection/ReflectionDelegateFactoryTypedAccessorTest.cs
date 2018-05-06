namespace Smart.Reflection
{
    using System;

    using Xunit;

    public class ReflectionDelegateFactoryTypedAccessorTest
    {
        //--------------------------------------------------------------------------------
        // Non static
        //--------------------------------------------------------------------------------

        [Fact]
        public void TypedAccessReadWriteOnly()
        {
            var getterWrite = ReflectionDelegateFactory.Default.CreateGetter<ReadWriteOnlyData, String>(nameof(ReadWriteOnlyData.WriteOnly));
            var setterWrite = ReflectionDelegateFactory.Default.CreateSetter<ReadWriteOnlyData, String>(nameof(ReadWriteOnlyData.WriteOnly));
            var getterRead = ReflectionDelegateFactory.Default.CreateGetter<ReadWriteOnlyData, String>(nameof(ReadWriteOnlyData.ReadOnly));
            var setterRead = ReflectionDelegateFactory.Default.CreateSetter<ReadWriteOnlyData, String>(nameof(ReadWriteOnlyData.ReadOnly));

            Assert.Null(getterWrite);
            Assert.NotNull(setterWrite);
            Assert.NotNull(getterRead);
            Assert.Null(setterRead);
        }

        [Fact]
        public void TypedAccessClassProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, string>(nameof(Data.StringValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, string>(nameof(Data.StringValue));

            var data = new Data();

            setter(data, "abc");
            Assert.Equal("abc", getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyInt()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, int>(nameof(Data.IntValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, int>(nameof(Data.IntValue));

            var data = new Data();

            setter(data, 1);
            Assert.Equal(1, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyBool()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, bool>(nameof(Data.BoolValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, bool>(nameof(Data.BoolValue));

            var data = new Data();

            setter(data, true);
            Assert.True(getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyByte()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, byte>(nameof(Data.ByteValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, byte>(nameof(Data.ByteValue));

            var data = new Data();

            setter(data, 1);
            Assert.Equal((byte)1, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyChar()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, char>(nameof(Data.CharValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, char>(nameof(Data.CharValue));

            var data = new Data();

            setter(data, (char)1);
            Assert.Equal((char)1, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyShort()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, short>(nameof(Data.ShortValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, short>(nameof(Data.ShortValue));

            var data = new Data();

            setter(data, 1);
            Assert.Equal((short)1, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyLong()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, long>(nameof(Data.LongValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, long>(nameof(Data.LongValue));

            var data = new Data();

            setter(data, 1L);
            Assert.Equal(1L, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyFloat()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, float>(nameof(Data.FloatValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, float>(nameof(Data.FloatValue));

            var data = new Data();

            setter(data, 1f);
            Assert.Equal(1f, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyDouble()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, double>(nameof(Data.DoubleValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, double>(nameof(Data.DoubleValue));

            var data = new Data();

            setter(data, 1d);
            Assert.Equal(1d, getter(data));
        }

        [Fact]
        public void TypedAccessValueTypePropertyIntPtr()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, IntPtr>(nameof(Data.IntPtrValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, IntPtr>(nameof(Data.IntPtrValue));

            var data = new Data();

            setter(data, (IntPtr)1);
            Assert.Equal((IntPtr)1, getter(data));
        }

        [Fact]
        public void TypedAccessEnumProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyEnum>(nameof(Data.EnumValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyEnum>(nameof(Data.EnumValue));

            var data = new Data();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));
        }

        [Fact]
        public void TypedAccessStructProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyStruct>(nameof(Data.StructValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyStruct>(nameof(Data.StructValue));

            var data = new Data();

            setter(data, new MyStruct { X = 1, Y = 2 });
            var structValue = getter(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // Non static value holder
        //--------------------------------------------------------------------------------

        [Fact]
        public void TypedAccessValueHolderClassProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, string>(nameof(Data.NotificationStringValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, string>(nameof(Data.NotificationStringValue));

            var data = new Data();

            setter(data, "abc");
            Assert.Equal("abc", getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void TypedAccessValueHolderValueTypeProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, int>(nameof(Data.NotificationIntValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, int>(nameof(Data.NotificationIntValue));

            var data = new Data();

            setter(data, 1);
            Assert.Equal(1, getter(data));
        }

        [Fact]
        public void TypedAccessValueHolderEnumProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyEnum>(nameof(Data.NotificationEnumValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyEnum>(nameof(Data.NotificationEnumValue));

            var data = new Data();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));
        }

        [Fact]
        public void TypedAccessValueHolderStructProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyStruct>(nameof(Data.NotificationStructValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyStruct>(nameof(Data.NotificationStructValue));

            var data = new Data();

            setter(data, new MyStruct { X = 1, Y = 2 });
            var structValue = getter(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // Static
        //--------------------------------------------------------------------------------

        [Fact]
        public void TypedAccessStaticClassProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, string>(nameof(Data.StaticStringValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, string>(nameof(Data.StaticStringValue));

            setter(null, "abc");
            Assert.Equal("abc", getter(null));

            setter(null, null);
            Assert.Null(getter(null));
        }

        [Fact]
        public void TypedAccessStaticValueTypePropertyInt()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, int>(nameof(Data.StaticIntValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, int>(nameof(Data.StaticIntValue));

            setter(null, 1);
            Assert.Equal(1, getter(null));
        }

        [Fact]
        public void TypedAccessStaticEnumProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyEnum>(nameof(Data.StaticEnumValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyEnum>(nameof(Data.StaticEnumValue));

            setter(null, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(null));
        }

        [Fact]
        public void TypedAccessStaticStructProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyStruct>(nameof(Data.StaticStructValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyStruct>(nameof(Data.StaticStructValue));

            setter(null, new MyStruct { X = 1, Y = 2 });
            var structValue = getter(null);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // Static value holder
        //--------------------------------------------------------------------------------

        [Fact]
        public void TypedAccessStaticValueHolderClassProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, string>(nameof(Data.StaticNotificationStringValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, string>(nameof(Data.StaticNotificationStringValue));

            setter(null, "abc");
            Assert.Equal("abc", getter(null));

            setter(null, null);
            Assert.Null(getter(null));
        }

        [Fact]
        public void TypedAccessStaticValueHolderValueTypeProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, int>(nameof(Data.StaticNotificationIntValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, int>(nameof(Data.StaticNotificationIntValue));

            setter(null, 1);
            Assert.Equal(1, getter(null));
        }

        [Fact]
        public void TypedAccessStaticValueHolderEnumProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyEnum>(nameof(Data.StaticNotificationEnumValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyEnum>(nameof(Data.StaticNotificationEnumValue));

            setter(null, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(null));
        }

        [Fact]
        public void TypedAccessStaticValueHolderStructProperty()
        {
            var getter = ReflectionDelegateFactory.Default.CreateGetter<Data, MyStruct>(nameof(Data.StaticNotificationStructValue));
            var setter = ReflectionDelegateFactory.Default.CreateSetter<Data, MyStruct>(nameof(Data.StaticNotificationStructValue));

            setter(null, new MyStruct { X = 1, Y = 2 });
            var structValue = getter(null);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);
        }
    }
}