namespace Smart.Functional
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    /// <summary>
    ///
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Also<T>(this T value, Action<T> action)
        {
            action(value);
            return value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AlsoIf<T>(this T value, Func<T, bool> predicate, Action<T> action)
        {
            if (predicate(value))
            {
                action(value);
            }
            return value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Apply<T>(this T value, Action<T> action)
        {
            action(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="action"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ApplyIf<T>(this T value, Func<T, bool> predicate, Action<T> action)
        {
            if (predicate(value))
            {
                action(value);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Apply<T, TResult>(this T value, Func<T, TResult> func)
        {
            return func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyIfOrDefault<T, TResult>(this T value, Func<T, bool> predicate, Func<T, TResult> func)
        {
            return predicate(value) ? func(value) : default;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyIf<T, TResult>(this T value, Func<T, bool> predicate, Func<T, TResult> func, TResult defaultValue)
        {
            return predicate(value) ? func(value) : defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="defaultValueFactory"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult ApplyIf<T, TResult>(this T value, Func<T, bool> predicate, Func<T, TResult> func, Func<TResult> defaultValueFactory)
        {
            return predicate(value) ? func(value) : defaultValueFactory();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOrDefault<T, TResult>(this T value, Func<T, TResult> func)
            where T : class
        {
            return value is null ? default : func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T value, Func<T, TResult> func, TResult defaultValue)
            where T : class
        {
            return value is null ? defaultValue : func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="defaultValueFactory"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T value, Func<T, TResult> func, Func<TResult> defaultValueFactory)
            where T : class
        {
            return value is null ? defaultValueFactory() : func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOrDefault<T, TResult>(this T? value, Func<T, TResult> func)
            where T : struct
        {
            return value is null ? default : func(value.Value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T? value, Func<T, TResult> func, TResult defaultValue)
            where T : struct
        {
            return value is null ? defaultValue : func(value.Value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="defaultValueFactory"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult MapOr<T, TResult>(this T? value, Func<T, TResult> func, Func<TResult> defaultValueFactory)
            where T : struct
        {
            return value is null ? defaultValueFactory() : func(value.Value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TResult> MapOrDefaultAsync<T, TResult>(this T value, Func<T, Task<TResult>> func)
        {
            return value == null ? Empty<TResult>.Task : func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="defaultTask"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TResult> MapOrAsync<T, TResult>(this T value, Func<T, Task<TResult>> func, Task<TResult> defaultTask)
        {
            return value == null ? defaultTask : func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <param name="defaultTaskFactory"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TResult> MapOrAsync<T, TResult>(this T value, Func<T, Task<TResult>> func, Func<Task<TResult>> defaultTaskFactory)
        {
            return value == null ? defaultTaskFactory() : func(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
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

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
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

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> FlatOrEmpty<T>(this T value)
            where T : class
        {
            return value is null ? Enumerable.Empty<T>() : FromSingleValue(value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> FlatOrEmpty<T>(this T? value)
            where T : struct
        {
            return value is null ? Enumerable.Empty<T>() : FromSingleValue(value.Value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static IEnumerable<T> FromSingleValue<T>(T value)
        {
            yield return value;
        }
    }
}
