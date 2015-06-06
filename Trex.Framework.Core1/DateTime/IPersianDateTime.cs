namespace Trex.Framework.Core.DateTime
{
    using System;
    public interface IPersianDateTime
    {
        DateTime _dateTime { get; set; }
        IPersianDateTime Add(TimeSpan value);
        IPersianDateTime AddDays(double value);
        IPersianDateTime Date { get; }
        int Day { get; }
        string DayName { get; }
        int DayOfWeek { get; }
        int DayOfYear { get; }
        bool Equals(IPersianDateTime value);
        IPersianDateTime FirstDayOfMonth { get; }
        IPersianDateTime FirstDayOfWeek { get; }
        IPersianDateTime FirstDayOfYear { get; }
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
        IPersianDateTime Now { get; }
        IPersianDateTime Parse(DateTime miladiDate);
        IPersianDateTime Parse(string persianDate);
        IPersianDateTime Parse(string persianDate, string time);
        int Second { get; }
        long Ticks { get; }
        TimeSpan TimeOfDay { get; }

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
