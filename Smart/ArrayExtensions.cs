namespace Smart
{
    using System.Runtime.CompilerServices;

    /// <summary>
    ///
    /// </summary>
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void FixLength(ref int length, int remain)
        {
            if (remain < length)
            {
                length = remain;
            }
        }
    }
}
