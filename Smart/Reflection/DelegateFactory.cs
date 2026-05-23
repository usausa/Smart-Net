namespace Smart.Reflection;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

public sealed partial class DelegateFactory : IDelegateFactory
{
    public static DelegateFactory Default { get; } = new();

    public IDelegateFactory Factory { get; set; }

    public bool IsCodegenRequired => Factory.IsCodegenRequired;

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "DynamicDelegateFactory is only used when RuntimeFeature.IsDynamicCodeSupported is true.")]
    [UnconditionalSuppressMessage("AOT", "IL3050", Justification = "DynamicDelegateFactory is only used when RuntimeFeature.IsDynamicCodeSupported is true.")]
    public DelegateFactory()
    {
        if (RuntimeFeature.IsDynamicCodeSupported)
        {
            Factory = DynamicDelegateFactory.Default;
        }
        else
        {
            Factory = ReflectionDelegateFactory.Default;
        }
    }

    //--------------------------------------------------------------------------------
    // Array
    //--------------------------------------------------------------------------------

    public Func<int, Array> CreateArrayAllocator(Type type)
    {
        return Factory.CreateArrayAllocator(type);
    }

    //--------------------------------------------------------------------------------
    // Factory
    //--------------------------------------------------------------------------------

    public Func<object> CreateFactory([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type)
    {
        return Factory.CreateFactory(type);
    }

    public Func<object?[]?, object> CreateFactory([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type, Type[] argumentTypes)
    {
        return Factory.CreateFactory(type, argumentTypes);
    }

    public Func<object?[]?, object> CreateFactory(ConstructorInfo ci)
    {
        return Factory.CreateFactory(ci);
    }

    //--------------------------------------------------------------------------------
    // Accessor
    //--------------------------------------------------------------------------------

    public Func<object?, object?>? CreateGetter(PropertyInfo pi)
    {
        return Factory.CreateGetter(pi);
    }

    public Func<object?, object?>? CreateGetter(PropertyInfo pi, bool extension)
    {
        return Factory.CreateGetter(pi, extension);
    }

    public Action<object?, object?>? CreateSetter(PropertyInfo pi)
    {
        return Factory.CreateSetter(pi);
    }

    public Action<object?, object?>? CreateSetter(PropertyInfo pi, bool extension)
    {
        return Factory.CreateSetter(pi, extension);
    }

    // Accessor

    public Func<T?, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi)
    {
        return Factory.CreateGetter<T, TMember>(pi);
    }

    public Func<T?, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi, bool extension)
    {
        return Factory.CreateGetter<T, TMember>(pi, extension);
    }

    public Action<T?, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi)
    {
        return Factory.CreateSetter<T, TMember>(pi);
    }

    public Action<T?, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi, bool extension)
    {
        return Factory.CreateSetter<T, TMember>(pi, extension);
    }

    //--------------------------------------------------------------------------------
    // Etc
    //--------------------------------------------------------------------------------

    public Type GetExtendedPropertyType(PropertyInfo pi)
    {
        return Factory.GetExtendedPropertyType(pi);
    }
}
