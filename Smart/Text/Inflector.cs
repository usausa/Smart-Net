namespace Smart.Text
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    public static class Inflector
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string Pascalize(string word)
        {
            return Camelize(word, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string Camelize(string word)
        {
            return Camelize(word, false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <param name="toUpper"></param>
        /// <returns></returns>
        public static string Camelize(string word, bool toUpper)
        {
            if (String.IsNullOrEmpty(word))
            {
                return word;
            }

            var sb = new StringBuilder();
            foreach (var c in word)
            {
                if (c == '_')
                {
                    toUpper = true;
                }
                else
                {
                    if (toUpper)
                    {
#if PCL
                        sb.Append(Char.ToUpper(c));
#else
                        sb.Append(Char.ToUpper(c, CultureInfo.InvariantCulture));
#endif
                        toUpper = false;
                    }
                    else
                    {
#if PCL
                        sb.Append(Char.ToLower(c));
#else
                        sb.Append(Char.ToLower(c, CultureInfo.InvariantCulture));
#endif
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string Underscore(string word)
        {
            return Underscore(word, false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <param name="toUpper"></param>
        /// <returns></returns>
        public static string Underscore(string word, bool toUpper)
        {
            if (String.IsNullOrEmpty(word))
            {
                return word;
            }

            var sb = new StringBuilder();
            foreach (var c in word)
            {
                if (Char.IsUpper(c) && (sb.Length > 0))
                {
                    sb.Append("_");
                }

#if PCL
                sb.Append(toUpper ? Char.ToUpper(c) : Char.ToLower(c));
#else
                sb.Append(toUpper ? Char.ToUpper(c, CultureInfo.InvariantCulture) : Char.ToLower(c, CultureInfo.InvariantCulture));
#endif
            }

            return sb.ToString();
        }
    }
}
