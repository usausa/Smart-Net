namespace Smart.Reflection;

using Xunit;

public sealed class ReflectionDelegateFactoryTypedFactoryTest
{
    [Fact]
    public void FactoryStruct()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, int, StructWithConstructor>();

        var data = factory(1, 2);
        Assert.Equal(1, data.X);
        Assert.Equal(2, data.Y);
    }

    [Fact]
    public void TypedFactoryData0()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<Data0>();

        var data = factory();
        Assert.NotNull(data);
    }

    [Fact]
    public void TypedFactoryData1()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, Data1>();

        var data = factory(1);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
    }

    [Fact]
    public void TypedFactoryData2()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, Data2>();

        var data = factory(1, "2");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
    }

    [Fact]
    public void TypedFactoryData3()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, Data3>();

        var data = factory(1, "2", 3);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
    }

    [Fact]
    public void TypedFactoryData4()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, Data4>();

        var data = factory(1, "2", 3, "4");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
    }

    [Fact]
    public void TypedFactoryData5()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, Data5>();

        var data = factory(1, "2", 3, "4", 5);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
    }

    [Fact]
    public void TypedFactoryData6()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, Data6>();

        var data = factory(1, "2", 3, "4", 5, "6");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
    }

    [Fact]
    public void TypedFactoryData7()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, Data7>();

        var data = factory(1, "2", 3, "4", 5, "6", 7);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
    }

    [Fact]
    public void TypedFactoryData8()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, Data8>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
    }

    [Fact]
    public void TypedFactoryData9()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, Data9>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
    }

    [Fact]
    public void TypedFactoryData10()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, Data10>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
    }

    [Fact]
    public void TypedFactoryData11()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, int, Data11>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10", 11);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
        Assert.Equal(11, data.Param11);
    }

    [Fact]
    public void TypedFactoryData12()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, int, string, Data12>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10", 11, "12");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
        Assert.Equal(11, data.Param11);
        Assert.Equal("12", data.Param12);
    }

    [Fact]
    public void TypedFactoryData13()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, int, string, int, Data13>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10", 11, "12", 13);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
        Assert.Equal(11, data.Param11);
        Assert.Equal("12", data.Param12);
        Assert.Equal(13, data.Param13);
    }

    [Fact]
    public void TypedFactoryData14()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, int, string, int, string, Data14>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10", 11, "12", 13, "14");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
        Assert.Equal(11, data.Param11);
        Assert.Equal("12", data.Param12);
        Assert.Equal(13, data.Param13);
        Assert.Equal("14", data.Param14);
    }

    [Fact]
    public void TypedFactoryData15()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, int, string, int, string, int, Data15>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10", 11, "12", 13, "14", 15);
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
        Assert.Equal(11, data.Param11);
        Assert.Equal("12", data.Param12);
        Assert.Equal(13, data.Param13);
        Assert.Equal("14", data.Param14);
        Assert.Equal(15, data.Param15);
    }

    [Fact]
    public void TypedFactoryData16()
    {
        var factory = ReflectionDelegateFactory.Default.CreateFactory<int, string, int, string, int, string, int, string, int, string, int, string, int, string, int, string, Data16>();

        var data = factory(1, "2", 3, "4", 5, "6", 7, "8", 9, "10", 11, "12", 13, "14", 15, "16");
        Assert.NotNull(data);
        Assert.Equal(1, data.Param1);
        Assert.Equal("2", data.Param2);
        Assert.Equal(3, data.Param3);
        Assert.Equal("4", data.Param4);
        Assert.Equal(5, data.Param5);
        Assert.Equal("6", data.Param6);
        Assert.Equal(7, data.Param7);
        Assert.Equal("8", data.Param8);
        Assert.Equal(9, data.Param9);
        Assert.Equal("10", data.Param10);
        Assert.Equal(11, data.Param11);
        Assert.Equal("12", data.Param12);
        Assert.Equal(13, data.Param13);
        Assert.Equal("14", data.Param14);
        Assert.Equal(15, data.Param15);
        Assert.Equal("16", data.Param16);
    }
}
