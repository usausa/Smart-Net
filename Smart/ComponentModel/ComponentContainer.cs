namespace Smart.ComponentModel;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public sealed class ComponentContainer : IDisposable, IServiceProvider
{
    private static readonly object[] EmptyResult = [];

#if NET9_0_OR_GREATER
    private readonly Lock sync = new();
#else
    private readonly object sync = new();
#endif

    private readonly Dictionary<Type, Slot> slots;

    private volatile Dictionary<Type, Slot> enumerableSlots = [];

    private int disposed;

    public ComponentContainer(ComponentConfig config)
    {
        slots = config.ToMappings().ToDictionary(static x => x.Key, static x => new Slot(x.Value));
    }

    public void Dispose()
    {
        if (Interlocked.CompareExchange(ref disposed, 1, 0) == 1)
        {
            return;
        }

        lock (sync)
        {
            var released = new HashSet<object>(ReferenceEqualityComparer.Instance);

            foreach (var slot in slots.Values)
            {
                var instances = slot.GetInstances();
                if (instances is null)
                {
                    continue;
                }

                foreach (var instance in instances)
                {
                    if ((instance is IDisposable disposable) && released.Add(instance))
                    {
                        disposable.Dispose();
                    }
                }
            }

            foreach (var slot in slots.Values)
            {
                foreach (var entry in slot.Entries)
                {
                    if ((entry.Constant is IDisposable disposable) && released.Add(disposable))
                    {
                        disposable.Dispose();
                    }
                }
            }

            foreach (var slot in slots.Values)
            {
                slot.SetTyped(null);
                slot.SetInstances(EmptyResult);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Get<T>() => (T)Get(typeof(T));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGet<T>([MaybeNullWhen(false)] out T value)
    {
        var objects = ResolveAll(typeof(T));
        if (objects.Length > 0)
        {
            value = (T)objects[^1];
            return true;
        }

        value = default!;
        return false;
    }

    public IEnumerable<T> GetAll<T>()
    {
        if (!slots.TryGetValue(typeof(T), out var slot))
        {
            return Array.Empty<T>();
        }

        if (slot.GetTyped() is T[] cached)
        {
            return cached;
        }

        return CreateTyped<T>(slot);
    }

    public object Get(Type componentType)
    {
        var objects = ResolveAll(componentType);
        if (objects.Length == 0)
        {
            throw new InvalidOperationException($"No such component registered. type=[{componentType.Name}]");
        }

        return objects[^1];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGet(Type componentType, [NotNullWhen(true)] out object? value)
    {
        var objects = ResolveAll(componentType);
        if (objects.Length > 0)
        {
            value = objects[^1];
            return true;
        }

        value = null;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<object> GetAll(Type componentType) => ResolveAll(componentType);

    public object? GetService(Type serviceType)
    {
        if (serviceType.IsGenericType)
        {
            if (enumerableSlots.TryGetValue(serviceType, out var enumerableSlot))
            {
                return enumerableSlot.GetTyped() ?? ResolveEnumerable(serviceType);
            }

            if (serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return ResolveEnumerable(serviceType);
            }
        }

        if (!slots.TryGetValue(serviceType, out var slot))
        {
            return null;
        }

        var objects = slot.GetInstances() ?? CreateInstances(slot);
        return objects.Length > 0 ? objects[^1] : null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private object[] ResolveAll(Type componentType)
    {
        if (!slots.TryGetValue(componentType, out var slot))
        {
            return EmptyResult;
        }

        return slot.GetInstances() ?? CreateInstances(slot);
    }

    private object[] CreateInstances(Slot slot)
    {
        lock (sync)
        {
            var published = slot.GetInstances();
            if (published is not null)
            {
                return published;
            }

            var entries = slot.Entries;
            var objects = new object[entries.Length];
            for (var i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                objects[i] = entry.Constant ?? CreateInstance(entry.ImplementType!);
            }

            published = slot.GetInstances();
            if (published is not null)
            {
                return published;
            }

            slot.SetInstances(objects);
            return objects;
        }
    }

    private T[] CreateTyped<T>(Slot slot)
    {
        lock (sync)
        {
            if (slot.GetTyped() is T[] cached)
            {
                return cached;
            }

            var objects = slot.GetInstances() ?? CreateInstances(slot);
            var typed = new T[objects.Length];
            for (var i = 0; i < objects.Length; i++)
            {
                typed[i] = (T)objects[i];
            }

            slot.SetTyped(typed);
            return typed;
        }
    }

    private Array ResolveEnumerable(Type serviceType)
    {
        var elementType = serviceType.GenericTypeArguments[0];

        lock (sync)
        {
            if (!slots.TryGetValue(elementType, out var slot))
            {
                return CreateArray(elementType, EmptyResult);
            }

            var typed = slot.GetTyped();
            if (typed is null)
            {
                typed = CreateArray(elementType, slot.GetInstances() ?? CreateInstances(slot));
                slot.SetTyped(typed);
            }

            if (!enumerableSlots.ContainsKey(serviceType))
            {
                enumerableSlots = new Dictionary<Type, Slot>(enumerableSlots) { [serviceType] = slot };
            }

            return typed;
        }
    }

    private object CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type)
    {
        foreach (var ci in type.GetConstructors().OrderByDescending(static c => c.GetParameters().Length))
        {
            var parameters = ci.GetParameters();
            if (parameters.Length == 0)
            {
                return ci.Invoke(null);
            }

            var match = true;
            var arguments = new object?[parameters.Length];
            for (var i = 0; i < arguments.Length; i++)
            {
                var pi = parameters[i];
                var elementType = GetElementType(pi.ParameterType);
                if (elementType is null)
                {
                    match = TryGet(pi.ParameterType, out arguments[i]);
                }
                else
                {
                    arguments[i] = CreateArray(elementType, ResolveAll(elementType));
                }

                if (!match)
                {
                    break;
                }
            }

            if (!match)
            {
                continue;
            }

            return ci.Invoke(arguments);
        }

        throw new InvalidOperationException($"Constructor parameter unresolved. type=[{type.Name}]");
    }

    private static Type? GetElementType(Type type)
    {
        if (type.IsArray)
        {
            return type.GetElementType();
        }

        if (type.IsGenericType)
        {
            var genericType = type.GetGenericTypeDefinition();
            if ((genericType == typeof(IEnumerable<>)) ||
                (genericType == typeof(ICollection<>)) ||
                (genericType == typeof(IList<>)))
            {
                return type.GenericTypeArguments[0];
            }
        }

        return null;
    }

    [UnconditionalSuppressMessage("AOT", "IL3050", Justification = "Array.CreateInstance is used for component resolution; element types are registered by the caller who is responsible for AOT compatibility.")]
    private static Array CreateArray(Type elementType, object[] source)
    {
        var array = Array.CreateInstance(elementType, source.Length);
        Array.Copy(source, 0, array, 0, source.Length);
        return array;
    }

    private sealed class Slot
    {
        private volatile object[]? instances;

        private volatile Array? typed;

        public ComponentEntry[] Entries { get; }

        public Slot(ComponentEntry[] entries)
        {
            Entries = entries;
        }

        public object[]? GetInstances() => instances;

        public void SetInstances(object[] value) => instances = value;

        public Array? GetTyped() => typed;

        public void SetTyped(Array? value) => typed = value;
    }
}
