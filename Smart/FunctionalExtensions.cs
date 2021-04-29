namespace Smart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

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
            return value is null ? ValueTask.CompletedTask : action(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask IfNotNullAsync<T>(this T? value, Func<T, ValueTask> action)
            where T : struct
        {
            return value is null ? ValueTask.CompletedTask : action(value.Value);
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
        public static T AlsoIf<T>(this T value, Condition<T> condition, Action<T> action)
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
        public static async Task<T> AlsoIfAsync<T>(this T value, Condition<T> condition, Func<T, Task> action)
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
        public static async ValueTask<T> AlsoIfAsync<T>(this T value, Condition<T> condition, Func<T, ValueTask> action)
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
        public static void ApplyIf<T>(this T value, Condition<T> condition, Action<T> action)
        {
            if (condition(value))
            {
                action(value);
            }
        }

        // Async

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ApplyAsync<T>(this T value, Func<T, Task> action) =>
            action(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ApplyIfAsync<T>(this T value, Condition<T> condition, Func<T, Task> action) =>
            condition(value) ? action(value) : Task.CompletedTask;

        // Async

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask ApplyAsync<T>(this T value, Func<T, ValueTask> action) =>
            action(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask ApplyIfAsync<T>(this T value, Condition<T> condition, Func<T, ValueTask> action) =>
            condition(value) ? action(value) : default;

        //--------------------------------------------------------------------------------
        // Map
        //--------------------------------------------------------------------------------

        public static TResult? Map<T, TResult>(this T? value, Func<T?, TResult?> func) =>
            func(value);

        public static TResult? MapOrDefault<T, TResult>(this T? value, Func<T, TResult?> func) =>
            value is null ? default : func(value);

        public static TResult? MapOrDefault<T, TResult>(this T? value, Func<T, TResult?> func, TResult? defaultValue) =>
            value is null ? defaultValue : func(value);

        public static TResult? MapIfOrDefault<T, TResult>(this T? value, NullableCondition<T> condition, Func<T?, TResult?> func) =>
            condition(value) ? func(value) : default;

        public static TResult? MapIfOrDefault<T, TResult>(this T? value, NullableCondition<T> condition, Func<T?, TResult?> func, TResult? defaultValue) =>
            condition(value) ? func(value) : defaultValue;

        // Async

        public static Task<TResult?> MapAsync<T, TResult>(this T? value, Func<T?, Task<TResult?>> func) =>
            func(value);

        public static Task<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, Task<TResult?>> func) =>
            value is null ? Task.FromResult(default(TResult)) : func(value);

        public static Task<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, Task<TResult?>> func, TResult? defaultValue) =>
            value is null ? Task.FromResult(defaultValue) : func(value);

        public static Task<TResult?> MapIfOrDefault<T, TResult>(this T? value, NullableCondition<T> condition, Func<T?, Task<TResult?>> func) =>
            condition(value) ? func(value) : Task.FromResult<TResult?>(default);

        public static Task<TResult?> MapIfOrDefault<T, TResult>(this T? value, NullableCondition<T> condition, Func<T?, Task<TResult?>> func, TResult? defaultValue) =>
            condition(value) ? func(value) : Task.FromResult(defaultValue);

        // Async

        public static ValueTask<TResult?> MapAsync<T, TResult>(this T? value, Func<T?, ValueTask<TResult?>> func) =>
            func(value);

        public static ValueTask<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, ValueTask<TResult?>> func) =>
            value is null ? new ValueTask<TResult?>(default(TResult)) : func(value);

        public static ValueTask<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, ValueTask<TResult?>> func, TResult? defaultValue) =>
            value is null ? new ValueTask<TResult?>(defaultValue) : func(value);

        public static ValueTask<TResult?> MapIfOrDefault<T, TResult>(this T? value, NullableCondition<T> condition, Func<T?, ValueTask<TResult?>> func) =>
            condition(value) ? func(value) : new ValueTask<TResult?>(default(TResult));

        public static ValueTask<TResult?> MapIfOrDefault<T, TResult>(this T? value, NullableCondition<T> condition, Func<T?, ValueTask<TResult?>> func, TResult? defaultValue) =>
            condition(value) ? func(value) : new ValueTask<TResult?>(defaultValue);

        //--------------------------------------------------------------------------------
        // Enumerable
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
        {
            return value is null ? Enumerable.Empty<T>() : Flat(value);
        }

        private static IEnumerable<T> Flat<T>(T value)
        {
            yield return value;
        }
    }
}
