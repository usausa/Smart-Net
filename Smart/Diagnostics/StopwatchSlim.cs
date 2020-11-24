namespace Smart.Diagnostics
{
    using System;
    using System.Diagnostics;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Justification = "Ignore")]
    public readonly struct StopwatchSlim
    {
        private static readonly double TimestampToTicks = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;

        private readonly long start;

        private StopwatchSlim(long start)
        {
            this.start = start;
        }

        public static StopwatchSlim StartNew() => new StopwatchSlim(Stopwatch.GetTimestamp());

        public TimeSpan GetElapsedTime()
        {
            return new TimeSpan((long)(TimestampToTicks * (Stopwatch.GetTimestamp() - start)));
        }
    }
}
