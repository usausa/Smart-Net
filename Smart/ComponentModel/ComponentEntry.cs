namespace Smart.ComponentModel;

internal sealed class ComponentEntry
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
