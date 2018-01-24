namespace Smart.Reflection
{
    using System.Linq;

    using Xunit;

    public class DelegateFactoryActivatorTest
    {
        [Fact]
        public void FactoryData0()
        {
            var factory = DelegateFactory.Default.CreateFactory(typeof(Data0).GetConstructors().First());

            var data = factory(null);
            Assert.NotNull(data);
        }

        [Fact]
        public void FactoryData1()
        {
            var factory = DelegateFactory.Default.CreateFactory(typeof(Data1).GetConstructors().First());

            var data = (Data1)factory(new object[] { 1 });
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
        }

        [Fact]
        public void FactoryData9()
        {
            var factory = DelegateFactory.Default.CreateFactory(typeof(Data9).GetConstructors().First());

            var data = (Data9)factory(new object[] { 1, "2", 3, "4", 5, "6", 7, "8", 9 });
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
        public void Factory0()
        {
            var factory = DelegateFactory.Default.CreateFactory0(typeof(Data0).GetConstructors().First());

            var data = factory();
            Assert.NotNull(data);
        }

        [Fact]
        public void Factory1()
        {
            var factory = DelegateFactory.Default.CreateFactory1(typeof(Data1).GetConstructors().First());

            var data = (Data1)factory(1);
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
        }

        [Fact]
        public void Factory2()
        {
            var factory = DelegateFactory.Default.CreateFactory2(typeof(Data2).GetConstructors().First());

            var data = (Data2)factory(1, "2");
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
            Assert.Equal("2", data.Param2);
        }

        [Fact]
        public void Factory3()
        {
            var factory = DelegateFactory.Default.CreateFactory3(typeof(Data3).GetConstructors().First());

            var data = (Data3)factory(1, "2", 3);
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
            Assert.Equal("2", data.Param2);
            Assert.Equal(3, data.Param3);
        }

        [Fact]
        public void Factory4()
        {
            var factory = DelegateFactory.Default.CreateFactory4(typeof(Data4).GetConstructors().First());

            var data = (Data4)factory(1, "2", 3, "4");
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
            Assert.Equal("2", data.Param2);
            Assert.Equal(3, data.Param3);
            Assert.Equal("4", data.Param4);
        }

        [Fact]
        public void Factory5()
        {
            var factory = DelegateFactory.Default.CreateFactory5(typeof(Data5).GetConstructors().First());

            var data = (Data5)factory(1, "2", 3, "4", 5);
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
            Assert.Equal("2", data.Param2);
            Assert.Equal(3, data.Param3);
            Assert.Equal("4", data.Param4);
            Assert.Equal(5, data.Param5);
        }

        [Fact]
        public void Factory6()
        {
            var factory = DelegateFactory.Default.CreateFactory6(typeof(Data6).GetConstructors().First());

            var data = (Data6)factory(1, "2", 3, "4", 5, "6");
            Assert.NotNull(data);
            Assert.Equal(1, data.Param1);
            Assert.Equal("2", data.Param2);
            Assert.Equal(3, data.Param3);
            Assert.Equal("4", data.Param4);
            Assert.Equal(5, data.Param5);
            Assert.Equal("6", data.Param6);
        }

        [Fact]
        public void Factory7()
        {
            var factory = DelegateFactory.Default.CreateFactory7(typeof(Data7).GetConstructors().First());

            var data = (Data7)factory(1, "2", 3, "4", 5, "6", 7);
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
        public void Factory8()
        {
            var factory = DelegateFactory.Default.CreateFactory8(typeof(Data8).GetConstructors().First());

            var data = (Data8)factory(1, "2", 3, "4", 5, "6", 7, "8");
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
    }
}