namespace Smart.Reflection;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

public sealed partial class ReflectionDelegateFactory : IDelegateFactory
{
    public static ReflectionDelegateFactory Default { get; } = new();

    public bool IsCodegenRequired => false;

    // Constructor

    private ReflectionDelegateFactory()
    {
    }

    //--------------------------------------------------------------------------------
    // Array
    //--------------------------------------------------------------------------------

    [UnconditionalSuppressMessage("AOT", "IL3050", Justification = "Arrays of reference types need no dynamic code. For value types, the caller makes the array type available, for example by referencing typeof(T[]).")]
    public Func<int, Array> CreateArrayAllocator(Type type)
    {
        return length => Array.CreateInstance(type, length);
    }

    //--------------------------------------------------------------------------------
    // Factory
    //--------------------------------------------------------------------------------

    public Func<object> CreateFactory([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type)
    {
        return () => Activator.CreateInstance(type)!;
    }

    public Func<object?[]?, object> CreateFactory([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type, Type[] argumentTypes)
    {
        if (type.IsValueType && (argumentTypes.Length == 0))
        {
            return _ => Activator.CreateInstance(type)!;
        }

        var ci = type.GetConstructor(argumentTypes);
        if (ci is null)
        {
            throw new ArgumentException($"Constructor not found. type=[{type}]", nameof(type));
        }

        return CreateFactory(ci);
    }

    public Func<object?[]?, object> CreateFactory(ConstructorInfo ci)
    {
        if (ci.DeclaringType is null)
        {
            throw new ArgumentException($"Invalid type parameter. name=[{ci.Name}]", nameof(ci));
        }

        return ci.GetParameters().Length == 0
            ? _ => ci.Invoke(BindingFlags.DoNotWrapExceptions, null, null, null)
            : args => ci.Invoke(BindingFlags.DoNotWrapExceptions, null, args, null);
    }

    public Func<object> CreateFactory0(ConstructorInfo ci)
    {
        if (ci.DeclaringType is null)
        {
            throw new ArgumentException($"Invalid type parameter. name=[{ci.Name}]", nameof(ci));
        }

        // specialized
        return () => ci.Invoke(BindingFlags.DoNotWrapExceptions, null, null, null);
    }

    public Func<T> CreateFactory<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>()
    {
        return Activator.CreateInstance<T>;
    }

    //--------------------------------------------------------------------------------
    // Accessor
    //--------------------------------------------------------------------------------

    public Func<object?, object?>? CreateGetter(PropertyInfo pi)
    {
        return CreateGetter(pi, true);
    }

    public Func<object?, object?>? CreateGetter(PropertyInfo pi, bool extension)
    {
        if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
        {
            throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
        }

        var vpi = !extension ? null : pi.GetValueHolderProperty();
        if (vpi is null)
        {
            if (!pi.CanRead)
            {
                return null;
            }

            return obj => pi.GetValue(obj, BindingFlags.DoNotWrapExceptions, null, null, null);
        }

        if (!pi.CanRead)
        {
            throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
        }

        return obj =>
        {
            var holder = pi.GetValue(obj, BindingFlags.DoNotWrapExceptions, null, null, null);
            return vpi.GetValue(holder, BindingFlags.DoNotWrapExceptions, null, null, null);
        };
    }

    public Action<object?, object?>? CreateSetter(PropertyInfo pi)
    {
        return CreateSetter(pi, true);
    }

    public Action<object?, object?>? CreateSetter(PropertyInfo pi, bool extension)
    {
        if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
        {
            throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
        }

        var vpi = !extension ? null : pi.GetValueHolderProperty();
        if (vpi is null)
        {
            if (!pi.CanWrite)
            {
                return null;
            }

            var setter = MethodInvoker.Create(pi.SetMethod!);
            return (obj, value) => setter.Invoke(obj, value);
        }

        if (!pi.CanRead)
        {
            throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
        }

        var holderGetter = MethodInvoker.Create(pi.GetMethod!);
        var valueSetter = MethodInvoker.Create(vpi.SetMethod!);
        return (obj, value) =>
        {
            var holder = holderGetter.Invoke(obj);
            valueSetter.Invoke(holder, value);
        };
    }

    // Accessor

    public Func<T?, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi)
    {
        return CreateGetter<T, TMember>(pi, true);
    }

    public Func<T?, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi, bool extension)
    {
        if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
        {
            throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
        }

        var vpi = !extension ? null : pi.GetValueHolderProperty();
        if (vpi is null)
        {
            if (!pi.CanRead)
            {
                return null;
            }

            return obj => (TMember?)pi.GetValue(obj, BindingFlags.DoNotWrapExceptions, null, null, null);
        }

        if (!pi.CanRead)
        {
            throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
        }

        return obj =>
        {
            var holder = pi.GetValue(obj, BindingFlags.DoNotWrapExceptions, null, null, null);
            return (TMember?)vpi.GetValue(holder, BindingFlags.DoNotWrapExceptions, null, null, null);
        };
    }

    public Action<T?, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi)
    {
        return CreateSetter<T, TMember>(pi, true);
    }

    public Action<T?, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi, bool extension)
    {
        if ((pi.DeclaringType is null) || pi.DeclaringType.IsValueType)
        {
            throw new ArgumentException($"Invalid type parameter. name=[{pi.Name}]", nameof(pi));
        }

        var vpi = !extension ? null : pi.GetValueHolderProperty();
        if (vpi is null)
        {
            if (!pi.CanWrite)
            {
                return null;
            }

            var setter = MethodInvoker.Create(pi.SetMethod!);
            return (obj, value) => setter.Invoke(obj, value);
        }

        if (!pi.CanRead)
        {
            throw new ArgumentException($"Value holder is not readable. name=[{pi.Name}]", nameof(pi));
        }

        var holderGetter = MethodInvoker.Create(pi.GetMethod!);
        var valueSetter = MethodInvoker.Create(vpi.SetMethod!);
        return (obj, value) =>
        {
            var holder = holderGetter.Invoke(obj);
            valueSetter.Invoke(holder, value);
        };
    }

    //--------------------------------------------------------------------------------
    // Etc
    //--------------------------------------------------------------------------------

    public Type GetExtendedPropertyType(PropertyInfo pi)
    {
        var tpi = pi.GetValueHolderProperty() ?? pi;
        return tpi.PropertyType;
    }
}
