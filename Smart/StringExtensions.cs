namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string EmptyIfNull(this string value)
        {
            return value ?? string.Empty;
        }

        public static string Repeat(this string value, int count)
        {
            var sb = new StringBuilder(value.Length * count);
            for (var i = 0; i < count; i++)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CutLeft(this string text, int length)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }

            return text.Length < length ? string.Empty : text.Substring(length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CutLeft(this string text, string value)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }

            return text.StartsWith(value, StringComparison.Ordinal) ? text.Substring(value.Length) : text;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CutLeft(this string text, string value, StringComparison comparison)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }

            return text.StartsWith(value, comparison) ? text.Substring(value.Length) : text;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CutRight(this string text, int length)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }

            return text.Length < length ? string.Empty : text.Substring(0, text.Length - length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CutRight(this string text, string value)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }

            return text.EndsWith(value, StringComparison.Ordinal) ? text.Substring(0, text.Length - value.Length) : text;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CutRight(this string text, string value, StringComparison comparison)
        {
            if (String.IsNullOrEmpty(text))
            {
                return text;
            }

            return text.EndsWith(value, comparison) ? text.Substring(0, text.Length - value.Length) : text;
        }
    }
}
