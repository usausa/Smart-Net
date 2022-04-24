namespace Smart;

using System.Runtime.CompilerServices;

public static class DateTimeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
    {
        return date.Date == dateToCompare.Date;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsTimeEqual(this DateTime time, DateTime timeToCompare)
    {
        return time.TimeOfDay == timeToCompare.TimeOfDay;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLeapYear(this DateTime date)
    {
        return DateTime.DaysInMonth(date.Year, 2) == 29;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime OfTime(this DateTime date, int hour, int minute, int second)
    {
        return new(date.Year, date.Month, date.Day, hour, minute, second);
    }
}
