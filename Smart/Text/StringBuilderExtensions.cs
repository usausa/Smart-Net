namespace Smart.Text
{
    using System;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="condition"></param>
        /// <param name="valueFactory"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static StringBuilder AppendIf(this StringBuilder sb, bool condition, Func<object> valueFactory)
        {
            if (condition)
            {
                var value = valueFactory();
                sb.Append(value);
            }

            return sb;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static StringBuilder AppendLineIf(this StringBuilder sb, bool condition)
        {
            if (condition)
            {
                sb.AppendLine();
            }

            return sb;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="condition"></param>
        /// <param name="valueFactory"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
        public static StringBuilder AppendLineIf(this StringBuilder sb, bool condition, Func<string> valueFactory)
        {
            if (condition)
            {
                var value = valueFactory();
                if (value != null)
                {
                    sb.AppendLine(value);
                }
            }

            return sb;
        }
    }
}
