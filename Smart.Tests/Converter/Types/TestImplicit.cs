namespace Smart.Converter.Types
{
    public struct TestImplicit
    {
        public int Value { get; set; }

        public static implicit operator int(TestImplicit value)
        {
            return value.Value;
        }

        public static implicit operator TestImplicit(int value)
        {
            return new TestImplicit { Value = value };
        }
    }

    public struct TestNullableImplicit
    {
        public int? Value { get; set; }

        public static implicit operator int?(TestNullableImplicit value)
        {
            return value.Value;
        }

        public static implicit operator TestNullableImplicit(int? value)
        {
            return new TestNullableImplicit { Value = value };
        }
    }
}
