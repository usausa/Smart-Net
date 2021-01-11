namespace Smart.Diagnostics
{
    public static class DebugMode
    {
#if DEBUG
        public static bool IsTrue => true;
#else
        public static bool IsTrue => false;
#endif
    }
}
