namespace Smart.Text;

using System.Runtime.CompilerServices;

public ref struct SpanSplitEnumerator
{
    private readonly ReadOnlySpan<char> span;

    private readonly char separator;

    private int start = 0;

    private int length = -1;

    public SpanSplitEnumerator(ReadOnlySpan<char> span, char separator)
    {
        this.span = span;
        this.separator = separator;
    }

    public readonly SpanSplitEnumerator GetEnumerator() => this;

    public readonly ReadOnlySpan<char> Current => span.Slice(start, length);

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public bool MoveNext()
    {
        start = start + length + 1;

        if ((uint)start > (uint)span.Length)
        {
            return false;
        }

        var remain = span[start..];
        var index = remain.IndexOf(separator);
        length = index >= 0 ? index : remain.Length;

        return true;
    }
}
