namespace Smart.Converter.Types
{
    using System;
    using System.Globalization;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Ignore")]
    public struct StructType
    {
        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "({0}, {1})", Value1, Value2);
        }
    }
}
