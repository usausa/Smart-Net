namespace Smart
{
    using System;

    public static class DateTimeExtensions
    {
        public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
        {
            return date.Date == dateToCompare.Date;
        }

        public static bool IsTimeEqual(this DateTime time, DateTime timeToCompare)
        {
            return time.TimeOfDay == timeToCompare.TimeOfDay;
        }

        public static bool IsLeapYear(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, 2) == 29;
        }

        public static DateTime OfTime(this DateTime date, int hour, int minute, int second)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }
    }
}
