namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public static class StringExtensions
    {
        //--------------------------------------------------------------------------------
        // Safe
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string EmptyIfNull(this string value)
        {
            return value ?? string.Empty;
        }

        //--------------------------------------------------------------------------------
        // Repeat
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Repeat(this char value, int count) => new(value, count);

        public static string Repeat(this string value, int count)
        {
            var sb = new StringBuilder(value.Length * count);
            for (var i = 0; i < count; i++)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }

        //--------------------------------------------------------------------------------
        // Cut
        //--------------------------------------------------------------------------------

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
