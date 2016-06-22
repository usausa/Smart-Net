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
            get
            {
                return Interlocked.Exchange(ref currentValue, currentValue) == True;
            }
            set
            {
                Interlocked.Exchange(ref currentValue, value ? True : False);
            }
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
    }
}
