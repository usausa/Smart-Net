namespace Smart.IO;

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[InterpolatedStringHandler]
[StructLayout(LayoutKind.Auto)]
public record struct BufferWriterSlimInterpolatedStringHandler
{
    private const int GuessedLengthPerHole = 11;

    private const int MinimumCapacity = 256;

    private readonly IFormatProvider? provider;

    private char[] buffer;

    private int position;

    internal readonly ReadOnlySpan<char> WrittenSpan => buffer.AsSpan(0, position);

    public BufferWriterSlimInterpolatedStringHandler(int literalLength, int formattedCount)
        : this(literalLength, formattedCount, null)
    {
    }

    public BufferWriterSlimInterpolatedStringHandler(int literalLength, int formattedCount, IFormatProvider? provider)
    {
        this.provider = provider;
        buffer = ArrayPool<char>.Shared.Rent(Math.Max(literalLength + (formattedCount * GuessedLengthPerHole), MinimumCapacity));
    }

    internal void Dispose()
    {
        var toReturn = buffer;
        buffer = [];
        position = 0;
        if (toReturn.Length > 0)
        {
            ArrayPool<char>.Shared.Return(toReturn);
        }
    }

    //--------------------------------------------------------------------------------
    // AppendLiteral
    //--------------------------------------------------------------------------------

    public void AppendLiteral(string value) => Write(value.AsSpan());

    //--------------------------------------------------------------------------------
    // AppendFormatted
    //--------------------------------------------------------------------------------

    public void AppendFormatted(scoped ReadOnlySpan<char> value) => Write(value);

    public void AppendFormatted(scoped ReadOnlySpan<char> value, int alignment)
    {
        var start = position;
        Write(value);
        FixAlignment(start, alignment);
    }

    public void AppendFormatted(string? value)
    {
        if (value is not null)
        {
            Write(value.AsSpan());
        }
    }

    public void AppendFormatted(string? value, int alignment) =>
        AppendFormatted(value.AsSpan(), alignment);

    public void AppendFormatted<T>(T value) =>
        AppendFormatted(value, format: null);

    public void AppendFormatted<T>(T value, string? format)
    {
        if (typeof(ISpanFormattable).IsAssignableFrom(typeof(T)) && (value is not null))
        {
            var hint = 1;
            while (true)
            {
                var span = GetSpan(hint);
                if (((ISpanFormattable)value).TryFormat(span, out var written, format, provider))
                {
                    position += written;
                    return;
                }

                hint = span.Length * 2;
            }
        }

        if (value is IFormattable formattable)
        {
            AppendFormatted(formattable.ToString(format, provider));
        }
        else if (value is not null)
        {
            AppendFormatted(value.ToString());
        }
    }

    public void AppendFormatted<T>(T value, int alignment) =>
        AppendFormatted(value, alignment, null);

    public void AppendFormatted<T>(T value, int alignment, string? format)
    {
        var start = position;
        AppendFormatted(value, format);
        FixAlignment(start, alignment);
    }

    //--------------------------------------------------------------------------------
    // Internal
    //--------------------------------------------------------------------------------

    private void Write(scoped ReadOnlySpan<char> value)
    {
        if (position + value.Length > buffer.Length)
        {
            Grow(value.Length);
        }

        value.CopyTo(buffer.AsSpan(position));
        position += value.Length;
    }

    private Span<char> GetSpan(int sizeHint)
    {
        if (position + sizeHint > buffer.Length)
        {
            Grow(sizeHint);
        }

        return buffer.AsSpan(position);
    }

    private void Grow(int additionalCapacity)
    {
        var newBuffer = ArrayPool<char>.Shared.Rent(Math.Max(position + additionalCapacity, buffer.Length * 2));
        buffer.AsSpan(0, position).CopyTo(newBuffer);
        if (buffer.Length > 0)
        {
            ArrayPool<char>.Shared.Return(buffer);
        }

        buffer = newBuffer;
    }

    private void FixAlignment(int start, int alignment)
    {
        var leftAlign = false;
        if (alignment < 0)
        {
            leftAlign = true;
            alignment = -alignment;
        }

        var written = position - start;
        var padding = alignment - written;
        if (padding <= 0)
        {
            return;
        }

        if (leftAlign)
        {
            GetSpan(padding)[..padding].Fill(' ');
            position += padding;
        }
        else
        {
            _ = GetSpan(padding);
            position += padding;

            var whole = buffer.AsSpan(0, position);
            whole.Slice(start, written).CopyTo(whole.Slice(start + padding, written));
            whole.Slice(start, padding).Fill(' ');
        }
    }
}
