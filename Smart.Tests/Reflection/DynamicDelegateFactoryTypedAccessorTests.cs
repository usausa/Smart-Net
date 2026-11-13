namespace Smart.Reflection;

public sealed class DynamicDelegateFactoryTypedAccessorTests
{
    //--------------------------------------------------------------------------------
    // Non static
    //--------------------------------------------------------------------------------

    [Fact]
    public void TypedAccessReadWriteOnly()
    {
        var getterWrite = DynamicDelegateFactory.Default.CreateGetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.WriteOnly));
        var setterWrite = DynamicDelegateFactory.Default.CreateSetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.WriteOnly));
        var getterRead = DynamicDelegateFactory.Default.CreateGetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.ReadOnly));
        var setterRead = DynamicDelegateFactory.Default.CreateSetter<ReadWriteOnlyData, string>(nameof(ReadWriteOnlyData.ReadOnly));

        Assert.Null(getterWrite);
        Assert.NotNull(setterWrite);
        Assert.NotNull(getterRead);
        Assert.Null(setterRead);
    }

    [Fact]
    public void TypedAccessClassProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.StringValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.StringValue))!;

        var data = new MemberData();

        setter(data, "abc");
        Assert.Equal("abc", getter(data));

        setter(data, null);
        Assert.Null(getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyInt()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.IntValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.IntValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal(1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyBool()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, bool>(nameof(MemberData.BoolValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, bool>(nameof(MemberData.BoolValue))!;

        var data = new MemberData();

        setter(data, true);
        Assert.True(getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyByte()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, byte>(nameof(MemberData.ByteValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, byte>(nameof(MemberData.ByteValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal((byte)1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyChar()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, char>(nameof(MemberData.CharValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, char>(nameof(MemberData.CharValue))!;

        var data = new MemberData();

        setter(data, (char)1);
        Assert.Equal((char)1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyShort()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, short>(nameof(MemberData.ShortValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, short>(nameof(MemberData.ShortValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal((short)1, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyLong()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, long>(nameof(MemberData.LongValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, long>(nameof(MemberData.LongValue))!;

        var data = new MemberData();

        setter(data, 1L);
        Assert.Equal(1L, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyFloat()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, float>(nameof(MemberData.FloatValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, float>(nameof(MemberData.FloatValue))!;

        var data = new MemberData();

        setter(data, 1f);
        Assert.Equal(1f, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyDouble()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, double>(nameof(MemberData.DoubleValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, double>(nameof(MemberData.DoubleValue))!;

        var data = new MemberData();

        setter(data, 1d);
        Assert.Equal(1d, getter(data));
    }

    [Fact]
    public void TypedAccessValueTypePropertyIntPtr()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, IntPtr>(nameof(MemberData.IntPtrValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, IntPtr>(nameof(MemberData.IntPtrValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal(1, getter(data));
    }

    [Fact]
    public void TypedAccessEnumProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.EnumValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.EnumValue))!;

        var data = new MemberData();

        setter(data, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(data));
    }

    [Fact]
    public void TypedAccessStructProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.StructValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.StructValue))!;

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
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.NotificationStringValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.NotificationStringValue))!;

        var data = new MemberData();

        setter(data, "abc");
        Assert.Equal("abc", getter(data));

        setter(data, null);
        Assert.Null(getter(data));
    }

    [Fact]
    public void TypedAccessValueHolderValueTypeProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.NotificationIntValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.NotificationIntValue))!;

        var data = new MemberData();

        setter(data, 1);
        Assert.Equal(1, getter(data));
    }

    [Fact]
    public void TypedAccessValueHolderEnumProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.NotificationEnumValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.NotificationEnumValue))!;

        var data = new MemberData();

        setter(data, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(data));
    }

    [Fact]
    public void TypedAccessValueHolderStructProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.NotificationStructValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.NotificationStructValue))!;

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
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.StaticStringValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.StaticStringValue))!;

        setter(null, "abc");
        Assert.Equal("abc", getter(null));

        setter(null, null);
        Assert.Null(getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueTypePropertyInt()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.StaticIntValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.StaticIntValue))!;

        setter(null, 1);
        Assert.Equal(1, getter(null));
    }

    [Fact]
    public void TypedAccessStaticEnumProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.StaticEnumValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.StaticEnumValue))!;

        setter(null, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(null));
    }

    [Fact]
    public void TypedAccessStaticStructProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.StaticStructValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.StaticStructValue))!;

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
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, string>(nameof(MemberData.StaticNotificationStringValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, string>(nameof(MemberData.StaticNotificationStringValue))!;

        setter(null, "abc");
        Assert.Equal("abc", getter(null));

        setter(null, null);
        Assert.Null(getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueHolderValueTypeProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, int>(nameof(MemberData.StaticNotificationIntValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, int>(nameof(MemberData.StaticNotificationIntValue))!;

        setter(null, 1);
        Assert.Equal(1, getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueHolderEnumProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyEnum>(nameof(MemberData.StaticNotificationEnumValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyEnum>(nameof(MemberData.StaticNotificationEnumValue))!;

        setter(null, MyEnum.One);
        Assert.Equal(MyEnum.One, getter(null));
    }

    [Fact]
    public void TypedAccessStaticValueHolderStructProperty()
    {
        var getter = DynamicDelegateFactory.Default.CreateGetter<MemberData, MyStruct>(nameof(MemberData.StaticNotificationStructValue))!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<MemberData, MyStruct>(nameof(MemberData.StaticNotificationStructValue))!;

        setter(null, new MyStruct { X = 1, Y = 2 });
        var structValue = getter(null);
        Assert.Equal(1, structValue.X);
        Assert.Equal(2, structValue.Y);
    }

    //--------------------------------------------------------------------------------
    // Target type
    //--------------------------------------------------------------------------------

    [Fact]
    public void TypedGetterIsCreatedForEachTargetType()
    {
        var pi = typeof(TypedAccessorData).GetProperty(nameof(TypedAccessorData.Value))!;
        var typedGetter = DynamicDelegateFactory.Default.CreateGetter<TypedAccessorData, int>(pi)!;
        var objectGetter = DynamicDelegateFactory.Default.CreateGetter<object, int>(pi)!;

        Assert.Equal(1, typedGetter(new TypedAccessorData { Value = 1 }));
        Assert.Equal(2, objectGetter(new TypedAccessorData { Value = 2 }));
        Assert.Throws<InvalidCastException>(() => objectGetter(new TypedAccessorOtherData()));
    }

    [Fact]
    public void TypedSetterIsCreatedForEachTargetType()
    {
        var pi = typeof(TypedAccessorData).GetProperty(nameof(TypedAccessorData.Value))!;
        var typedSetter = DynamicDelegateFactory.Default.CreateSetter<TypedAccessorData, int>(pi)!;
        var objectSetter = DynamicDelegateFactory.Default.CreateSetter<object, int>(pi)!;

        var data = new TypedAccessorData();
        typedSetter(data, 1);
        Assert.Equal(1, data.Value);
        objectSetter(data, 2);
        Assert.Equal(2, data.Value);
        Assert.Throws<InvalidCastException>(() => objectSetter(new TypedAccessorOtherData(), 3));
    }

    [Fact]
    public void TypedAccessorCastsBaseTargetType()
    {
        var pi = typeof(TypedAccessorData).GetProperty(nameof(TypedAccessorData.Value))!;
        var getter = DynamicDelegateFactory.Default.CreateGetter<TypedAccessorBaseData, int>(pi)!;
        var setter = DynamicDelegateFactory.Default.CreateSetter<TypedAccessorBaseData, int>(pi)!;

        var data = new TypedAccessorData();
        setter(data, 3);
        Assert.Equal(3, getter(data));
        Assert.Throws<InvalidCastException>(() => getter(new TypedAccessorBaseData()));
        Assert.Throws<InvalidCastException>(() => setter(new TypedAccessorBaseData(), 4));
    }

    [Fact]
    public void TypedAccessorFromCacheRejectsOtherMemberType()
    {
        var pi = typeof(TypedAccessorTextData).GetProperty(nameof(TypedAccessorTextData.Text))!;
        var getter = DynamicDelegateFactory.Default.CreateGetter<TypedAccessorTextData, string>(pi);
        var setter = DynamicDelegateFactory.Default.CreateSetter<TypedAccessorTextData, string>(pi);

        Assert.Same(getter, DynamicDelegateFactory.Default.CreateGetter<TypedAccessorTextData, string>(pi));
        Assert.Same(setter, DynamicDelegateFactory.Default.CreateSetter<TypedAccessorTextData, string>(pi));
        Assert.Throws<ArgumentException>(() => DynamicDelegateFactory.Default.CreateGetter<TypedAccessorTextData, object>(pi));
        Assert.Throws<ArgumentException>(() => DynamicDelegateFactory.Default.CreateSetter<TypedAccessorTextData, object>(pi));
        Assert.Throws<ArgumentException>(() => DynamicDelegateFactory.Default.CreateGetter<TypedAccessorTextData, int>(pi));
    }

    [Fact]
    public void AccessorFromCacheDoesNotAllocate()
    {
        var pi = typeof(TypedAccessorData).GetProperty(nameof(TypedAccessorData.Value))!;
        var factory = DynamicDelegateFactory.Default;
        _ = factory.CreateGetter(pi);
        _ = factory.CreateSetter(pi);
        _ = factory.CreateGetter<TypedAccessorData, int>(pi);
        _ = factory.CreateSetter<TypedAccessorData, int>(pi);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            _ = factory.CreateGetter(pi);
            _ = factory.CreateSetter(pi);
            _ = factory.CreateGetter<TypedAccessorData, int>(pi);
            _ = factory.CreateSetter<TypedAccessorData, int>(pi);
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);
    }
}
