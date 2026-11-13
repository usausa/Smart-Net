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
        writer.Append(CultureInfo.InvariantCulture, $"{name}={123:X4}");

        Assert.Equal("abc=007B", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedSupportsAlignment()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        var name = "abc";
        writer.Append(CultureInfo.InvariantCulture, $"[{name,5}][{name,-5}][{42,6:D4}][{42,-6:D4}][{name,2}]");

        Assert.Equal("[  abc][abc  ][  0042][0042  ][abc]", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedSupportsSpan()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        writer.Append(CultureInfo.InvariantCulture, $"[{"xy".AsSpan()}][{"xy".AsSpan(),4}]");

        Assert.Equal("[xy][  xy]", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedSupportsNonSpanFormattable()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        var nullValue = default(string);
        writer.Append(CultureInfo.InvariantCulture, $"[{DayOfWeek.Monday}][{new Dummy()}][{nullValue}]");

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
    public void AppendInterpolatedWithoutProviderUsesCurrentCulture()
    {
        var culture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
        try
        {
            Span<char> initial = stackalloc char[16];
            var writer = new BufferWriterSlim<char>(initial);

            // ReSharper disable once InvocationIsCultureSensitive
            writer.Append($"{1234.5}");

            Assert.Equal("1234,5", writer.ToStringAndClear());

            writer.Dispose();
        }
        finally
        {
            CultureInfo.CurrentCulture = culture;
        }
    }

    [Fact]
    public void AppendInterpolatedGrowsWhenBufferIsSmall()
    {
        Span<char> initial = stackalloc char[4];
        var writer = new BufferWriterSlim<char>(initial);

        writer.Append(CultureInfo.InvariantCulture, $"{new string('x', 100)}={4321:D8}");

        Assert.Equal(new string('x', 100) + "=00004321", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedObjectHoleUsesTryFormat()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        object value = new SpanOnly();
        IFormattable formattable = new SpanOnly();
        writer.Append(CultureInfo.InvariantCulture, $"[{value}][{formattable}][{new SpanOnly()}]");

        Assert.Equal("[span][span][span]", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedObjectHoleFormatsLikeTypedHole()
    {
        Span<char> initial = stackalloc char[16];
        var writer = new BufferWriterSlim<char>(initial);

        object number = 0xBEEF;
        object date = new DateTime(2026, 8, 8, 1, 2, 3);
        int? nullable = 42;
        int? empty = null;
        writer.Append(CultureInfo.InvariantCulture, $"{number:X8},{date:yyyy-MM-dd HH:mm:ss},{number,8:D},{nullable},{empty}|");

        Assert.Equal("0000BEEF,2026-08-08 01:02:03,   48879,42,|", writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedObjectHoleGrowsWhenBufferIsSmall()
    {
        Span<char> initial = stackalloc char[4];
        var writer = new BufferWriterSlim<char>(initial);

        object value = new LongSpanOnly(1000);
        writer.Append(CultureInfo.InvariantCulture, $"{value}");

        Assert.Equal(new string('z', 1000), writer.ToStringAndClear());

        writer.Dispose();
    }

    [Fact]
    public void AppendInterpolatedObjectHoleDoesNotAllocate()
    {
        var buffer = new char[64];
        object value = 12345;
        AppendObject(buffer, value);

        var before = GC.GetAllocatedBytesForCurrentThread();
        for (var i = 0; i < 100; i++)
        {
            AppendObject(buffer, value);
        }

        Assert.InRange(GC.GetAllocatedBytesForCurrentThread() - before, 0, 99);

        static void AppendObject(char[] buffer, object value)
        {
            var writer = new BufferWriterSlim<char>(buffer);
            writer.Append(CultureInfo.InvariantCulture, $"{value}");
            writer.Dispose();
        }
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

    private sealed class SpanOnly : ISpanFormattable
    {
        public string ToString(string? format, IFormatProvider? formatProvider) => "string";

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
            destination.TryWrite($"span", out charsWritten);
    }

    private sealed class LongSpanOnly : ISpanFormattable
    {
        private readonly int length;

        public LongSpanOnly(int length)
        {
            this.length = length;
        }

        public string ToString(string? format, IFormatProvider? formatProvider) => "string";

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            if (destination.Length < length)
            {
                charsWritten = 0;
                return false;
            }

            destination[..length].Fill('z');
            charsWritten = length;
            return true;
        }
    }
}
