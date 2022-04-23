namespace Smart.IO;

using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

public static class TextReaderExtensions
{
    public static IEnumerable<string> ReadLines(this TextReader reader)
    {
        while (reader.ReadLine() is { } result)
        {
            yield return result;
        }
    }

    public static async IAsyncEnumerable<string> ReadLinesAsync(this TextReader reader)
    {
        while (await reader.ReadLineAsync().ConfigureAwait(false) is { } result)
        {
            yield return result;
        }
    }

    public static async IAsyncEnumerable<string> ReadLinesAsync(this TextReader reader, [EnumeratorCancellation] CancellationToken cancel)
    {
        cancel.ThrowIfCancellationRequested();

        while (await reader.ReadLineAsync().ConfigureAwait(false) is { } result)
        {
            yield return result;

            cancel.ThrowIfCancellationRequested();
        }
    }
}
