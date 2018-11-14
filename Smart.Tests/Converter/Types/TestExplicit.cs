namespace Smart.Converter.Types
{
    public struct TestExplicit
    {
        public int Value { get; set; }

        public static explicit operator int(TestExplicit value)
        {
            return value.Value;
        }

        public static explicit operator TestExplicit(int value)
        {
            return new TestExplicit { Value = value };
        }
    }

    public struct TestNullableExplicit
    {
        public int? Value { get; set; }

        public static explicit operator int?(TestNullableExplicit value)
        {
            return value.Value;
        }

        public static explicit operator TestNullableExplicit(int? value)
        {
            return new TestNullableExplicit { Value = value };
        }
    }
}
