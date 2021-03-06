namespace Smart.ComponentModel
{
    using System;

    internal class ComponentEntry
    {
        public object? Constant { get; }

        public Type? ImplementType { get; }

        public ComponentEntry(object constant)
        {
            Constant = constant;
        }

        public ComponentEntry(Type implementType)
        {
            ImplementType = implementType;
        }
    }
}
