namespace Smart.Text
{
    using System;
    using System.Runtime.CompilerServices;

    public static class Inflector
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Pascalize(string word) => Camelize(word, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Camelize(string word) => Camelize(word, false);

        public static unsafe string Camelize(string word, bool toUpper)
        {
            if (word.Length == 0)
            {
                return word;
            }

            var buffer = word.Length < 2048 ? stackalloc char[word.Length] : new char[word.Length];
            var length = 0;

            fixed (char* pBuffer = buffer)
            {
                var isLowerPrevious = false;
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
                            pBuffer[length++] = Char.ToUpperInvariant(c);
                            toUpper = false;
                        }
                        else if (isLowerPrevious)
                        {
                            pBuffer[length++] = c;
                        }
                        else
                        {
                            pBuffer[length++] = Char.ToLowerInvariant(c);
                        }

                        isLowerPrevious = Char.IsLower(c);
                    }
                }

                return new string(pBuffer, 0, length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Underscore(string word)
        {
            return Underscore(word, false);
        }

        public static unsafe string Underscore(string word, bool toUpper)
        {
            if (word.Length == 0)
            {
                return word;
            }

            var bufferSize = word.Length << 1;
            var buffer = bufferSize < 2048 ? stackalloc char[bufferSize] : new char[bufferSize];
            var length = 0;

            fixed (char* pBuffer = buffer)
            {
                if (toUpper)
                {
                    foreach (var c in word)
                    {
                        if (Char.IsUpper(c))
                        {
                            if (length > 0)
                            {
                                pBuffer[length++] = '_';
                            }

                            pBuffer[length++] = c;
                        }
                        else
                        {
                            pBuffer[length++] = Char.ToUpperInvariant(c);
                        }
                    }
                }
                else
                {
                    foreach (var c in word)
                    {
                        if (Char.IsUpper(c))
                        {
                            if (length > 0)
                            {
                                pBuffer[length++] = '_';
                            }

                            pBuffer[length++] = Char.ToLowerInvariant(c);
                        }
                        else
                        {
                            pBuffer[length++] = c;
                        }
                    }
                }

                return new string(pBuffer, 0, length);
            }
        }
    }
}
