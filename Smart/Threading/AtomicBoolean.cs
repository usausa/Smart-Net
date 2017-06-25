namespace Smart.Threading
{
    using System.Threading;

    using Smart.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public class AtomicBoolean : IValueHolder<bool>
    {
        private const int True = -1;
        private const int False = 0;

        private int currentValue;

        /// <summary>
        ///
        /// </summary>
        public bool Value
        {
            get => currentValue == True;
            set => Interlocked.Exchange(ref currentValue, value ? True : False);
        }

        /// <summary>
        ///
        /// </summary>
        public AtomicBoolean()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="initialValue"></param>
        public AtomicBoolean(bool initialValue)
        {
            currentValue = initialValue ? True : False;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetAndSet(bool value)
        {
            return Interlocked.Exchange(ref currentValue, value ? True : False) == True;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparand"></param>
        /// <returns></returns>
        public bool TrySet(bool value, bool comparand)
        {
            return Interlocked.CompareExchange(ref currentValue, value ? True : False, comparand ? True : False) == (comparand ? True : False);
        }
    }
}
