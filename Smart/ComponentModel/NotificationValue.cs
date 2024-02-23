namespace Smart.ComponentModel;

public class NotificationValue<T> : NotificationObject, IValueHolder<T>
{
    private T storage = default!;

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

#pragma warning disable CA2225
    public static implicit operator T(NotificationValue<T> value) => value.Value;
#pragma warning restore CA2225

    public override string? ToString() => storage?.ToString();
}
