namespace Smart
{
    using System;

    public static class NumberExtensions
    {
        public static int Clip(this int value, int minValue, int maxValue)
        {
            return Math.Min(Math.Max(value, minValue), maxValue);
        }

        public static long Clip(this long value, long minValue, long maxValue)
        {
            return Math.Min(Math.Max(value, minValue), maxValue);
        }

        public static double Clip(this double value, double minValue, double maxValue)
        {
            return Math.Min(Math.Max(value, minValue), maxValue);
        }

        public static float Clip(this float value, float minValue, float maxValue)
        {
            return Math.Min(Math.Max(value, minValue), maxValue);
        }
    }
}
