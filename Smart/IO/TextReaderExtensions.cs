namespace Smart.IO
{
    using System.Collections.Generic;
    using System.IO;

    public static class TextReaderExtensions
    {
        public static IEnumerable<string> ReadLines(this TextReader reader)
        {
            string result;
            while ((result = reader.ReadLine()) != null)
            {
                yield return result;
            }
        }
    }
}
