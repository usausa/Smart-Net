namespace Smart;

using System.Runtime.CompilerServices;

public static class StringExtensions
{
    //--------------------------------------------------------------------------------
    // Safe
    //--------------------------------------------------------------------------------

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EmptyIfNull(this string? value)
    {
        return value ?? string.Empty;
    }
}
