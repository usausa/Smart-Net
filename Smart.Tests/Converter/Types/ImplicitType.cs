namespace Smart.Converter.Types
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Ignore")]
    public struct ImplicitType
    {
        public int Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Ignore")]
        public static implicit operator int(ImplicitType value)
        {
            return value.Value;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Ignore")]
        public static implicit operator ImplicitType(int value)
        {
            return new ImplicitType { Value = value };
        }
    }
}
