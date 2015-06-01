using System;
namespace Trex.Framework.Service.Droid.DateTime
{
    interface IPersianDateTime
    {
        global::Trex.Framework.Core.DateTime.PersianDateTime Add(TimeSpan value);
        global::Trex.Framework.Core.DateTime.PersianDateTime AddDays(double value);
        global::Trex.Framework.Core.DateTime.PersianDateTime Date { get; }
        int Day { get; }
        string DayName { get; }
        int DayOfWeek { get; }
        int DayOfYear { get; }
        bool Equals(global::Trex.Framework.Core.DateTime.PersianDateTime value);
        global::Trex.Framework.Core.DateTime.PersianDateTime FirstDayOfMonth { get; }
        global::Trex.Framework.Core.DateTime.PersianDateTime FirstDayOfWeek { get; }
        global::Trex.Framework.Core.DateTime.PersianDateTime FirstDayOfYear { get; }
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
        global::Trex.Framework.Core.DateTime.PersianDateTime Now { get; }
        global::Trex.Framework.Core.DateTime.PersianDateTime Parse(DateTime miladiDate);
        global::Trex.Framework.Core.DateTime.PersianDateTime Parse(string persianDate);
        global::Trex.Framework.Core.DateTime.PersianDateTime Parse(string persianDate, string time);
        int Second { get; }
        long Ticks { get; }
        TimeSpan TimeOfDay { get; }
        TimeSpan TimeOfYear { get; }
        DateTime ToDateTime();
        int ToInt();
        string ToString();
        string ToString(string format);
        string ToString(global::Trex.Framework.Core.DateTime.PersianDateTimeFormat format);
        int Year { get; }
    }
}
