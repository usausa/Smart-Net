namespace Smart.Diagnostics
{
    public static class DebugMode
    {
        public static bool IsTrue
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
}
