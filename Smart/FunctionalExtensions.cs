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
        {
            if (value is null)
            {
                return;
            }

            action(value);
        }

        // Async

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task IfNotNullAsync<T>(this T? value, Func<T, Task> action) =>
            value is null ? Task.CompletedTask : action(value);

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
        public static T AlsoIf<T>(this T value, NotNullCondition<T> condition, Action<T> action)
        {
            if (condition(value))
            {
                action(value);
            }

            return value;
        }

        // Async

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> AlsoAsync<T>(this T value, Func<T, Task<T>> action) =>
            action(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<T> AlsoIfAsync<T>(this T value, NotNullCondition<T> condition, Func<T, Task<T>> action) =>
            condition(value) ? action(value) : Task.FromResult(value);

        // Async

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> AlsoAsync<T>(this T value, Func<T, ValueTask<T>> action) =>
            action(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<T> AlsoIfAsync<T>(this T value, NotNullCondition<T> condition, Func<T, ValueTask<T>> action) =>
            condition(value) ? action(value) : new ValueTask<T>(value);

        //--------------------------------------------------------------------------------
        // Apply
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Apply<T>(this T value, Action<T> action) =>
            action(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ApplyIf<T>(this T value, NotNullCondition<T> condition, Action<T> action)
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
        public static Task ApplyIfAsync<T>(this T value, NotNullCondition<T> condition, Func<T, Task> action) =>
            condition(value) ? action(value) : Task.CompletedTask;

        // Async

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask ApplyAsync<T>(this T value, Func<T, ValueTask> action) =>
            action(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask ApplyIfAsync<T>(this T value, NotNullCondition<T> condition, Func<T, ValueTask> action) =>
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

        public static TResult? MapIfOrDefault<T, TResult>(this T? value, Condition<T> condition, Func<T?, TResult?> func) =>
            condition(value) ? func(value) : default;

        public static TResult? MapIfOrDefault<T, TResult>(this T? value, Condition<T> condition, Func<T?, TResult?> func, TResult? defaultValue) =>
            condition(value) ? func(value) : defaultValue;

        // Async

        public static Task<TResult?> MapAsync<T, TResult>(this T? value, Func<T?, Task<TResult?>> func) =>
            func(value);

        public static Task<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, Task<TResult?>> func) =>
            value is null ? Task.FromResult(default(TResult)) : func(value);

        public static Task<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, Task<TResult?>> func, TResult? defaultValue) =>
            value is null ? Task.FromResult(defaultValue) : func(value);

        public static Task<TResult?> MapIfOrDefault<T, TResult>(this T? value, Condition<T> condition, Func<T?, Task<TResult?>> func) =>
            condition(value) ? func(value) : Task.FromResult<TResult?>(default);

        public static Task<TResult?> MapIfOrDefault<T, TResult>(this T? value, Condition<T> condition, Func<T?, Task<TResult?>> func, TResult? defaultValue) =>
            condition(value) ? func(value) : Task.FromResult(defaultValue);

        // Async

        public static ValueTask<TResult?> MapAsync<T, TResult>(this T? value, Func<T?, ValueTask<TResult?>> func) =>
            func(value);

        public static ValueTask<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, ValueTask<TResult?>> func) =>
            value is null ? new ValueTask<TResult?>(default(TResult)) : func(value);

        public static ValueTask<TResult?> MapOrDefault<T, TResult>(this T? value, Func<T, ValueTask<TResult?>> func, TResult? defaultValue) =>
            value is null ? new ValueTask<TResult?>(defaultValue) : func(value);

        public static ValueTask<TResult?> MapIfOrDefault<T, TResult>(this T? value, Condition<T> condition, Func<T?, ValueTask<TResult?>> func) =>
            condition(value) ? func(value) : new ValueTask<TResult?>(default(TResult));

        public static ValueTask<TResult?> MapIfOrDefault<T, TResult>(this T? value, Condition<T> condition, Func<T?, ValueTask<TResult?>> func, TResult? defaultValue) =>
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
