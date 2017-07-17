namespace Smart.Collections.Concurrent
{
    using System;

    public interface IHashArrayMapResizeContext
    {
        int Width { get; }

        int Depth { get; }

        int Count { get; }

        int Growth { get; }
    }

    public interface IHashArrayMapStrategy
    {
        int CalculateInitialSize();

        int CalculateRequestSize(IHashArrayMapResizeContext context);
    }

    public sealed class GrowthHashArrayMapStrategy : IHashArrayMapStrategy
    {
        private readonly int initialSize;

        private readonly double factor;

        public GrowthHashArrayMapStrategy(int initialSize, double factor = 1.0)
        {
            this.initialSize = initialSize;
            this.factor = factor;
        }

        public int CalculateInitialSize()
        {
            return initialSize;
        }

        public int CalculateRequestSize(IHashArrayMapResizeContext context)
        {
            return (int)Math.Ceiling((context.Count + context.Growth) * factor);
        }
    }
}
