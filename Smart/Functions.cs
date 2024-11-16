namespace Smart;

public static class Functions<T>
{
    public static Func<T, T> Identify => static x => x;

    public static Func<T, string?> String => static x => x?.ToString();
}

public static class Functions
{
    public static Func<bool, bool> Not => static x => !x;

    public static Func<bool, bool, bool> And => static (x, y) => x && y;

    public static Func<bool, bool, bool> Or => static (x, y) => x || y;

    public static Func<bool, bool, bool> Xor => static (x, y) => x ^ y;
}
