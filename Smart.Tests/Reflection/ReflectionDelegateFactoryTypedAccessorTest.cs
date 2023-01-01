#if !NET7_0_OR_GREATER
// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable RedundantCast
#endif
namespace Smart.Reflection;

using Xunit;

public class ReflectionDelegateFactoryTypedAccessorTest
{
    //--------------------------------------------------------------------------------
    // Non static
    //--------------------------------------------------------------------------------

    [Fact]
    public void TypedAccessReadWriteOnly()
    {
        var getterWrite = ReflectionDelegateFactory.Default.CreateGetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.WriteOnly));
        var setterWrite = ReflectionDelegateFactory.Default.CreateSetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.WriteOnly));
        var getterRead = ReflectionDelegateFactory.Default.CreateGetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.ReadOnly));
        var setterRead = ReflectionDelegateFactory.Default.CreateSetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.ReadOnly));

        Assert.Null(getterWrite);
        Assert.NotNull(setterWrite);
        Assert.NotNull(getterRead);
        Assert.Null(setterRead);
    }

    [Fact]
    public void TypedAccessClassProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.StringValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.StringValue))!;

        var data = new MemberData();

        setter(data, "abc");
        Assert.Equal("abc", getter(data));

        setter(data, null);
        Assert.Null(getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyInt()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.IntValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.IntValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal(1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyBool()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, bool>(nameof(MemberData.BoolValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, bool>(nameof(MemberData.BoolValue))!;

        var data = new MemberData();

        setter(data, true);
        Assert.True(getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyByte()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, byte>(nameof(MemberData.ByteValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, byte>(nameof(MemberData.ByteValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal((byte)1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyChar()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, char>(nameof(MemberData.CharValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, char>(nameof(MemberData.CharValue))!;

        var data = new MemberData();

        setter(data, (char)1);
        Assert.Equal((char)1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyShort()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, short>(nameof(MemberData.ShortValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, short>(nameof(MemberData.ShortValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal((short)1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyLong()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, long>(nameof(MemberData.LongValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, long>(nameof(MemberData.LongValue))!;

        var data = new MemberData();

        setter(data, 1L);
        Assert.Equal(1L, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyFloat()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, float>(nameof(MemberData.FloatValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, float>(nameof(MemberData.FloatValue))!;

        var data = new MemberData();

        setter(data, 1f);
        Assert.Equal(1f, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyDouble()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, double>(nameof(MemberData.DoubleValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, double>(nameof(MemberData.DoubleValue))!;

        var data = new MemberData();

        setter(data, 1d);
        Assert.Equal(1d, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyIntPtr()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, IntPtr>(nameof(MemberData.IntPtrValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, IntPtr>(nameof(MemberData.IntPtrValue))!;

        var data = new MemberData();

        setter(data, (IntPtr)1);
        Assert.Equal((IntPtr)1, getter(data));
    }

    [Fact]
    public void TypedAccessEnumProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.EnumValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.EnumValue))!;

        var data = new MemberData();

        setter(data, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(data));
    }

    [Fact]
    public void TypedAccessStructProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.StructValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.StructValue))!;

        var data = new MemberData();

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
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.NotificationStringValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.NotificationStringValue))!;

        var data = new MemberData();

        setter(data, "abc");
        Assert.Equal("abc", getter(data));

        setter(data, null);
        Assert.Null(getter(data));
    }

    [Fact]
    public void TypedAccessValueHolderValueTypeProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.NotificationIntValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.NotificationIntValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal(1, getter(data));
    }

    [Fact]
    public void TypedAccessValueHolderEnumProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.NotificationEnumValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.NotificationEnumValue))!;

        var data = new MemberData();

        setter(data, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(data));
    }

    [Fact]
    public void TypedAccessValueHolderStructProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.NotificationStructValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.NotificationStructValue))!;

        var data = new MemberData();

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
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.StaticStringValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.StaticStringValue))!;

        setter(null, "abc");
        Assert.Equal("abc", getter(null));

        setter(null, null);
        Assert.Null(getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueTypePropertyInt()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.StaticIntValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.StaticIntValue))!;

        setter(null, 1);
        Assert.Equal(1, getter(null));
    }

    [Fact]
    public void TypedAccessStaticEnumProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.StaticEnumValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.StaticEnumValue))!;

        setter(null, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(null));
    }

    [Fact]
    public void TypedAccessStaticStructProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.StaticStructValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.StaticStructValue))!;

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
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.StaticNotificationStringValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.StaticNotificationStringValue))!;

        setter(null, "abc");
        Assert.Equal("abc", getter(null));

        setter(null, null);
        Assert.Null(getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueHolderValueTypeProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.StaticNotificationIntValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.StaticNotificationIntValue))!;

        setter(null, 1);
        Assert.Equal(1, getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueHolderEnumProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.StaticNotificationEnumValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.StaticNotificationEnumValue))!;

        setter(null, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueHolderStructProperty()
    {
        var getter = ReflectionDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.StaticNotificationStructValue))!;
        var setter = ReflectionDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.StaticNotificationStructValue))!;

        setter(null, new MyStruct { X = 1, Y = 2 });
        var structValue = getter(null);
        Assert.Equal(1, structValue.X);
        Assert.Equal(2, structValue.Y);
    }
}
