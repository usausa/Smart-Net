﻿namespace Smart.Reflection
{
    using System;

    using Smart.ComponentModel;

    using Xunit;

    public class EmitMethodGeneratorTest
    {
        public enum MyEnum
        {
            Zero, One, Two
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

            Assert.Equal(ctor, activator.Source);

            var obj = activator.Create();

            Assert.NotNull(obj);
            Assert.Equal(typeof(Data), obj.GetType());
        }

        [Fact]
        public void ActivateWithArguments()
        {
            var ctor = typeof(Data2).GetConstructor(new[] { typeof(int), typeof(string) });
            var activator = EmitMethodGenerator.CreateActivator(ctor);

            Assert.Equal(ctor, activator.Source);

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
        public void AccessValueTypeProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.IntValue));
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

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
        public void AccessValueHolderClassProperty()
        {
            var pi = typeof(Data).GetProperty(nameof(Data.NotificationStringValue));
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

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
            var accessor = EmitMethodGenerator.CreateAccessor(pi);

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
    }
}
