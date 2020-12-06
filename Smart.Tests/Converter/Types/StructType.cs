namespace Smart.Converter.Types
{
    public struct StructType
    {
        public int X { get; init; }

        public int Y { get; init; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
