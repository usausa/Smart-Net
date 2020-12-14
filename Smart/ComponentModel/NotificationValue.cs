namespace Smart.ComponentModel
{
    public class NotificationValue<T> : NotificationObject, IValueHolder<T>
    {
        private T? storage;

        public T? Value
        {
            get => storage;
            set => SetProperty(ref storage, value);
        }

        public NotificationValue()
        {
        }

        public NotificationValue(T? value)
        {
            storage = value;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Ignore")]
        public static implicit operator T?(NotificationValue<T> value) => value.Value;

        public override string? ToString() => storage?.ToString();
    }
}
