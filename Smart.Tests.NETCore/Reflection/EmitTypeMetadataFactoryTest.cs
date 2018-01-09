namespace Smart.Reflection
{
    using System;

    using Smart.ComponentModel;

    using Xunit;

    public class EmitTypeMetadataFactoryTest
    {
        public enum MyEnum
        {
            Zero,
            One,
            Two
        }

        public struct MyStruct
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        public class Data
        {
            public int IntValue { get; set; }

            public string StringValue { get; set; }

            public IValueHolder<int> NotificationIntValue { get; } = new NotificationValue<int>();

            public IValueHolder<string> NotificationStringValue { get; } = new NotificationValue<string>();

            public bool BoolValue { get; set; }

            public byte ByteValue { get; set; }

            public char CharValue { get; set; }

            public short ShortValue { get; set; }

            public long LongValue { get; set; }

            public float FloatValue { get; set; }

            public double DoubleValue { get; set; }

            public IntPtr IntPtrValue { get; set; }

            public MyEnum EnumValue { get; set; }

            public IValueHolder<MyEnum> NotificationEnumValue { get; } = new NotificationValue<MyEnum>();

            public MyStruct StructValue { get; set; }

            public IValueHolder<MyStruct> NotificationStructValue { get; } = new NotificationValue<MyStruct>();

            // static

            public static int StaticIntValue { get; set; }

            public static string StaticStringValue { get; set; }

            public static IValueHolder<int> StaticNotificationIntValue { get; } = new NotificationValue<int>();

            public static IValueHolder<string> StaticNotificationStringValue { get; } = new NotificationValue<string>();

            public static MyEnum StaticEnumValue { get; set; }

            public static IValueHolder<MyEnum> StaticNotificationEnumValue { get; } = new NotificationValue<MyEnum>();

            public static MyStruct StaticStructValue { get; set; }

            public static IValueHolder<MyStruct> StaticNotificationStructValue { get; } =
                new NotificationValue<MyStruct>();
        }

        public class Data2
        {
            public int IntValue { get; }

            public string StringValue { get; }

            public Data2(int intValue, string stringValue)
            {
                IntValue = intValue;
                StringValue = stringValue;
            }
        }

        //--------------------------------------------------------------------------------
        // Activator
        //--------------------------------------------------------------------------------

        [Fact]
        public void ActivateByDefaultConstructor()
        {
            var ctor = typeof(Data).GetConstructor(Type.EmptyTypes);
            var activator = EmitTypeMetadataFactory.Default.CreateActivator(ctor);

            Assert.Equal(ctor, activator.Source);

            var obj = activator.Create(null);

            Assert.NotNull(obj);
            Assert.Equal(typeof(Data), obj.GetType());
        }

        [Fact]
        public void ActivateWithArguments()
        {
            var ctor = typeof(Data2).GetConstructor(new[] { typeof(int), typeof(string) });
            var activator = EmitTypeMetadataFactory.Default.CreateActivator(ctor);

            Assert.Equal(ctor, activator.Source);

            var obj = (Data2)activator.Create(new object[] { 1, "abc" });

            Assert.Equal(1, obj.IntValue);
            Assert.Equal("abc", obj.StringValue);
        }

        //--------------------------------------------------------------------------------
        // Accessor
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessReadOnlyProperty()
        {
            var pi = typeof(Data2).GetProperty(nameof(Data2.StringValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data2.StringValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.False(accessor.CanWrite);
        }

        [Fact]
        public void AccessClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StringValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StringValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, "abc");
            Assert.Equal("abc", accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Null(accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyInt()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.IntValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.IntValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, 1);
            Assert.Equal(1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyBool()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.BoolValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.BoolValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, true);
            Assert.True((bool)accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.False((bool)accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyByte()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.ByteValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.ByteValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, (byte)1);
            Assert.Equal((byte)1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal((byte)0, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyChar()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.CharValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.CharValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, (char)1);
            Assert.Equal((char)1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal((char)0, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyShort()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.ShortValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.ShortValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, (short)1);
            Assert.Equal((short)1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal((short)0, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyLong()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.LongValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.LongValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, 1L);
            Assert.Equal(1L, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0L, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyFloat()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.FloatValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.FloatValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, 1f);
            Assert.Equal(1f, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0f, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyDouble()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.DoubleValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.DoubleValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, 1d);
            Assert.Equal(1d, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0d, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypePropertyIntPtr()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.IntPtrValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.IntPtrValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, (IntPtr)1);
            Assert.Equal((IntPtr)1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(IntPtr.Zero, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueHolderClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationStringValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.NotificationStringValue), accessor.Name);
            Assert.Equal(typeof(string), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, "abc");
            Assert.Equal("abc", accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Null(accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueHolderValueTypeProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationIntValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.NotificationIntValue), accessor.Name);
            Assert.Equal(typeof(int), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, 1);
            Assert.Equal(1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0, accessor.GetValue(data));
        }

        [Fact]
        public void AccessEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.EnumValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.EnumValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, MyEnum.One);
            Assert.Equal(MyEnum.One, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(default(MyEnum), accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueHolderEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationEnumValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.NotificationEnumValue), accessor.Name);
            Assert.Equal(typeof(MyEnum), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, MyEnum.One);
            Assert.Equal(MyEnum.One, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(default(MyEnum), accessor.GetValue(data));
        }

        [Fact]
        public void AccessStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StructValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StructValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)accessor.GetValue(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            accessor.SetValue(data, null);
            structValue = (MyStruct)accessor.GetValue(data);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        [Fact]
        public void AccessValueHolderStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationStructValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.NotificationStructValue), accessor.Name);
            Assert.Equal(typeof(MyStruct), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            var data = new Data();

            accessor.SetValue(data, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)accessor.GetValue(data);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            accessor.SetValue(data, null);
            structValue = (MyStruct)accessor.GetValue(data);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        // static

        [Fact]
        public void AccessStaticClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticStringValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticStringValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, "abc");
            Assert.Equal("abc", accessor.GetValue(null));

            accessor.SetValue(null, null);
            Assert.Null(accessor.GetValue(null));
        }

        [Fact]
        public void AccessStaticValueTypePropertyInt()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticIntValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticIntValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, 1);
            Assert.Equal(1, accessor.GetValue(null));

            accessor.SetValue(null, null);
            Assert.Equal(0, accessor.GetValue(null));
        }

        [Fact]
        public void AccessStaticValueHolderClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationStringValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticNotificationStringValue), accessor.Name);
            Assert.Equal(typeof(string), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, "abc");
            Assert.Equal("abc", accessor.GetValue(null));

            accessor.SetValue(null, null);
            Assert.Null(accessor.GetValue(null));
        }

        [Fact]
        public void AccessStaticValueHolderValueTypeProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationIntValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticNotificationIntValue), accessor.Name);
            Assert.Equal(typeof(int), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, 1);
            Assert.Equal(1, accessor.GetValue(null));

            accessor.SetValue(null, null);
            Assert.Equal(0, accessor.GetValue(null));
        }

        [Fact]
        public void AccessStaticEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticEnumValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticEnumValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, MyEnum.One);
            Assert.Equal(MyEnum.One, accessor.GetValue(null));

            accessor.SetValue(null, null);
            Assert.Equal(default(MyEnum), accessor.GetValue(null));
        }

        [Fact]
        public void AccessStaticValueHolderEnumProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationEnumValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticNotificationEnumValue), accessor.Name);
            Assert.Equal(typeof(MyEnum), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, MyEnum.One);
            Assert.Equal(MyEnum.One, accessor.GetValue(null));

            accessor.SetValue(null, null);
            Assert.Equal(default(MyEnum), accessor.GetValue(null));
        }

        [Fact]
        public void AccessStaticStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticStructValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticStructValue), accessor.Name);
            Assert.Equal(pi.PropertyType, accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)accessor.GetValue(null);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            accessor.SetValue(null, null);
            structValue = (MyStruct)accessor.GetValue(null);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        [Fact]
        public void AccessStaticValueHolderStructProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StaticNotificationStructValue));
            var accessor = EmitTypeMetadataFactory.Default.CreateAccessor(pi);

            Assert.Equal(pi, accessor.Source);
            Assert.Equal(nameof(Data.StaticNotificationStructValue), accessor.Name);
            Assert.Equal(typeof(MyStruct), accessor.Type);
            Assert.True(accessor.CanRead);
            Assert.True(accessor.CanWrite);

            accessor.SetValue(null, new MyStruct { X = 1, Y = 2 });
            var structValue = (MyStruct)accessor.GetValue(null);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);

            accessor.SetValue(null, null);
            structValue = (MyStruct)accessor.GetValue(null);
            Assert.Equal(0, structValue.X);
            Assert.Equal(0, structValue.Y);
        }

        //--------------------------------------------------------------------------------
        // ArrayOperator
        //--------------------------------------------------------------------------------

        [Fact]
        public void ArrayOperationBool()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(bool));

            var array = arrayOperator.Create(2);
            array.SetValue(true, 1);
            Assert.True((bool)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationByte()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(byte));

            var array = arrayOperator.Create(2);
            array.SetValue((byte)1, 1);
            Assert.Equal((byte)1, (byte)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationChar()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(char));

            var array = arrayOperator.Create(2);
            array.SetValue((char)1, 1);
            Assert.Equal((char)1, (char)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationShort()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(short));

            var array = arrayOperator.Create(2);
            array.SetValue((short)1, 1);
            Assert.Equal((short)1, (short)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationInt()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(int));

            var array = arrayOperator.Create(2);
            array.SetValue(1, 1);
            Assert.Equal(1, (int)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationSByte()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(sbyte));

            var array = arrayOperator.Create(2);
            array.SetValue((sbyte)1, 1);
            Assert.Equal((sbyte)1, (sbyte)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationUShort()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(ushort));

            var array = arrayOperator.Create(2);
            array.SetValue((ushort)1, 1);
            Assert.Equal((ushort)1, (ushort)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationUInt()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(uint));

            var array = arrayOperator.Create(2);
            array.SetValue((uint)1, 1);
            Assert.Equal((uint)1, (uint)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationLong()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(long));

            var array = arrayOperator.Create(2);
            array.SetValue(1L, 1);
            Assert.Equal(1L, (long)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationULong()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(ulong));

            var array = arrayOperator.Create(2);
            array.SetValue(1UL, 1);
            Assert.Equal(1UL, (ulong)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationFloat()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(float));

            var array = arrayOperator.Create(2);
            array.SetValue(1F, 1);
            Assert.Equal(1F, (float)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationDouble()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(double));

            var array = arrayOperator.Create(2);
            array.SetValue(1D, 1);
            Assert.Equal(1D, (double)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationIntPtr()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(IntPtr));

            var array = arrayOperator.Create(2);
            array.SetValue((IntPtr)1, 1);
            Assert.Equal((IntPtr)1, (IntPtr)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationUIntPtr()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(UIntPtr));

            var array = arrayOperator.Create(2);
            array.SetValue((UIntPtr)1, 1);
            Assert.Equal((UIntPtr)1, (UIntPtr)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationString()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(string));

            var array = arrayOperator.Create(2);
            array.SetValue("1", 1);
            Assert.Equal("1", (string)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationEnum()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(MyEnum));

            var array = arrayOperator.Create(2);
            array.SetValue(MyEnum.One, 1);
            Assert.Equal(MyEnum.One, (MyEnum)array.GetValue(1));
        }

        [Fact]
        public void ArrayOperationStruct()
        {
            var arrayOperator = EmitTypeMetadataFactory.Default.CreateArray(typeof(MyStruct));

            var array = arrayOperator.Create(2);
            array.SetValue(new MyStruct { X = 1, Y = 2 }, 1);
            var structValue = (MyStruct)array.GetValue(1);
            Assert.Equal(1, structValue.X);
            Assert.Equal(2, structValue.Y);
        }
    }
}