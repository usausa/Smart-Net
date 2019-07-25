namespace Smart.IO
{
    using System.Collections.Generic;
    using System.IO;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Extensions")]
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
