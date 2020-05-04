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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StringValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, "abc");
            Assert.Equal("abc", getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyInt()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.IntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, 1);
            Assert.Equal(1, getter(data));

            setter(data, null);
            Assert.Equal(0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyBool()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.BoolValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, true);
            Assert.True((bool)getter(data));

            setter(data, null);
            Assert.False((bool)getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyByte()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.ByteValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, (byte)1);
            Assert.Equal((byte)1, getter(data));

            setter(data, null);
            Assert.Equal((byte)0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyChar()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.CharValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, (char)1);
            Assert.Equal((char)1, getter(data));

            setter(data, null);
            Assert.Equal((char)0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyShort()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.ShortValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, (short)1);
            Assert.Equal((short)1, getter(data));

            setter(data, null);
            Assert.Equal((short)0, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyLong()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.LongValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, 1L);
            Assert.Equal(1L, getter(data));

            setter(data, null);
            Assert.Equal(0L, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyFloat()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.FloatValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, 1f);
            Assert.Equal(1f, getter(data));

            setter(data, null);
            Assert.Equal(0f, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyDouble()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.DoubleValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, 1d);
            Assert.Equal(1d, getter(data));

            setter(data, null);
            Assert.Equal(0d, getter(data));
        }

        [Fact]
        public void AccessValueTypePropertyIntPtr()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.IntPtrValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, (IntPtr)1);
            Assert.Equal((IntPtr)1, getter(data));

            setter(data, null);
            Assert.Equal(IntPtr.Zero, getter(data));
        }

        [Fact]
        public void AccessEnumProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.EnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));

            setter(data, null);
            Assert.Equal(default(MyEnum), getter(data));
        }

        [Fact]
        public void AccessStructProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

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
        // Non static nullable
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessNullableProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NullableIntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, 1);
            Assert.Equal(1, getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void AccessNullableEnumProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NullableEnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void AccessNullableStructProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NullableStructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)getter(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            setter(data, null);
            Assert.Null(getter(data));
        }

        //--------------------------------------------------------------------------------
        // Non static value holder
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessValueHolderClassProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NotificationStringValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, "abc");
            Assert.Equal("abc", getter(data));

            setter(data, null);
            Assert.Null(getter(data));
        }

        [Fact]
        public void AccessValueHolderValueTypeProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NotificationIntValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, 1);
            Assert.Equal(1, getter(data));

            setter(data, null);
            Assert.Equal(0, getter(data));
        }

        [Fact]
        public void AccessValueHolderEnumProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NotificationEnumValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

            setter(data, MyEnum.One);
            Assert.Equal(MyEnum.One, getter(data));

            setter(data, null);
            Assert.Equal(default(MyEnum), getter(data));
        }

        [Fact]
        public void AccessValueHolderStructProperty()
        {
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.NotificationStructValue));
            var getter = ReflectionDelegateFactory.Default.CreateGetter(pi);
            var setter = ReflectionDelegateFactory.Default.CreateSetter(pi);

            var data = new MemberData();

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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticStringValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticIntValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticEnumValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticStructValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticNotificationStringValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticNotificationIntValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticNotificationEnumValue));
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
            var pi = typeof(MemberData).GetProperty(nameof(MemberData.StaticNotificationStructValue));
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