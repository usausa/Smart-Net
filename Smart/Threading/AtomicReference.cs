namespace Smart.Threading
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using Smart.ComponentModel;

    public sealed class AtomicReference<T> : IValueHolder<T>
        where T : class
    {
        [AllowNull]
        private T currentValue;

        public T Value
        {
            get => currentValue;
            set => Interlocked.Exchange(ref currentValue, value);
        }

        public AtomicReference()
        {
        }

        public AtomicReference(T initialValue)
        {
            currentValue = initialValue;
        }

        public T GetAndSet(T value)
        {
            return Interlocked.Exchange(ref currentValue, value);
        }

        public bool TrySet(T value, T comparand)
        {
            return Interlocked.CompareExchange(ref currentValue, value, comparand) == comparand;
        }
    }
}
