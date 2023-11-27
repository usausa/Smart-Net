namespace Smart.IO;

using System.Runtime.CompilerServices;

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

#if NET8_0_OR_GREATER
        while (await reader.ReadLineAsync(cancel).ConfigureAwait(false) is { } result)
#else
        while (await reader.ReadLineAsync().ConfigureAwait(false) is { } result)
#endif
        {
            yield return result;

            cancel.ThrowIfCancellationRequested();
        }
    }
}
