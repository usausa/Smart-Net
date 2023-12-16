namespace Smart.Diagnostics;

using System.Diagnostics;

#pragma warning disable CA1815
public readonly struct StopwatchSlim
{
    private static readonly double TimestampToTicks = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;

    private readonly long start;

    private StopwatchSlim(long start)
    {
        this.start = start;
    }

    public static StopwatchSlim StartNew() => new(Stopwatch.GetTimestamp());

    public TimeSpan Elapsed => new((long)(TimestampToTicks * (Stopwatch.GetTimestamp() - start)));
}
#pragma warning restore CA1815
