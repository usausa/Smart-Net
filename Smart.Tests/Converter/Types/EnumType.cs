namespace Smart.Converter.Types
{
    using System;

    public enum Enum1Type
    {
        Zero,
        One,
        Two
    }

    public enum Enum2Type
    {
        Zero,
        One,
        Minus = -1
    }

    [Flags]
    public enum FlagsEnum1Type
    {
        None,
        Value1 = 0x01,
        Value2 = 0x02,
        Value4 = 0x04
    }

    [Flags]
    public enum FlagsEnum2Type
    {
        None,
        Value1 = 0x01,
        Value2 = 0x02,
        Value8 = 0x08
    }
}
