namespace Smart.IO;

using System.Globalization;

public sealed class BufferWriterSlimExtensionsTests
{
    //--------------------------------------------------------------------------------
    // WriteLine
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteLineAppendsNewLine()
    {
        Span<char> initial = stackalloc char[32];
        var writer = new BufferWriterSlim<char>(initial);

        writer.WriteLine("abc");
        writer.WriteLine();

        Assert.Equal("abc" + Environment.NewLine + Environment.NewLine, writer.ToStringAndClear());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // WriteFormattable
    //--------------------------------------------------------------------------------

    [Fact]
    public void WriteFormattableWritesValue()
    {
        Span<char> initial = stackalloc char[32];
        var writer = new BufferWriterSlim<char>(initial);

        writer.WriteFormattable(0xBEEF, "X8");
        writer.WriteFormattable(new DateTime(2026, 8, 8, 1, 2, 3), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        Assert.Equal("0000BEEF2026-08-08 01:02:03", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void WriteFormattableGrowsWhenBufferIsSmall()
    {
        Span<char> initial = stackalloc char[2];
        var writer = new BufferWriterSlim<char>(initial);

        writer.WriteFormattable(123456789, default, CultureInfo.InvariantCulture);

        Assert.Equal("123456789", writer.ToStringAndClear());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Append
    //--------------------------------------------------------------------------------

    [Fact]
    public void AppendWritesString()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        var nullValue = default(string);
        writer.Append("abc");
        writer.Append(nullValue);
        writer.Append(string.Empty);

        Assert.Equal("abc", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedFormatsValues()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        var name = "abc";
        writer.Append($"{name}={123:X4}");

        Assert.Equal("abc=007B", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedSupportsAlignment()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        var name = "abc";
        writer.Append($"[{name,5}][{name,-5}][{42,6:D4}][{42,-6:D4}][{name,2}]");

        Assert.Equal("[  abc][abc  ][  0042][0042  ][abc]", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedSupportsSpan()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        writer.Append($"[{"xy".AsSpan()}][{"xy".AsSpan(),4}]");

        Assert.Equal("[xy][  xy]", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedSupportsNonSpanFormattable()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        var nullValue = default(string);
        writer.Append($"[{DayOfWeek.Monday}][{new Dummy()}][{nullValue}]");

        Assert.Equal("[Monday][dummy][]", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedWithProviderFormatsValues()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        writer.Append(CultureInfo.InvariantCulture, $"{1234.5}");

        Assert.Equal("1234.5", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedGrowsWhenBufferIsSmall()
    {
        Span<char> initial = stackalloc char[4];
        var writer = new BufferWriterSlim<char>(initial);

        writer.Append($"{new string('x', 100)}={4321:D8}");

        Assert.Equal(new string('x', 100) + "=00004321", writer.ToStringAndClear());

        writer.Dispose();
    }

    //--------------------------------------------------------------------------------
    // ToStringAndClear
    //--------------------------------------------------------------------------------

    [Fact]
    public void ToStringAndClearResetsWriter()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        writer.Append("abc");

        Assert.Equal("abc", writer.ToStringAndClear());
        Assert.Equal(0, writer.WrittenCount);

        writer.Append("def");

        Assert.Equal("def", writer.ToStringAndClear());

        writer.Dispose();
    }

    private sealed class Dummy
    {
        public override string ToString() => "dummy";
    }
}
