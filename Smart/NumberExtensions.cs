namespace Smart
{
    using System.Runtime.CompilerServices;

    public static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clip(this int value, int minValue, int maxValue)
        {
            return value < minValue ? minValue : (value > maxValue ? maxValue : value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Clip(this long value, long minValue, long maxValue)
        {
            return value < minValue ? minValue : (value > maxValue ? maxValue : value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clip(this double value, double minValue, double maxValue)
        {
            return value < minValue ? minValue : (value > maxValue ? maxValue : value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clip(this float value, float minValue, float maxValue)
        {
            return value < minValue ? minValue : (value > maxValue ? maxValue : value);
        }
    }
}
