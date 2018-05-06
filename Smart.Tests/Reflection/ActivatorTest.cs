//namespace Smart.Reflection
//{
//    using System.Linq;

//    using Xunit;

//    public class ActivatorTest
//    {
//        public class Data0
//        {
//        }

//        public class Data1
//        {
//            public int Param1 { get; }

//            public Data1(int p1)
//            {
//                Param1 = p1;
//            }
//        }

//        public class Data2
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public Data2(int p1, string p2)
//            {
//                Param1 = p1;
//                Param2 = p2;
//            }
//        }

//        public class Data3
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public int Param3 { get; }

//            public Data3(int p1, string p2, int p3)
//            {
//                Param1 = p1;
//                Param2 = p2;
//                Param3 = p3;
//            }
//        }

//        public class Data4
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public int Param3 { get; }

//            public string Param4 { get; }

//            public Data4(int p1, string p2, int p3, string p4)
//            {
//                Param1 = p1;
//                Param2 = p2;
//                Param3 = p3;
//                Param4 = p4;
//            }
//        }

//        public class Data5
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public int Param3 { get; }

//            public string Param4 { get; }

//            public int Param5 { get; }

//            public Data5(int p1, string p2, int p3, string p4, int p5)
//            {
//                Param1 = p1;
//                Param2 = p2;
//                Param3 = p3;
//                Param4 = p4;
//                Param5 = p5;
//            }
//        }

//        public class Data6
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public int Param3 { get; }

//            public string Param4 { get; }

//            public int Param5 { get; }

//            public string Param6 { get; }

//            public Data6(int p1, string p2, int p3, string p4, int p5, string p6)
//            {
//                Param1 = p1;
//                Param2 = p2;
//                Param3 = p3;
//                Param4 = p4;
//                Param5 = p5;
//                Param6 = p6;
//            }
//        }

//        public class Data7
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public int Param3 { get; }

//            public string Param4 { get; }

//            public int Param5 { get; }

//            public string Param6 { get; }

//            public int Param7 { get; }

//            public Data7(int p1, string p2, int p3, string p4, int p5, string p6, int p7)
//            {
//                Param1 = p1;
//                Param2 = p2;
//                Param3 = p3;
//                Param4 = p4;
//                Param5 = p5;
//                Param6 = p6;
//                Param7 = p7;
//            }
//        }

//        public class Data8
//        {
//            public int Param1 { get; }

//            public string Param2 { get; }

//            public int Param3 { get; }

//            public string Param4 { get; }

//            public int Param5 { get; }

//            public string Param6 { get; }

//            public int Param7 { get; }

//            public string Param8 { get; }

//            public Data8(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8)
//            {
//                Param1 = p1;
//                Param2 = p2;
//                Param3 = p3;
//                Param4 = p4;
//                Param5 = p5;
//                Param6 = p6;
//                Param7 = p7;
//                Param8 = p8;
//            }
//        }

//        //--------------------------------------------------------------------------------
//        // Emit
//        //--------------------------------------------------------------------------------

//        [Fact]
//        public void Activator0CreatedByEmit()
//        {
//            var ctor = typeof(Data0).GetConstructors().First();
//            var activator0 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator0>(ctor);

//            var data = activator0.Create();
//            Assert.NotNull(data);
//        }

//        [Fact]
//        public void Activator1CreatedByEmit()
//        {
//            var ctor = typeof(Data1).GetConstructors().First();
//            var activator1 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator1>(ctor);

//            var data = (Data1)activator1.Create(1);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//        }

//        [Fact]
//        public void Activator2CreatedByEmit()
//        {
//            var ctor = typeof(Data2).GetConstructors().First();
//            var activator2 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator2>(ctor);

//            var data = (Data2)activator2.Create(1, "2");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//        }

//        [Fact]
//        public void Activator3CreatedByEmit()
//        {
//            var ctor = typeof(Data3).GetConstructors().First();
//            var activator3 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator3>(ctor);

//            var data = (Data3)activator3.Create(1, "2", 3);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//        }

//        [Fact]
//        public void Activator4CreatedByEmit()
//        {
//            var ctor = typeof(Data4).GetConstructors().First();
//            var activator4 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator4>(ctor);

//            var data = (Data4)activator4.Create(1, "2", 3, "4");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//        }

//        [Fact]
//        public void Activator5CreatedByEmit()
//        {
//            var ctor = typeof(Data5).GetConstructors().First();
//            var activator5 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator5>(ctor);

//            var data = (Data5)activator5.Create(1, "2", 3, "4", 5);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//        }

//        [Fact]
//        public void Activator6CreatedByEmit()
//        {
//            var ctor = typeof(Data6).GetConstructors().First();
//            var activator6 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator6>(ctor);

//            var data = (Data6)activator6.Create(1, "2", 3, "4", 5, "6");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//            Assert.Equal("6", data.Param6);
//        }

//        [Fact]
//        public void Activator7CreatedByEmit()
//        {
//            var ctor = typeof(Data7).GetConstructors().First();
//            var activator7 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator7>(ctor);

//            var data = (Data7)activator7.Create(1, "2", 3, "4", 5, "6", 7);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//            Assert.Equal("6", data.Param6);
//            Assert.Equal(7, data.Param7);
//        }

//        [Fact]
//        public void Activator8CreatedByEmit()
//        {
//            var ctor = typeof(Data8).GetConstructors().First();
//            var activator8 = EmitTypeMetadataFactory.Default.CreateActivator<IActivator8>(ctor);

//            var data = (Data8)activator8.Create(1, "2", 3, "4", 5, "6", 7, "8");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//            Assert.Equal("6", data.Param6);
//            Assert.Equal(7, data.Param7);
//            Assert.Equal("8", data.Param8);
//        }

//        //--------------------------------------------------------------------------------
//        // Reflection
//        //--------------------------------------------------------------------------------

//        [Fact]
//        public void Activator0CreatedByReflection()
//        {
//            var ctor = typeof(Data0).GetConstructors().First();
//            var activator0 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator0>(ctor);

//            var data = activator0.Create();
//            Assert.NotNull(data);
//        }

//        [Fact]
//        public void Activator1CreatedByReflection()
//        {
//            var ctor = typeof(Data1).GetConstructors().First();
//            var activator1 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator1>(ctor);

//            var data = (Data1)activator1.Create(1);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//        }

//        [Fact]
//        public void Activator2CreatedByReflection()
//        {
//            var ctor = typeof(Data2).GetConstructors().First();
//            var activator2 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator2>(ctor);

//            var data = (Data2)activator2.Create(1, "2");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//        }

//        [Fact]
//        public void Activator3CreatedByReflection()
//        {
//            var ctor = typeof(Data3).GetConstructors().First();
//            var activator3 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator3>(ctor);

//            var data = (Data3)activator3.Create(1, "2", 3);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//        }

//        [Fact]
//        public void Activator4CreatedByReflection()
//        {
//            var ctor = typeof(Data4).GetConstructors().First();
//            var activator4 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator4>(ctor);

//            var data = (Data4)activator4.Create(1, "2", 3, "4");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//        }

//        [Fact]
//        public void Activator5CreatedByReflection()
//        {
//            var ctor = typeof(Data5).GetConstructors().First();
//            var activator5 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator5>(ctor);

//            var data = (Data5)activator5.Create(1, "2", 3, "4", 5);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//        }

//        [Fact]
//        public void Activator6CreatedByReflection()
//        {
//            var ctor = typeof(Data6).GetConstructors().First();
//            var activator6 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator6>(ctor);

//            var data = (Data6)activator6.Create(1, "2", 3, "4", 5, "6");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//            Assert.Equal("6", data.Param6);
//        }

//        [Fact]
//        public void Activator7CreatedByReflection()
//        {
//            var ctor = typeof(Data7).GetConstructors().First();
//            var activator7 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator7>(ctor);

//            var data = (Data7)activator7.Create(1, "2", 3, "4", 5, "6", 7);
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//            Assert.Equal("6", data.Param6);
//            Assert.Equal(7, data.Param7);
//        }

//        [Fact]
//        public void Activator8CreatedByReflection()
//        {
//            var ctor = typeof(Data8).GetConstructors().First();
//            var activator8 = ReflectionTypeMetadataFactory.Default.CreateActivator<IActivator8>(ctor);

//            var data = (Data8)activator8.Create(1, "2", 3, "4", 5, "6", 7, "8");
//            Assert.NotNull(data);
//            Assert.Equal(1, data.Param1);
//            Assert.Equal("2", data.Param2);
//            Assert.Equal(3, data.Param3);
//            Assert.Equal("4", data.Param4);
//            Assert.Equal(5, data.Param5);
//            Assert.Equal("6", data.Param6);
//            Assert.Equal(7, data.Param7);
//            Assert.Equal("8", data.Param8);
//        }
//    }
//}
