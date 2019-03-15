namespace Smart
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateToCompare"></param>
        /// <returns></returns>
        public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
        {
            return date.Date == dateToCompare.Date;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timeToCompare"></param>
        /// <returns></returns>
        public static bool IsTimeEqual(this DateTime time, DateTime timeToCompare)
        {
            return time.TimeOfDay == timeToCompare.TimeOfDay;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, 2) == 29;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Tomorrow(this DateTime date)
        {
            return date.AddDays(1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime OfTime(this DateTime date, int hour, int minute, int second)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }
    }
}
