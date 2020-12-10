namespace Smart
{
    using System;

    public static class Functions<T>
    {
        public static Func<T, T> Identify => x => x;

        public static Func<T, string> String => x => x.ToString();

        public static Func<bool, bool> Not => x => !x;

        public static Func<bool, bool, bool> Or => (x, y) => x || y;

        public static Func<bool, bool, bool> And => (x, y) => x && y;
    }
}
