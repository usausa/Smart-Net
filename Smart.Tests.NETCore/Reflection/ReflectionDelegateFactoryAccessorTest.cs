namespace Smart.Reflection
{
    using System;

    using Xunit;

    public class ReflectionDelegateFactoryAccessorTest
    {
        //--------------------------------------------------------------------------------
        // Non static
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessReadWriteOnly()
        {
            var piWrite = typeof(ReadWriteOnlyData).GetProperty(nameof(ReadWriteOnlyData.WriteOnly));
            var piRead = typeof(ReadWriteOnlyData).GetProperty(nameof(ReadWriteOnlyData.ReadOnly));

            var getterWrite = ReflectionDelegateFactory.Default.CreateGetter(piWrite);
            var setterWrite = ReflectionDelegateFactory.Default.CreateSetter(piWrite);
            var getterRead = ReflectionDelegateFactory.Default.CreateGetter(piRead);
            var setterRead = ReflectionDelegateFactory.Default.CreateSetter(piRead);

            Assert.Null(getterWrite);
            Assert.NotNull(setterWrite);
            Assert.NotNull(getterRead);
            Assert.Null(setterRead);
        }

        [Fact]
        public void AccessClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StringValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, "abc");
            Assert.Equal("abc", getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyInt()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.IntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, 1);
            Assert.Equal(1, getter(data));

            setter(data, null);
            Assert.Equal(0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyBool()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.BoolValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, true);
            Assert.True((bool)getter(data));

            setter(data, null);
            Assert.False((bool)getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyByte()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.ByteValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, (byte)1);
            Assert.Equal((byte)1, getter(data));

            setter(data, null);
            Assert.Equal((byte)0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyChar()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.CharValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, (char)1);
            Assert.Equal((char)1, getter(data));

            setter(data, null);
            Assert.Equal((char)0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyShort()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.ShortValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, (short)1);
            Assert.Equal((short)1, getter(data));

            setter(data, null);
            Assert.Equal((short)0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyLong()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.LongValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, 1L);
            Assert.Equal(1L, getter(data));

            setter(data, null);
            Assert.Equal(0L, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyFloat()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.FloatValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, 1f);
            Assert.Equal(1f, getter(data));

            setter(data, null);
            Assert.Equal(0f, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyDouble()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.DoubleValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, 1d);
            Assert.Equal(1d, getter(data));

            setter(data, null);
            Assert.Equal(0d, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyIntPtr()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.IntPtrValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, (IntPtr)1);
            Assert.Equal((IntPtr)1, getter(data));

            setter(data, null);
            Assert.Equal(IntPtr.Zero, getter(data));
        }

        [Fact]
        public void AccessEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.EnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));

            setter(data, null);
            Assert.Equal(default(MyEnum), getter(data));
        }

        [Fact]
        public void AccessStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)getter(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            setter(data, null);
            structValue = (MyStruct)getter(data);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // Non static value holder
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessValueHolderClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationStringValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, "abc");
            Assert.Equal("abc", getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void AccessValueHolderValueTypeProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationIntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, 1);
            Assert.Equal(1, getter(data));

            setter(data, null);
            Assert.Equal(0, getter(data));
        }

        [Fact]
        public void AccessValueHolderEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationEnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));

            setter(data, null);
            Assert.Equal(default(MyEnum), getter(data));
        }

        [Fact]
        public void AccessValueHolderStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationStructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new Data();

            setter(data, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)getter(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            setter(data, null);
            structValue = (MyStruct)getter(data);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // Static
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessStaticClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticStringValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, "abc");
            Assert.Equal("abc", getter(null));

            setter(null, null);
            Assert.Null(getter(null));
        }

        [Fact]
        public void AccessStaticValueTypePropertyInt()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticIntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, 1);
            Assert.Equal(1, getter(null));

            setter(null, null);
            Assert.Equal(0, getter(null));
        }

        [Fact]
        public void AccessStaticEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticEnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(null));

            setter(null, null);
            Assert.Equal(default(MyEnum), getter(null));
        }

        [Fact]
        public void AccessStaticStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticStructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)getter(null);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            setter(null, null);
            structValue = (MyStruct)getter(null);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // Static value holder
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessStaticValueHolderClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationStringValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, "abc");
            Assert.Equal("abc", getter(null));

            setter(null, null);
            Assert.Null(getter(null));
        }

        [Fact]
        public void AccessStaticValueHolderValueTypeProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationIntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, 1);
            Assert.Equal(1, getter(null));

            setter(null, null);
            Assert.Equal(0, getter(null));
        }

        [Fact]
        public void AccessStaticValueHolderEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationEnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(null));

            setter(null, null);
            Assert.Equal(default(MyEnum), getter(null));
        }

        [Fact]
        public void AccessStaticValueHolderStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationStructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            setter(null, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)getter(null);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            setter(null, null);
            structValue = (MyStruct)getter(null);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }
    }
}