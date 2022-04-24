namespace Smart;

using System.Runtime.CompilerServices;

public static class FunctionalExtensions
{
    //--------------------------------------------------------------------------------
    // If
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IfNotNull<T>(this T? value, Action<T> action)
        where T : class
    {
        if (value is null)
        {
            return;
        }

        action(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IfNotNull<T>(this T? value, Action<T> action)
        where T : struct
    {
        if (value is null)
        {
            return;
        }

        action(value.Value);
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task IfNotNullAsync<T>(this T? value, Func<T, Task> action)
        where T : class
    {
        return value is null ? Task.CompletedTask : action(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task IfNotNullAsync<T>(this T? value, Func<T, Task> action)
        where T : struct
    {
        return value is null ? Task.CompletedTask : action(value.Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask IfNotNullAsync<T>(this T? value, Func<T, ValueTask> action)
        where T : class
    {
        return value is null ? default : action(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask IfNotNullAsync<T>(this T? value, Func<T, ValueTask> action)
        where T : struct
    {
        return value is null ? default : action(value.Value);
    }

    //--------------------------------------------------------------------------------
    // Also
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Also<T>(this T value, Action<T> action)
    {
        action(value);
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AlsoIf<T>(this T value, Func<T, bool> condition, Action<T> action)
    {
        if (condition(value))
        {
            action(value);
        }

        return value;
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<T> AlsoAsync<T>(this T value, Func<T, Task> action)
    {
        await action(value).ConfigureAwait(false);
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<T> AlsoIfAsync<T>(this T value, Func<T, bool> condition, Func<T, Task> action)
    {
        if (condition(value))
        {
            await action(value).ConfigureAwait(false);
        }

        return value;
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<T> AlsoAsync<T>(this T value, Func<T, ValueTask> action)
    {
        await action(value).ConfigureAwait(false);
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<T> AlsoIfAsync<T>(this T value, Func<T, bool> condition, Func<T, ValueTask> action)
    {
        if (condition(value))
        {
            await action(value).ConfigureAwait(false);
        }

        return value;
    }

    //--------------------------------------------------------------------------------
    // Apply
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Apply<T>(this T value, Action<T> action) =>
        action(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyIf<T>(this T value, Func<T, bool> condition, Action<T> action)
    {
        if (condition(value))
        {
            action(value);
        }
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task ApplyAsync<T>(this T value, Func<T, Task> action)
    {
        await action(value).ConfigureAwait(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task ApplyIfAsync<T>(this T value, Func<T, bool> condition, Func<T, Task> action)
    {
        if (condition(value))
        {
            await action(value).ConfigureAwait(false);
        }
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask ApplyAsync<T>(this T value, Func<T, ValueTask> action)
    {
        await action(value).ConfigureAwait(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask ApplyIfAsync<T>(this T value, Func<T, bool> condition, Func<T, ValueTask> action)
    {
        if (condition(value))
        {
            await action(value).ConfigureAwait(false);
        }
    }

    //--------------------------------------------------------------------------------
    // Map
    //--------------------------------------------------------------------------------

    public static TResult Map<T, TResult>(this T value, Func<T, TResult> func)
    {
        return func(value);
    }

    public static TResult MapOrDefault<T, TResult>(this T? value, Func<T, TResult> func)
        where T : class
    {
        return value is null ? default! : func(value);
    }

    public static TResult MapOrDefault<T, TResult>(this T? value, Func<T, TResult> func)
        where T : struct
    {
        return value.HasValue ? func(value.Value) : default!;
    }

    public static TResult MapOrDefault<T, TResult>(this T? value, Func<T, TResult> func, TResult defaultValue)
        where T : class
    {
        return value is null ? defaultValue : func(value);
    }

    public static TResult MapOrDefault<T, TResult>(this T? value, Func<T, TResult> func, TResult defaultValue)
        where T : struct
    {
        return value.HasValue ? func(value.Value) : defaultValue;
    }

    public static TResult MapIfOrDefault<T, TResult>(this T value, Func<T, bool> condition, Func<T, TResult> func)
    {
        return condition(value) ? func(value) : default!;
    }

    public static TResult MapIfOrDefault<T, TResult>(this T value, Func<T, bool> condition, Func<T, TResult> func, TResult defaultValue)
    {
        return condition(value) ? func(value) : defaultValue;
    }

    // Async

    public static async Task<TResult> MapAsync<T, TResult>(this T value, Func<T, Task<TResult>> func)
    {
        return await func(value).ConfigureAwait(false);
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, Task<TResult>> func)
        where T : class
    {
        return value is null ? default! : await func(value).ConfigureAwait(false);
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, Task<TResult>> func)
        where T : struct
    {
        return value.HasValue ? await func(value.Value).ConfigureAwait(false) : default!;
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, Task<TResult>> func, TResult defaultValue)
        where T : class
    {
        return value is null ? defaultValue : await func(value).ConfigureAwait(false);
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, Task<TResult>> func, TResult defaultValue)
        where T : struct
    {
        return value.HasValue ? await func(value.Value).ConfigureAwait(false) : defaultValue;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TResult>(this T value, Func<T, bool> condition, Func<T, Task<TResult>> func)
    {
        return condition(value) ? await func(value).ConfigureAwait(false) : default!;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TResult>(this T value, Func<T, bool> condition, Func<T, Task<TResult>> func, TResult defaultValue)
    {
        return condition(value) ? await func(value).ConfigureAwait(false) : defaultValue;
    }

    // Async

    public static async ValueTask<TResult> MapAsync<T, TResult>(this T value, Func<T, ValueTask<TResult>> func)
    {
        return await func(value).ConfigureAwait(false);
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, ValueTask<TResult>> func)
        where T : class
    {
        return value is null ? default! : await func(value).ConfigureAwait(false);
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, ValueTask<TResult>> func)
        where T : struct
    {
        return value.HasValue ? await func(value.Value).ConfigureAwait(false) : default!;
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, ValueTask<TResult>> func, TResult defaultValue)
        where T : class
    {
        return value is null ? defaultValue : await func(value).ConfigureAwait(false);
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TResult>(this T? value, Func<T, ValueTask<TResult>> func, TResult defaultValue)
        where T : struct
    {
        return value.HasValue ? await func(value.Value).ConfigureAwait(false) : defaultValue;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TResult>(this T value, Func<T, bool> condition, Func<T, ValueTask<TResult>> func)
    {
        return condition(value) ? await func(value).ConfigureAwait(false) : default!;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TResult>(this T value, Func<T, bool> condition, Func<T, ValueTask<TResult>> func, TResult defaultValue)
    {
        return condition(value) ? await func(value).ConfigureAwait(false) : defaultValue;
    }

    //--------------------------------------------------------------------------------
    // Enumerable
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
        where T : class
    {
        return value is null ? Enumerable.Empty<T>() : Flat(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
        where T : struct
    {
        return value.HasValue ? Flat(value.Value) : Enumerable.Empty<T>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<T> Flat<T>(T value)
    {
        yield return value;
    }
}
