namespace Smart;

#pragma warning disable CA1000
public static class Functions<T>
{
    public static Func<T, T> Identity => static x => x;

#pragma warning disable CA1720
    public static Func<T, string?> String => static x => x?.ToString();
#pragma warning restore CA1720
}
#pragma warning restore CA1000

public static class Functions
{
    public static Func<bool, bool> Not => static x => !x;

    public static Func<bool, bool, bool> And => static (x, y) => x && y;

    public static Func<bool, bool, bool> Or => static (x, y) => x || y;

    public static Func<bool, bool, bool> Xor => static (x, y) => x ^ y;
}
