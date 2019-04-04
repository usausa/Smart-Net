namespace Smart.Threading
{
    using System.Threading;

    using Smart.ComponentModel;

    public sealed class AtomicBoolean : IValueHolder<bool>
    {
        private const int True = -1;
        private const int False = 0;

        private int currentValue;

        public bool Value
        {
            get => currentValue == True;
            set => Interlocked.Exchange(ref currentValue, value ? True : False);
        }

        public AtomicBoolean()
        {
        }

        public AtomicBoolean(bool initialValue)
        {
            currentValue = initialValue ? True : False;
        }

        public bool GetAndSet(bool value)
        {
            return Interlocked.Exchange(ref currentValue, value ? True : False) == True;
        }

        public bool TrySet(bool value, bool comparand)
        {
            return Interlocked.CompareExchange(ref currentValue, value ? True : False, comparand ? True : False) == (comparand ? True : False);
        }
    }
}
