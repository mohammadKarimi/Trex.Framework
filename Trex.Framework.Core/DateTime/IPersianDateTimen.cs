namespace Trex.Framework.Core.DateTime
{
    using System;
    interface IPersianDateTimen
    {
        IPersianDateTimen Add(TimeSpan value);
        IPersianDateTimen AddDays(double value);
        IPersianDateTimen Date { get; }
        int Day { get; }
        string DayName { get; }
        int DayOfWeek { get; }
        int DayOfYear { get; }
        bool Equals(IPersianDateTimen value);
        IPersianDateTimen FirstDayOfMonth { get; }
        IPersianDateTimen FirstDayOfWeek { get; }
        IPersianDateTimen FirstDayOfYear { get; }
        string GetDayName(int day);
        int GetDaysInYear(int year);
        int GetHashCode();
        string GetMonthName(int month);
        string GetRelativeTime(DateTime dateTime);
        int Hour { get; }
        bool IsLeapYear(int year);
        int Millisecond { get; }
        int Minute { get; }
        int Month { get; }
        string MonthName { get; }
        IPersianDateTimen Now { get; }
        IPersianDateTimen Parse(DateTime miladiDate);
        IPersianDateTimen Parse(string persianDate);
        IPersianDateTimen Parse(string persianDate, string time);
        int Second { get; }
        long Ticks { get; }
        TimeSpan TimeOfDay { get; }
        TimeSpan TimeOfYear { get; }
        DateTime ToDateTime();
        int ToInt();
        string ToString();
        string ToString(string format);
        string ToString(PersianDateTimeFormat format);
        int Year { get; }
    }

    public enum PersianDateTimeFormat
    {
        Date = 0,
        DateTime = 1,
        LongDate = 2,
        LongDateLongTime = 3,
        FullDate = 4,
        FullDateLongTime = 5,
        FullDateFullTime = 6,
        DateShortTime = 7,
        ShortDateShortTime = 8,
        LongDateFullTime = 9
    }

    public enum PersianDateTimeMode
    {
        /// <summary>
        /// استفاده از تایم زون جاری
        /// </summary>
        System,
        /// <summary>
        /// استفاده از تایم زون شمسی
        /// </summary>
        PersianTimeZoneInfo,
        /// <summary>
        ///استفاده از Utc
        /// </summary>
        UtcOffset
    }
}
