namespace Smart.Converter.Types
{
    public struct StructType
    {
        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
