namespace Smart.IO
{
    using System.Collections.Generic;
    using System.IO;
#if !NETSTANDARD2_0
    using System.Runtime.CompilerServices;
    using System.Threading;
#endif

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

#if !NETSTANDARD2_0
        public static async IAsyncEnumerable<string> ReadLinesAsync(this TextReader reader)
        {
            string result;
            while ((result = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                yield return result;
            }
        }

        public static async IAsyncEnumerable<string> ReadLinesAsync(this TextReader reader, [EnumeratorCancellation] CancellationToken cancel)
        {
            cancel.ThrowIfCancellationRequested();

            string result;
            while ((result = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                yield return result;

                cancel.ThrowIfCancellationRequested();
            }
        }
#endif
    }
}
