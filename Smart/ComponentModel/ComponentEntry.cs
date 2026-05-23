namespace Smart.ComponentModel;

using System.Diagnostics.CodeAnalysis;

internal sealed class ComponentEntry
{
    public object? Constant { get; }

    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    public Type? ImplementType { get; }

    public ComponentEntry(object constant)
    {
        Constant = constant;
    }

    public ComponentEntry([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementType)
    {
        ImplementType = implementType;
    }
}
