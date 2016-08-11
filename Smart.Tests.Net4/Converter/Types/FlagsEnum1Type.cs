namespace Smart.Converter.Types
{
    using System;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", Justification = "Ignore")]
    [Flags]
    public enum FlagsEnum1Type
    {
        None,
        Value1 = 0x01,
        Value2 = 0x02,
        Value4 = 0x04
    }
}
