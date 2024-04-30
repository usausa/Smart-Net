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

    // With state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IfNotNull<T, TState>(this T? value, TState state, Action<T, TState> action)
        where T : class
    {
        if (value is null)
        {
            return;
        }

        action(value, state);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IfNotNull<T, TState>(this T? value, TState state, Action<T, TState> action)
        where T : struct
    {
        if (value is null)
        {
            return;
        }

        action(value.Value, state);
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

    // Async with state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task IfNotNullAsync<T, TState>(this T? value, TState state, Func<T, TState, Task> action)
        where T : class
    {
        return value is null ? Task.CompletedTask : action(value, state);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task IfNotNullAsync<T, TState>(this T? value, TState state, Func<T, TState, Task> action)
        where T : struct
    {
        return value is null ? Task.CompletedTask : action(value.Value, state);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask IfNotNullAsync<T, TState>(this T? value, TState state, Func<T, TState, ValueTask> action)
        where T : class
    {
        return value is null ? default : action(value, state);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask IfNotNullAsync<T, TState>(this T? value, TState state, Func<T, TState, ValueTask> action)
        where T : struct
    {
        return value is null ? default : action(value.Value, state);
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

    // With state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Also<T, TState>(this T value, TState state, Action<T, TState> action)
    {
        action(value, state);
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AlsoIf<T, TState>(this T value, TState state, Func<T, bool> condition, Action<T, TState> action)
    {
        if (condition(value))
        {
            action(value, state);
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AlsoIf<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Action<T> action)
    {
        if (condition(value, state))
        {
            action(value);
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AlsoIf<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Action<T, TState> action)
    {
        if (condition(value, state))
        {
            action(value, state);
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

    // Async with state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<T> AlsoAsync<T, TState>(this T value, TState state, Func<T, TState, Task> action)
    {
        await action(value, state).ConfigureAwait(false);
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<T> AlsoIfAsync<T, TState>(this T value, TState state, Func<T, bool> condition, Func<T, TState, Task> action)
    {
        if (condition(value))
        {
            await action(value, state).ConfigureAwait(false);
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<T> AlsoIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, Task> action)
    {
        if (condition(value, state))
        {
            await action(value).ConfigureAwait(false);
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<T> AlsoIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, Task> action)
    {
        if (condition(value, state))
        {
            await action(value, state).ConfigureAwait(false);
        }

        return value;
    }

    // Async with state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<T> AlsoAsync<T, TState>(this T value, TState state, Func<T, TState, ValueTask> action)
    {
        await action(value, state).ConfigureAwait(false);
        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<T> AlsoIfAsync<T, TState>(this T value, TState state, Func<T, bool> condition, Func<T, TState, ValueTask> action)
    {
        if (condition(value))
        {
            await action(value, state).ConfigureAwait(false);
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<T> AlsoIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, ValueTask> action)
    {
        if (condition(value, state))
        {
            await action(value).ConfigureAwait(false);
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<T> AlsoIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, ValueTask> action)
    {
        if (condition(value, state))
        {
            await action(value, state).ConfigureAwait(false);
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

    // With state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Apply<T, TState>(this T value, TState state, Action<T, TState> action) =>
        action(value, state);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyIf<T, TState>(this T value, TState state, Func<T, bool> condition, Action<T, TState> action)
    {
        if (condition(value))
        {
            action(value, state);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyIf<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Action<T> action)
    {
        if (condition(value, state))
        {
            action(value);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyIf<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Action<T, TState> action)
    {
        if (condition(value, state))
        {
            action(value, state);
        }
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ApplyAsync<T>(this T value, Func<T, Task> action) =>
        action(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ApplyIfAsync<T>(this T value, Func<T, bool> condition, Func<T, Task> action)
    {
        if (condition(value))
        {
            return action(value);
        }

        return Task.CompletedTask;
    }

    // Async

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask ApplyAsync<T>(this T value, Func<T, ValueTask> action) =>
        action(value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask ApplyIfAsync<T>(this T value, Func<T, bool> condition, Func<T, ValueTask> action)
    {
        if (condition(value))
        {
            return action(value);
        }

        return ValueTask.CompletedTask;
    }

    // Async with state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ApplyAsync<T, TState>(this T value, TState state, Func<T, TState, Task> action) =>
        action(value, state);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ApplyIfAsync<T, TState>(this T value, TState state, Func<T, bool> condition, Func<T, TState, Task> action)
    {
        if (condition(value))
        {
            return action(value, state);
        }

        return Task.CompletedTask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ApplyIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, Task> action)
    {
        if (condition(value, state))
        {
            return action(value);
        }

        return Task.CompletedTask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task ApplyIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, Task> action)
    {
        if (condition(value, state))
        {
            return action(value, state);
        }

        return Task.CompletedTask;
    }

    // Async with state

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask ApplyAsync<T, TState>(this T value, TState state, Func<T, TState, ValueTask> action) =>
        action(value, state);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask ApplyIfAsync<T, TState>(this T value, TState state, Func<T, bool> condition, Func<T, TState, ValueTask> action)
    {
        if (condition(value))
        {
            return action(value, state);
        }

        return ValueTask.CompletedTask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask ApplyIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, ValueTask> action)
    {
        if (condition(value, state))
        {
            return action(value);
        }

        return ValueTask.CompletedTask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask ApplyIfAsync<T, TState>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, ValueTask> action)
    {
        if (condition(value, state))
        {
            return action(value, state);
        }

        return ValueTask.CompletedTask;
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

    // With state

    public static TResult Map<T, TState, TResult>(this T value, TState state, Func<T, TState, TResult> func)
    {
        return func(value, state);
    }

    public static TResult MapOrDefault<T, TState, TResult>(this T? value, TState state, Func<T, TState, TResult> func)
        where T : class
    {
        return value is null ? default! : func(value, state);
    }

    public static TResult MapOrDefault<T, TState, TResult>(this T? value, TState state, Func<T, TState, TResult> func)
        where T : struct
    {
        return value.HasValue ? func(value.Value, state) : default!;
    }

    public static TResult MapOrDefault<T, TState, TResult>(this T? value, TState state, Func<T, TState, TResult> func, TResult defaultValue)
        where T : class
    {
        return value is null ? defaultValue : func(value, state);
    }

    public static TResult MapOrDefault<T, TState, TResult>(this T? value, TState state, Func<T, TState, TResult> func, TResult defaultValue)
        where T : struct
    {
        return value.HasValue ? func(value.Value, state) : defaultValue;
    }

    public static TResult MapIfOrDefault<T, TState, TResult>(this T value, TState state, Func<T, bool> condition, Func<T, TState, TResult> func)
    {
        return condition(value) ? func(value, state) : default!;
    }

    public static TResult MapIfOrDefault<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TResult> func)
    {
        return condition(value, state) ? func(value) : default!;
    }

    public static TResult MapIfOrDefault<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, TResult> func)
    {
        return condition(value, state) ? func(value, state) : default!;
    }

    public static TResult MapIfOrDefault<T, TState, TResult>(this T value, TState state, Func<T, bool> condition, Func<T, TState, TResult> func, TResult defaultValue)
    {
        return condition(value) ? func(value, state) : defaultValue;
    }

    public static TResult MapIfOrDefault<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TResult> func, TResult defaultValue)
    {
        return condition(value, state) ? func(value) : defaultValue;
    }

    public static TResult MapIfOrDefault<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, TResult> func, TResult defaultValue)
    {
        return condition(value, state) ? func(value, state) : defaultValue;
    }

    // Async

    public static Task<TResult> MapAsync<T, TResult>(this T value, Func<T, Task<TResult>> func)
    {
        return func(value);
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

    public static ValueTask<TResult> MapAsync<T, TResult>(this T value, Func<T, ValueTask<TResult>> func)
    {
        return func(value);
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

    // Async with state

    public static Task<TResult> MapAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, Task<TResult>> func)
    {
        return func(value, state);
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, Task<TResult>> func)
        where T : class
    {
        return value is null ? default! : await func(value, state).ConfigureAwait(false);
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, Task<TResult>> func)
        where T : struct
    {
        return value.HasValue ? await func(value.Value, state).ConfigureAwait(false) : default!;
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, Task<TResult>> func, TResult defaultValue)
        where T : class
    {
        return value is null ? defaultValue : await func(value, state).ConfigureAwait(false);
    }

    public static async Task<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, Task<TResult>> func, TResult defaultValue)
        where T : struct
    {
        return value.HasValue ? await func(value.Value, state).ConfigureAwait(false) : defaultValue;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, bool> condition, Func<T, TState, Task<TResult>> func)
    {
        return condition(value) ? await func(value, state).ConfigureAwait(false) : default!;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, Task<TResult>> func)
    {
        return condition(value, state) ? await func(value).ConfigureAwait(false) : default!;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, Task<TResult>> func)
    {
        return condition(value, state) ? await func(value, state).ConfigureAwait(false) : default!;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, bool> condition, Func<T, TState, Task<TResult>> func, TResult defaultValue)
    {
        return condition(value) ? await func(value, state).ConfigureAwait(false) : defaultValue;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, Task<TResult>> func, TResult defaultValue)
    {
        return condition(value, state) ? await func(value).ConfigureAwait(false) : defaultValue;
    }

    public static async Task<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, Task<TResult>> func, TResult defaultValue)
    {
        return condition(value, state) ? await func(value, state).ConfigureAwait(false) : defaultValue;
    }

    // Async with state

    public static ValueTask<TResult> MapAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, ValueTask<TResult>> func)
    {
        return func(value, state);
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, ValueTask<TResult>> func)
        where T : class
    {
        return value is null ? default! : await func(value, state).ConfigureAwait(false);
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, ValueTask<TResult>> func)
        where T : struct
    {
        return value.HasValue ? await func(value.Value, state).ConfigureAwait(false) : default!;
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, ValueTask<TResult>> func, TResult defaultValue)
        where T : class
    {
        return value is null ? defaultValue : await func(value, state).ConfigureAwait(false);
    }

    public static async ValueTask<TResult> MapOrDefaultAsync<T, TState, TResult>(this T? value, TState state, Func<T, TState, ValueTask<TResult>> func, TResult defaultValue)
        where T : struct
    {
        return value.HasValue ? await func(value.Value, state).ConfigureAwait(false) : defaultValue;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, bool> condition, Func<T, TState, ValueTask<TResult>> func)
    {
        return condition(value) ? await func(value, state).ConfigureAwait(false) : default!;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, ValueTask<TResult>> func)
    {
        return condition(value, state) ? await func(value).ConfigureAwait(false) : default!;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, ValueTask<TResult>> func)
    {
        return condition(value, state) ? await func(value, state).ConfigureAwait(false) : default!;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, bool> condition, Func<T, TState, ValueTask<TResult>> func, TResult defaultValue)
    {
        return condition(value) ? await func(value, state).ConfigureAwait(false) : defaultValue;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, ValueTask<TResult>> func, TResult defaultValue)
    {
        return condition(value, state) ? await func(value).ConfigureAwait(false) : defaultValue;
    }

    public static async ValueTask<TResult> MapIfOrDefaultAsync<T, TState, TResult>(this T value, TState state, Func<T, TState, bool> condition, Func<T, TState, ValueTask<TResult>> func, TResult defaultValue)
    {
        return condition(value, state) ? await func(value, state).ConfigureAwait(false) : defaultValue;
    }

    //--------------------------------------------------------------------------------
    // Enumerable
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
        where T : class
    {
        return value is null ? [] : Flat(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
        where T : struct
    {
        return value.HasValue ? Flat(value.Value) : [];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<T> Flat<T>(T value)
    {
        yield return value;
    }
}
