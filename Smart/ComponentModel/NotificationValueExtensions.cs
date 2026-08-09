namespace Smart.ComponentModel;

using System.ComponentModel;

public static class NotificationValueExtensions
{
    public static Task<T> WaitValueChangedAsync<T>(this NotificationValue<T> value)
    {
        var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

        void ValuePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IValueHolder<>.Value))
            {
                return;
            }

            value.PropertyChanged -= ValuePropertyChanged;
            tcs.TrySetResult(value.Value);
        }

        value.PropertyChanged += ValuePropertyChanged;

        return tcs.Task;
    }

    public static async Task<T> WaitValueChangedAsync<T>(this NotificationValue<T> value, CancellationToken cancel)
    {
        var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

        void ValuePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IValueHolder<>.Value))
            {
                return;
            }

            value.PropertyChanged -= ValuePropertyChanged;
            tcs.TrySetResult(value.Value);
        }

        value.PropertyChanged += ValuePropertyChanged;

#pragma warning disable CA2007
        await using var registration = cancel.Register(() =>
        {
            value.PropertyChanged -= ValuePropertyChanged;
            tcs.TrySetCanceled(cancel);
        });
#pragma warning restore CA2007

        return await tcs.Task.ConfigureAwait(false);
    }
}
