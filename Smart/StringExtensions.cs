namespace Smart
{
    using System.Text;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
    public static class StringExtensions
    {
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
    }
}
