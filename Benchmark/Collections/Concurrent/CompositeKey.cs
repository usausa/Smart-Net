namespace Benchmark.Collections.Concurrent
{
    using System;

    public struct CompositeKey : IEquatable<CompositeKey>
    {
        public Type Type { get; }

        public string Name { get; }

        public CompositeKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }

        public bool Equals(CompositeKey other) => Type == other.Type && Name == other.Name;

        public override bool Equals(object obj) => obj is CompositeKey other && Equals(other);

        public override int GetHashCode() => (Type, Name).GetHashCode();
    }
}
