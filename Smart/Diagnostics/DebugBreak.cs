namespace Smart.Diagnostics;

using System.Diagnostics;

public static class DebugBreak
{
    [DebuggerHidden]
    [Conditional("DEBUG")]
    public static void If(bool condition)
    {
        if (condition)
        {
            Debugger.Break();
        }
    }
}
