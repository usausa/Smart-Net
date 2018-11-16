namespace Smart.Converter.Types
{
    public struct ExplicitType
    {
        public int Value { get; set; }

        public static explicit operator int(ExplicitType value)
        {
            return value.Value;
        }

        public static explicit operator ExplicitType(int value)
        {
            return new ExplicitType { Value = value };
        }
    }

    public struct NullableExplicitType
    {
        public int? Value { get; set; }

        public static explicit operator int?(NullableExplicitType value)
        {
            return value.Value;
        }

        public static explicit operator NullableExplicitType(int? value)
        {
            return new NullableExplicitType { Value = value };
        }
    }
}
