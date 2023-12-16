namespace Smart.ComponentModel;

using System.ComponentModel;
using System.Runtime.CompilerServices;

public abstract class NotificationObject : INotifyPropertyChanged, INotifyPropertyChanging
{
    public event PropertyChangingEventHandler? PropertyChanging;

    public event PropertyChangedEventHandler? PropertyChanged;

#pragma warning disable CA1030
    protected void RaisePropertyChanging([CallerMemberName] string? propertyName = null)
    {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
#pragma warning restore CA1030

#pragma warning disable CA1030
    protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
#pragma warning restore CA1030

    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value))
        {
            return false;
        }

        RaisePropertyChanging(propertyName);
        storage = value;
        RaisePropertyChanged(propertyName);

        return true;
    }

    protected bool SetProperty<T>(ref T storage, T value, IEqualityComparer<T> comparer, [CallerMemberName] string? propertyName = null)
    {
        if (comparer.Equals(storage, value))
        {
            return false;
        }

        RaisePropertyChanging(propertyName);
        storage = value;
        RaisePropertyChanged(propertyName);

        return true;
    }
}
