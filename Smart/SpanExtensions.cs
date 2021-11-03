namespace Smart
{
    using System;
    using System.Runtime.CompilerServices;

    public static class SpanExtensions
    {
        //--------------------------------------------------------------------------------
        // Line
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SplitLinesEnumerator SplitLines(this ReadOnlySpan<char> value) => new(value);

        public ref struct SplitLinesEnumerator
        {
            private ReadOnlySpan<char> remain;

            public ReadOnlySpan<char> Current { get; private set; }

            public SplitLinesEnumerator(ReadOnlySpan<char> remain)
            {
                this.remain = remain;
                Current = default;
            }

            public SplitLinesEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                // No more
                if (remain.Length == 0)
                {
                    return false;
                }

                // Last
                var index = remain.IndexOfAny('\r', '\n');
                if (index == -1)
                {
                    Current = remain;
                    remain = ReadOnlySpan<char>.Empty;
                    return true;
                }

                if ((index < remain.Length - 1) && (remain[index] == '\r') && (remain[index + 1] == '\n'))
                {
                    Current = remain[..index];
                    remain = remain[(index + 2)..];
                    return true;
                }

                Current = remain[..index];
                remain = remain[(index + 1)..];
                return true;
            }
        }
    }
}
