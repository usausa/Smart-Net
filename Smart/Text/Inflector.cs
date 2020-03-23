namespace Smart.Text
{
    using System;
    using System.Globalization;
    using System.Text;

    public static class Inflector
    {
        public static string Pascalize(string word) => Camelize(word, true);

        public static string Camelize(string word) => Camelize(word, false);

        public static string Camelize(string word, bool toUpper)
        {
            if (String.IsNullOrEmpty(word))
            {
                return word;
            }

            var isLowerPrevious = false;
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
                        sb.Append(Char.ToUpper(c, CultureInfo.CurrentCulture));
                        toUpper = false;
                    }
                    else if (isLowerPrevious)
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        sb.Append(Char.ToLower(c, CultureInfo.CurrentCulture));
                    }

                    isLowerPrevious = Char.IsLower(c);
                }
            }

            return sb.ToString();
        }

        public static string Underscore(string word)
        {
            return Underscore(word, false);
        }

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

                sb.Append(toUpper ? Char.ToUpper(c, CultureInfo.CurrentCulture) : Char.ToLower(c, CultureInfo.CurrentCulture));
            }

            return sb.ToString();
        }
    }
}
