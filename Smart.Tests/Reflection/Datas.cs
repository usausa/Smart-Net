// ReSharper disable MemberCanBeProtected.Global
namespace Smart.Reflection
{
    using System;

    using Smart.ComponentModel;

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

    public struct StructWithConstructor
    {
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public int X { get; set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public int Y { get; set; }

        public StructWithConstructor(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class MemberData
    {
        public string StringValue { get; set; }

        public int IntValue { get; set; }

        public bool BoolValue { get; set; }

        public byte ByteValue { get; set; }

        public char CharValue { get; set; }

        public short ShortValue { get; set; }

        public long LongValue { get; set; }

        public float FloatValue { get; set; }

        public double DoubleValue { get; set; }

        public IntPtr IntPtrValue { get; set; }

        public MyEnum EnumValue { get; set; }

        public MyStruct StructValue { get; set; }

        public int? NullableIntValue { get; set; }

        public MyEnum? NullableEnumValue { get; set; }

        public MyStruct? NullableStructValue { get; set; }

        public IValueHolder<string> NotificationStringValue { get; } = new NotificationValue<string>();

        public IValueHolder<int> NotificationIntValue { get; } = new NotificationValue<int>();

        public IValueHolder<MyEnum> NotificationEnumValue { get; } = new NotificationValue<MyEnum>();

        public IValueHolder<MyStruct> NotificationStructValue { get; } = new NotificationValue<MyStruct>();

        // static

        public static string StaticStringValue { get; set; }

        public static int StaticIntValue { get; set; }

        public static MyEnum StaticEnumValue { get; set; }

        public static MyStruct StaticStructValue { get; set; }

        public static IValueHolder<string> StaticNotificationStringValue { get; } = new NotificationValue<string>();

        public static IValueHolder<int> StaticNotificationIntValue { get; } = new NotificationValue<int>();

        public static IValueHolder<MyEnum> StaticNotificationEnumValue { get; } = new NotificationValue<MyEnum>();

        public static IValueHolder<MyStruct> StaticNotificationStructValue { get; } = new NotificationValue<MyStruct>();
    }

    internal class InternalData
    {
    }

    public class ReadWriteOnlyData
    {
        private string str;

        private void Set(string value) => str = value;

        private string Get() => str;

        public string WriteOnly { set => Set(value); }

        public string ReadOnly => Get();
    }

    public class Struct0
    {
    }

    public class Struct1
    {
        public int Param1 { get; }

        public Struct1(int p1)
        {
            Param1 = p1;
        }
    }

    public class Data0
    {
    }

    public class Data1
    {
        public int Param1 { get; }

        public Data1(int p1)
        {
            Param1 = p1;
        }
    }

    public class Data2 : Data1
    {
        public string Param2 { get; }

        public Data2(int p1, string p2)
            : base(p1)
        {
            Param2 = p2;
        }
    }

    public class Data3 : Data2
    {
        public int Param3 { get; }

        public Data3(int p1, string p2, int p3)
            : base(p1, p2)
        {
            Param3 = p3;
        }
    }

    public class Data4 : Data3
    {
        public string Param4 { get; }

        public Data4(int p1, string p2, int p3, string p4)
            : base(p1, p2, p3)
        {
            Param4 = p4;
        }
    }

    public class Data5 : Data4
    {
        public int Param5 { get; }

        public Data5(int p1, string p2, int p3, string p4, int p5)
            : base(p1, p2, p3, p4)
        {
            Param5 = p5;
        }
    }

    public class Data6 : Data5
    {
        public string Param6 { get; }

        public Data6(int p1, string p2, int p3, string p4, int p5, string p6)
            : base(p1, p2, p3, p4, p5)
        {
            Param6 = p6;
        }
    }

    public class Data7 : Data6
    {
        public int Param7 { get; }

        public Data7(int p1, string p2, int p3, string p4, int p5, string p6, int p7)
            : base(p1, p2, p3, p4, p5, p6)
        {
            Param7 = p7;
        }
    }

    public class Data8 : Data7
    {
        public string Param8 { get; }

        public Data8(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8)
            : base(p1, p2, p3, p4, p5, p6, p7)
        {
            Param8 = p8;
        }
    }

    public class Data9 : Data8
    {
        public int Param9 { get; }

        public Data9(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9)
            : base(p1, p2, p3, p4, p5, p6, p7, p8)
        {
            Param9 = p9;
        }
    }

    public class Data10 : Data9
    {
        public string Param10 { get; }

        public Data10(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9)
        {
            Param10 = p10;
        }
    }

    public class Data11 : Data10
    {
        public int Param11 { get; }

        public Data11(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10)
        {
            Param11 = p11;
        }
    }

    public class Data12 : Data11
    {
        public string Param12 { get; }

        public Data12(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11, string p12)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11)
        {
            Param12 = p12;
        }
    }

    public class Data13 : Data12
    {
        public int Param13 { get; }

        public Data13(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11, string p12, int p13)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12)
        {
            Param13 = p13;
        }
    }

    public class Data14 : Data13
    {
        public string Param14 { get; }

        public Data14(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11, string p12, int p13, string p14)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13)
        {
            Param14 = p14;
        }
    }

    public class Data15 : Data14
    {
        public int Param15 { get; }

        public Data15(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11, string p12, int p13, string p14, int p15)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14)
        {
            Param15 = p15;
        }
    }

    public class Data16 : Data15
    {
        public string Param16 { get; }

        public Data16(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11, string p12, int p13, string p14, int p15, string p16)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15)
        {
            Param16 = p16;
        }
    }

    public class Data17 : Data16
    {
        public int Param17 { get; }

        public Data17(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9, string p10, int p11, string p12, int p13, string p14, int p15, string p16, int p17)
            : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16)
        {
            Param17 = p17;
        }
    }
}
