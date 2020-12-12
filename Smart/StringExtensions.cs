namespace Smart
{
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
    }
}
