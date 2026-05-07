namespace Smart.Text;

using System.Runtime.CompilerServices;

public ref struct SpanTokenizer<T>
    where T : IEquatable<T>
{
    private readonly ReadOnlySpan<T> span;

    private readonly T separator;

    private int start;

    private int end;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SpanTokenizer(ReadOnlySpan<T> span, T separator)
    {
        this.span = span;
        this.separator = separator;
        start = 0;
        end = -1;
    }

    public readonly SpanTokenizer<T> GetEnumerator() => this;

    public readonly ReadOnlySpan<T> Current
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => span.Slice(start, end - start);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        var newStart = end + 1;
        if ((uint)newStart > (uint)span.Length)
        {
            return false;
        }

        start = newStart;
        var index = span[newStart..].IndexOf(separator);
        end = index >= 0 ? newStart + index : span.Length;

        return true;
    }
}
