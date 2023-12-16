namespace Smart.Text;

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

    public bool MoveNext()
    {
        start = start + length + 1;

        if (span.Length < start)
        {
            return false;
        }

        var index = span[start..].IndexOf(separator);
        length = index > 0 ? index : span.Length - start;

        return true;
    }
}
