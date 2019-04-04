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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Ignore")]
        public override int GetHashCode() => (Type, Name).GetHashCode();

        public override bool Equals(object obj) => obj is CompositeKey other && Equals(other);

        public bool Equals(CompositeKey other) => Type == other.Type && Name == other.Name;

        public static bool operator ==(CompositeKey x, CompositeKey y) => x.Equals(y);

        public static bool operator !=(CompositeKey x, CompositeKey y) => !x.Equals(y);
    }
}
