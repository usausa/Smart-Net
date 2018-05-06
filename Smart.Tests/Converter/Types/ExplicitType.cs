namespace Smart.Converter.Types
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Ignore")]
    public struct ExplicitType
    {
        public int Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Ignore")]
        public static explicit operator int(ExplicitType value)
        {
            return value.Value;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Ignore")]
        public static explicit operator ExplicitType(int value)
        {
            return new ExplicitType { Value = value };
        }
    }
}
