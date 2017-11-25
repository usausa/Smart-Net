namespace Smart.Reflection
{
    using System;

    using Smart.ComponentModel;

    using Xunit;

    public class EmitMethodGeneratorTest
    {
        public class Data
        {
            public int IntValue { get; set; }

            public string StringValue { get; set; }

            public IValueHolder<int> NotificationIntValue { get; } = new NotificationValue<int>();

            public IValueHolder<string> NotificationStringValue { get; } = new NotificationValue<string>();
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

        //--------------------------------------------------------------------------------
        // Accessor
        //--------------------------------------------------------------------------------

        [Fact]
        public void AccessClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.StringValue));
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

            var data = new Data();

            accessor.SetValue(data, "abc");
            Assert.Equal("abc", accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Null(accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueTypeProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.IntValue));
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

            var data = new Data();

            accessor.SetValue(data, 1);
            Assert.Equal(1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0, accessor.GetValue(data));
        }

        [Fact]
        public void AccessValueHolderClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationStringValue));
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

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
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

            var data = new Data();

            accessor.SetValue(data, 1);
            Assert.Equal(1, accessor.GetValue(data));

            accessor.SetValue(data, null);
            Assert.Equal(0, accessor.GetValue(data));
        }
    }
}
