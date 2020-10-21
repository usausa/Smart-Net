namespace Smart.Functional
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using Smart.Threading.Tasks;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class ObjectExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Also<T>(this T value, Action<T> action)
        {
            action(value);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AlsoIf<T>(this T value, Func<T, bool> predicate, Action<T> action)
        {
            if (predicate(value))
            {
                action(value);
            }
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Apply<T>(this T value, Action<T> action)
        {
            action(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ApplyIf<T>(this T value, Func<T, bool> predicate, Action<T> action)
        {
            if (predicate(value))
            {
                action(value);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Apply<T, TResult>(this T value, Func<T, TResult> func)
        {
            return func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyIfOrDefault<T, TResult>(this T value, Func<T, bool> predicate, Func<T, TResult> func)
        {
            return predicate(value) ? func(value) : default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyIf<T, TResult>(this T value, Func<T, bool> predicate, Func<T, TResult> func, TResult defaultValue)
        {
            return predicate(value) ? func(value) : defaultValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyIf<T, TResult>(this T value, Func<T, bool> predicate, Func<T, TResult> func, Func<TResult> defaultValueFactory)
        {
            return predicate(value) ? func(value) : defaultValueFactory();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOrDefault<T, TResult>(this T value, Func<T, TResult> func)
            where T : class
        {
            return value is null ? default : func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T value, Func<T, TResult> func, TResult defaultValue)
            where T : class
        {
            return value is null ? defaultValue : func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T value, Func<T, TResult> func, Func<TResult> defaultValueFactory)
            where T : class
        {
            return value is null ? defaultValueFactory() : func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOrDefault<T, TResult>(this T? value, Func<T, TResult> func)
            where T : struct
        {
            return value is null ? default : func(value.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T? value, Func<T, TResult> func, TResult defaultValue)
            where T : struct
        {
            return value is null ? defaultValue : func(value.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T? value, Func<T, TResult> func, Func<TResult> defaultValueFactory)
            where T : struct
        {
            return value is null ? defaultValueFactory() : func(value.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TResult> MapOrDefaultAsync<T, TResult>(this T value, Func<T, Task<TResult>> func)
        {
            return value == null ? Tasks<TResult>.DefaultResult : func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TResult> MapOrAsync<T, TResult>(this T value, Func<T, Task<TResult>> func, Task<TResult> defaultTask)
        {
            return value == null ? defaultTask : func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TResult> MapOrAsync<T, TResult>(this T value, Func<T, Task<TResult>> func, Func<Task<TResult>> defaultTaskFactory)
        {
            return value == null ? defaultTaskFactory() : func(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IfNotNull<T>(this T value, Action<T> action)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> FlatOrEmpty<T>(this T value)
            where T : class
        {
            return value is null ? Enumerable.Empty<T>() : FromSingleValue(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
            where T : struct
        {
            return value is null ? Enumerable.Empty<T>() : FromSingleValue(value.Value);
        }

        private static IEnumerable<T> FromSingleValue<T>(T value)
        {
            yield return value;
        }
    }
}
