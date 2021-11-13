namespace Smart.ComponentModel;

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

public static class NotificationValueExtensions
{
    public static Task<T> WaitValueChangedAsync<T>(this NotificationValue<T> value)
    {
        var cts = new TaskCompletionSource<T>();

        void ValuePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IValueHolder<T>.Value))
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
            if (e.PropertyName != nameof(IValueHolder<T>.Value))
            {
                return;
            }

            value.PropertyChanged -= ValuePropertyChanged;
            cts.SetResult(value.Value);
        }

        await using var registration = cancel.Register(() =>
        {
            value.PropertyChanged -= ValuePropertyChanged;
            // ReSharper disable once MethodSupportsCancellation
            cts.SetCanceled();
        });

        value.PropertyChanged += ValuePropertyChanged;

        var ret = await cts.Task.ConfigureAwait(false);

        return ret;
    }
}
