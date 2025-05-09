namespace Smart.ComponentModel;

using System.ComponentModel;

public static class NotificationValueExtensions
{
    public static Task<T> WaitValueChangedAsync<T>(this NotificationValue<T> value)
    {
        var cts = new TaskCompletionSource<T>();

        void ValuePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IValueHolder<>.Value))
            {
                return;
            }

            value.PropertyChanged -= ValuePropertyChanged;
            cts.SetResult(value.Value);
        }

        value.PropertyChanged += ValuePropertyChanged;

        return cts.Task;
    }

    public static async Task<T> WaitValueChangedAsync<T>(this NotificationValue<T> value, CancellationToken cancel)
    {
        var cts = new TaskCompletionSource<T>();

        void ValuePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IValueHolder<>.Value))
            {
                return;
            }

            value.PropertyChanged -= ValuePropertyChanged;
            cts.SetResult(value.Value);
        }

#pragma warning disable CA2007
        await using var registration = cancel.Register(() =>
        {
            value.PropertyChanged -= ValuePropertyChanged;
            // ReSharper disable once MethodSupportsCancellation
            cts.SetCanceled();
        });
#pragma warning restore CA2007

        value.PropertyChanged += ValuePropertyChanged;

        var ret = await cts.Task.ConfigureAwait(false);

        return ret;
    }
}
