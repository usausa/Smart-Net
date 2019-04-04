namespace Smart
{
    using System;

    public static class Functions<T>
    {
        public static Func<T, T> Identify => x => x;

        public static Func<T, string> String => x => x.ToString();
    }
}
