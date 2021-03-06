namespace Smart.ComponentModel
{
    using System.Diagnostics.CodeAnalysis;

    public class NotificationValue<T> : NotificationObject, IValueHolder<T>
    {
        [AllowNull]
        private T storage;

        public T Value
        {
            get => storage;
            set => SetProperty(ref storage, value);
        }

        public NotificationValue()
        {
        }

        public NotificationValue(T value)
        {
            storage = value;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Ignore")]
        public static implicit operator T(NotificationValue<T> value) => value.Value;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1508", Justification = "Analyzers bug ?")]
        public override string? ToString() => storage?.ToString();
    }
}
