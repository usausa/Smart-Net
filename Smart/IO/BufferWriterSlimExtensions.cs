namespace Smart.IO;

using System.Runtime.CompilerServices;

public static class BufferWriterSlimExtensions
{
    //--------------------------------------------------------------------------------
    // WriteLine
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteLine(this ref BufferWriterSlim<char> writer) =>
        writer.Write(Environment.NewLine.AsSpan());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteLine(this ref BufferWriterSlim<char> writer, scoped ReadOnlySpan<char> value)
    {
        writer.Write(value);
        writer.Write(Environment.NewLine.AsSpan());
    }

    //--------------------------------------------------------------------------------
    // WriteFormattable
    //--------------------------------------------------------------------------------

    public static void WriteFormattable<T>(this ref BufferWriterSlim<char> writer, T value, scoped ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
        where T : ISpanFormattable
    {
        var hint = 0;
        while (true)
        {
            var span = writer.GetSpan(hint);
            if (value.TryFormat(span, out var written, format, provider))
            {
                writer.Advance(written);
                return;
            }

            hint = span.Length * 2;
        }
    }

    //--------------------------------------------------------------------------------
    // Append
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Append(this ref BufferWriterSlim<char> writer, string? value)
    {
        if (!String.IsNullOrEmpty(value))
        {
            writer.Write(value.AsSpan());
        }
    }

    public static void Append(this ref BufferWriterSlim<char> writer, ref BufferWriterSlimInterpolatedStringHandler handler)
    {
        writer.Write(handler.WrittenSpan);
        handler.Dispose();
    }

    public static void Append(this ref BufferWriterSlim<char> writer, IFormatProvider? provider, [InterpolatedStringHandlerArgument(nameof(provider))] ref BufferWriterSlimInterpolatedStringHandler handler)
    {
        _ = provider;
        writer.Write(handler.WrittenSpan);
        handler.Dispose();
    }

    //--------------------------------------------------------------------------------
    // ToString
    //--------------------------------------------------------------------------------

    public static string ToStringAndClear(this ref BufferWriterSlim<char> writer)
    {
        var result = new string(writer.WrittenSpan);
        writer.Clear();
        return result;
    }
}
