namespace Smart.ComponentModel;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

public sealed class ComponentContainer : IDisposable, IServiceProvider
{
    private static readonly object[] EmptyResult = [];

    private readonly Dictionary<Type, object[]> cache = [];

    private readonly Dictionary<Type, ComponentEntry[]> mappings;

    public ComponentContainer(ComponentConfig config)
    {
        mappings = config.ToMappings();
    }

    ~ComponentContainer()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            lock (cache)
            {
                var disposed = new HashSet<object>();
                foreach (var instance in cache.Values.SelectMany(static x => x))
                {
                    if (instance is IDisposable disposable)
                    {
                        disposable.Dispose();
                        disposed.Add(instance);
                    }
                }

                foreach (var entry in mappings.Values.SelectMany(static x => x))
                {
                    if ((entry.Constant is IDisposable disposable) && !disposed.Contains(disposable))
                    {
                        disposable.Dispose();
                    }
                }

                cache.Clear();
                mappings.Clear();
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<T> GetAll<T>() => GetAll(typeof(T)).Cast<T>();

    public object Get(Type componentType)
    {
        var objects = ResolveAll(componentType);
        if (objects.Length == 0)
        {
            throw new InvalidOperationException(
                String.Format(CultureInfo.InvariantCulture, "No such component registered. component type = {0}", componentType.Name));
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
        if (serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            return ConvertArray(serviceType.GenericTypeArguments[0], GetAll(serviceType.GenericTypeArguments[0]));
        }

        var objects = ResolveAll(serviceType);
        return objects.Length > 0 ? objects[^1] : null;
    }

    private object[] ResolveAll(Type componentType)
    {
        lock (cache)
        {
            if (cache.TryGetValue(componentType, out var objects))
            {
                return objects;
            }

            if (!mappings.TryGetValue(componentType, out var entries))
            {
                return EmptyResult;
            }

            objects = entries
                .Select(entry => entry.Constant ?? CreateInstance(entry.ImplementType!))
                .ToArray();
            cache[componentType] = objects;

            return objects;
        }
    }

    private object CreateInstance(Type type)
    {
        foreach (var ci in type.GetConstructors().OrderByDescending(static c => c.GetParameters().Length))
        {
            if (ci.GetParameters().Length == 0)
            {
                return ci.Invoke(null);
            }

            var match = true;
            var arguments = new object?[ci.GetParameters().Length];
            for (var i = 0; i < arguments.Length; i++)
            {
                var pi = ci.GetParameters()[i];
                var elementType = GetElementType(pi.ParameterType);
                if (elementType is null)
                {
                    match = TryGet(pi.ParameterType, out arguments[i]);
                }
                else
                {
                    arguments[i] = ConvertArray(elementType, GetAll(elementType));
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

        throw new InvalidOperationException(
            String.Format(CultureInfo.InvariantCulture, "Constructor parameter unresolved. implementation type = {0}", type.Name));
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

    private static Array ConvertArray(Type elementType, IEnumerable<object> source)
    {
        var sourceArray = source.ToArray();
        var array = Array.CreateInstance(elementType, sourceArray.Length);
        Array.Copy(sourceArray, 0, array, 0, sourceArray.Length);
        return array;
    }
}
