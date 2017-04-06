namespace Smart.Threading
{
    using System.Threading;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public class AtomicInteger : IValueHolder<int>
    {
        private int currentValue;

        /// <summary>
        ///
        /// </summary>
        public int Value
        {
            get => Interlocked.Exchange(ref currentValue, currentValue);
            set => Interlocked.Exchange(ref currentValue, value);
        }

        /// <summary>
        ///
        /// </summary>
        public AtomicInteger()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initialValue"></param>
        public AtomicInteger(int initialValue)
        {
            currentValue = initialValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetAndSet(int value)
        {
            return Interlocked.Exchange(ref currentValue, value);
        }
    }
}
