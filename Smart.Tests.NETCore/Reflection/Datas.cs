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

    public class Data
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

        public string WriteOnly { set => str = value; }

        public string ReadOnly => str;
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

    public class Data2
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public Data2(int p1, string p2)
        {
            Param1 = p1;
            Param2 = p2;
        }
    }

    public class Data3
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public Data3(int p1, string p2, int p3)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
        }
    }

    public class Data4
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public string Param4 { get; }

        public Data4(int p1, string p2, int p3, string p4)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
            Param4 = p4;
        }
    }

    public class Data5
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public string Param4 { get; }

        public int Param5 { get; }

        public Data5(int p1, string p2, int p3, string p4, int p5)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
            Param4 = p4;
            Param5 = p5;
        }
    }

    public class Data6
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public string Param4 { get; }

        public int Param5 { get; }

        public string Param6 { get; }

        public Data6(int p1, string p2, int p3, string p4, int p5, string p6)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
            Param4 = p4;
            Param5 = p5;
            Param6 = p6;
        }
    }

    public class Data7
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public string Param4 { get; }

        public int Param5 { get; }

        public string Param6 { get; }

        public int Param7 { get; }

        public Data7(int p1, string p2, int p3, string p4, int p5, string p6, int p7)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
            Param4 = p4;
            Param5 = p5;
            Param6 = p6;
            Param7 = p7;
        }
    }

    public class Data8
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public string Param4 { get; }

        public int Param5 { get; }

        public string Param6 { get; }

        public int Param7 { get; }

        public string Param8 { get; }

        public Data8(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
            Param4 = p4;
            Param5 = p5;
            Param6 = p6;
            Param7 = p7;
            Param8 = p8;
        }
    }

    public class Data9
    {
        public int Param1 { get; }

        public string Param2 { get; }

        public int Param3 { get; }

        public string Param4 { get; }

        public int Param5 { get; }

        public string Param6 { get; }

        public int Param7 { get; }

        public string Param8 { get; }

        public int Param9 { get; }

        public Data9(int p1, string p2, int p3, string p4, int p5, string p6, int p7, string p8, int p9)
        {
            Param1 = p1;
            Param2 = p2;
            Param3 = p3;
            Param4 = p4;
            Param5 = p5;
            Param6 = p6;
            Param7 = p7;
            Param8 = p8;
            Param9 = p9;
        }
    }
}
