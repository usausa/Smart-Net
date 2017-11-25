namespace Smart.Reflection
{
    using System;

    using Xunit;

    public class EmitMethodGeneratorTest
    {
        public class Data
        {
            public int IntValue { get; set; }

            public string StringValue { get; set; }
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

        [Fact]
        public void ActivateByDefaultConstructor()
        {
            var ctor = typeof(Data).GetConstructor(Type.EmptyTypes);
            var activator = EmitMethodGenerator.CreateActivator(ctor);

            var obj = activator.Create();

            Assert.NotNull(obj);
            Assert.Equal(typeof(Data), obj.GetType());
        }

        [Fact]
        public void ActivateWithArguments()
        {
            var ctor = typeof(Data2).GetConstructor(new[] { typeof(int), typeof(string) });
            var activator = EmitMethodGenerator.CreateActivator(ctor);

            var obj = (Data2)activator.Create(1, "abc");

            Assert.Equal(1, obj.IntValue);
            Assert.Equal("abc", obj.StringValue);
        }
    }
}
