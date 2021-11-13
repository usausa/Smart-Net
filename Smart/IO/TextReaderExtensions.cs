namespace Smart.IO;

using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

public static class TextReaderExtensions
{
    public static IEnumerable<string> ReadLines(this TextReader reader)
    {
        string? result;
        while ((result = reader.ReadLine()) is not null)
        {
            yield return result;
        }
    }

    public static async IAsyncEnumerable<string> ReadLinesAsync(this TextReader reader)
    {
        string? result;
        while ((result = await reader.ReadLineAsync().ConfigureAwait(false)) is not null)
        {
            yield return result;
        }
    }

    public static async IAsyncEnumerable<string> ReadLinesAsync(this TextReader reader, [EnumeratorCancellation] CancellationToken cancel)
    {
        cancel.ThrowIfCancellationRequested();

        string? result;
        while ((result = await reader.ReadLineAsync().ConfigureAwait(false)) is not null)
        {
            yield return result;

            cancel.ThrowIfCancellationRequested();
        }
    }
}
