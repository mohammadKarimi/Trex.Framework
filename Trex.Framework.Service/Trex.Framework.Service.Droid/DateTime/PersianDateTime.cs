using Trex.Framework.Service.Droid.DateTime;

//[assembly: Xamarin.Forms.Dependency(typeof(PersianDateTime))]
namespace Trex.Framework.Service.Droid.DateTime
{
    //using System;
    //using System.Globalization;
    //using Trex.Framework.Core.DateTime;
    //public class PersianDateTime : IPersianDateTime
    //{
    //    /// <summary>
    //    /// System.TimeZoneInfo دریافت تایم زون ایران و قرار دادن آن در آبجکت
    //    /// </summary>
    //    public TimeZoneInfo PersianTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
    //    public Calendar _persianCalendar = new PersianCalendar();

    //    public readonly string[] _dayNames = new string[] { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه" };
    //    public readonly string[] _monthNames = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

    //    public string AM = "ق.ظ";
    //    public string PM = "ب.ظ";

    //    public PersianDateTimeMode Mode = PersianDateTimeMode.UtcOffset;
    //    public TimeSpan DaylightSavingTimeStart = TimeSpan.FromDays(1);
    //    public TimeSpan DaylightSavingTimeEnd = TimeSpan.FromDays(185);
    //    public TimeSpan DaylightSavingTime = TimeSpan.FromHours(1);
    //    public TimeSpan OffsetFromUtc = new TimeSpan(3, 30, 0);


    //    /// <summary>
    //    /// کم کردن 2 عدد تاریخ شمسی از همدیگر
    //    /// </summary>
    //    /// <param name="d1">تاریخ شمسی اولی</param>
    //    /// <param name="d2">تاریخ شمسی دومی</param>
    //    /// <returns>میزان فاصله ی بین این 2 تاریخ</returns>
    //    public static TimeSpan operator -(PersianDateTime d1, PersianDateTime d2)
    //    {
    //        return d1.ToDateTime() - d2.ToDateTime();
    //    }



    //    /// <summary>
    //    /// دریافت نام ماه درخواستی
    //    /// </summary>
    //    /// <param name="month">عدد ماه بین 1 تا 12</param>
    //    /// <returns>نام ماه درخواستی</returns>
    //    public string GetMonthName(int month)
    //    {
    //        return _monthNames[month + 1];
    //    }

    //    /// <summary>
    //    /// دریافت نام روز درخواستی
    //    /// </summary>
    //    /// <param name="day">عدد روز بین 0 تا 6</param>
    //    /// <returns>نام روز درخواستی</returns>
    //    public string GetDayName(int day)
    //    {
    //        return _dayNames[day];
    //    }

    //    /// <summary>
    //    /// تشخیص اینکه آیا سال جاری سال کبیسه هست یا خییر
    //    /// </summary>
    //    /// <param name="year">عدد سال ورودی بین 1 تا 9378</param>
    //    /// <returns>بلی ، در صورتی که سال درخواستی سال کبیسه باشد</returns>
    //    public bool IsLeapYear(int year)
    //    {
    //        return _persianCalendar.IsLeapYear(year);
    //    }

    //    /// <summary>
    //    /// دریافت تعداد روزهای یک سال مشخص
    //    /// </summary>
    //    /// <param name="year">عدد سال ورودی بین 1 تا 9378</param>
    //    /// <returns>چنانچه سال معمولی باشد عدد 365 بازگردانده می شود در غیر این صورت 366</returns>
    //    public int GetDaysInYear(int year)
    //    {
    //        return _persianCalendar.GetDaysInYear(year);
    //    }


    //    public IPersianDateTime Now
    //    {
    //        get
    //        {
    //            switch (Mode)
    //            {
    //                case PersianDateTimeMode.System:
    //                    return new PersianDateTime(DateTime.Now);

    //                case PersianDateTimeMode.PersianTimeZoneInfo:
    //                    return new PersianDateTime(TimeZoneInfo.ConvertTime(DateTime.Now, PersianTimeZoneInfo));


    //                default:
    //                    throw new NotSupportedException(Mode.ToString());
    //            }
    //        }
    //    }

    //    /// <summary>
    //    ///تبدیل تاریخ میلادی به شمسی
    //    /// </summary>
    //    /// <param name="miladiDate">تاریخ میلادی</param>
    //    public IPersianDateTime Parse(DateTime miladiDate)
    //    {
    //        return new PersianDateTime(miladiDate);
    //    }

    //    /// <summary>
    //    /// Converts the specified string representation of a date to its PersianDateTime equivalent.
    //    /// </summary>
    //    /// <param name="persianDate">A string containing a date to convert.</param>
    //    public IPersianDateTime Parse(string persianDate)
    //    {
    //        return Parse(persianDate, "0");
    //    }

    //    /// <summary>
    //    /// Converts the specified string representation of a date and time to its PersianDateTime equivalent.
    //    /// </summary>
    //    /// <param name="persianDate">A string containing a date to convert.</param>
    //    /// <param name="time">A string containing a time to convert.</param>
    //    public IPersianDateTime Parse(string persianDate, string time)
    //    {
    //        return new PersianDateTime(int.Parse(persianDate.Replace("/", "")), int.Parse(time.Replace(":", "")));
    //    }



    //    /// <summary>
    //    /// Gets the year component of the date represented by this instance.
    //    /// </summary>
    //    public int Year
    //    {
    //        get { return _persianCalendar.GetYear(_dateTime); }
    //    }

    //    /// <summary>
    //    /// Gets the month component of the date represented by this instance.
    //    /// </summary>
    //    public int Month
    //    {
    //        get { return _persianCalendar.GetMonth(_dateTime); }
    //    }

    //    /// <summary>
    //    /// Gets the day of the month represented by this instance.
    //    /// </summary>
    //    public int Day
    //    {
    //        get { return _persianCalendar.GetDayOfMonth(_dateTime); }
    //    }

    //    /// <summary>
    //    /// Gets the hour component of the date represented by this instance.
    //    /// </summary>
    //    public int Hour
    //    {
    //        get { return _dateTime.Hour; }
    //    }

    //    /// <summary>
    //    /// Gets the minute component of the date represented by this instance.
    //    /// </summary>
    //    public int Minute
    //    {
    //        get { return _dateTime.Minute; }
    //    }

    //    /// <summary>
    //    /// Gets the seconds component of the date represented by this instance.
    //    /// </summary>
    //    public int Second
    //    {
    //        get { return _dateTime.Second; }
    //    }

    //    /// <summary>
    //    /// Gets the milliseconds component of the date represented by this instance.
    //    /// </summary>
    //    public int Millisecond
    //    {
    //        get { return _dateTime.Millisecond; }
    //    }

    //    /// <summary>
    //    /// Gets the number of ticks that represent the date and time of this instance.
    //    /// </summary>
    //    public long Ticks
    //    {
    //        get { return _dateTime.Ticks; }
    //    }

    //    /// <summary>
    //    /// Gets the time of day for this instance.
    //    /// </summary>
    //    public TimeSpan TimeOfDay
    //    {
    //        get { return _dateTime.TimeOfDay; }
    //    }

    //    /// <summary>
    //    /// Gets the time of year for this instance.
    //    /// </summary>
    //    // public TimeSpan TimeOfYear
    //    // {
    //    //     get { return this - FirstDayOfYear; }
    //    // }



    //    /// <summary>
    //    /// Initializes a new instance of the PersianDateTime class to a specified dateTime.
    //    /// </summary>
    //    /// <param name="dateTime">A date and time in the Gregorian calendar.</param>
    //    public PersianDateTime(DateTime dateTime)
    //    {
    //        _dateTime = dateTime;
    //    }



    //    /// <summary>
    //    /// Initializes a new instance of the PersianDateTime class to the specified persian date and time.
    //    /// </summary>
    //    /// <param name="persianDate">The persian date.</param>
    //    /// <param name="time">The time.</param>
    //    public PersianDateTime( int persianDate, int time)
    //    {
    //        int year = persianDate / 10000;
    //        int month = (persianDate / 100) % 100;
    //        int day = persianDate % 100;

    //        int hour = time / 10000;
    //        int minute = (time / 100) % 100;
    //        int second = time % 100;

    //        _dateTime = _persianCalendar.ToDateTime(year, month, day, hour, minute, second, 0);
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the PersianDateTime class to the specified year, month, and day.
    //    /// </summary>
    //    /// <param name="year">The year (1 through 9999).</param>
    //    /// <param name="month">The month (1 through 12).</param>
    //    /// <param name="day">The day (1 through the number of days in month).</param>
    //    public PersianDateTime( int year, int month, int day)
    //        : this( year, month, day, 0, 0, 0)
    //    {
    //    }

    //    public PersianDateTime(Calendar persianCalendar, TimeZoneInfo persianTimeZone)
    //    {
    //        _persianCalendar = persianCalendar;
    //        PersianTimeZoneInfo = persianTimeZone;
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the PersianDateTime class to the specified year, month, day, hour, minute, and second.
    //    /// </summary>
    //    /// <param name="year">The year (1 through 9999).</param>
    //    /// <param name="month">The month (1 through 12).</param>
    //    /// <param name="day">The day (1 through the number of days in month).</param>
    //    /// <param name="hour">The hours (0 through 23).</param>
    //    /// <param name="minute">The minutes (0 through 59).</param>
    //    /// <param name="second">The seconds (0 through 59).</param>
    //    public PersianDateTime( int year, int month, int day, int hour, int minute, int second)
    //    {
    //        _dateTime = _persianCalendar.ToDateTime(year, month, day, hour, minute, second, 0);
    //    }





    //    /// <summary>
    //    /// Gets the day of the year represented by this instance.
    //    /// </summary>
    //    public int DayOfYear
    //    {
    //        get { return _persianCalendar.GetDayOfYear(_dateTime); }
    //    }

    //    /// <summary>
    //    /// Gets the day of the week represented by this instance.
    //    /// </summary>
    //    public int DayOfWeek
    //    {
    //        get { return ((int)_dateTime.DayOfWeek + 1) % 7; }
    //    }

    //    /// <summary>
    //    /// Gets the name of the day of the week represented by this instance.
    //    /// </summary>
    //    public string DayName
    //    {
    //        get { return _dayNames[DayOfWeek]; }
    //    }

    //    /// <summary>
    //    /// Gets the name of the month represented by this instance.
    //    /// </summary>
    //    public string MonthName
    //    {
    //        get { return _monthNames[Month - 1]; }
    //    }

    //    /// <summary>
    //    /// Gets the date component of this instance.
    //    /// </summary>
    //    public IPersianDateTime Date
    //    {
    //        get { return new PersianDateTime(_dateTime.Date); }
    //    }

    //    /// <summary>
    //    /// Gets the first day of the year represented by this instance.
    //    /// </summary>
    //    public IPersianDateTime FirstDayOfYear
    //    {
    //        get { return AddDays(-DayOfYear + 1).Date; }
    //    }



    //    /// <summary>
    //    /// Gets the first day of the month represented by this instance.
    //    /// </summary>
    //    public IPersianDateTime FirstDayOfMonth
    //    {
    //        get { return AddDays(-Day + 1).Date; }
    //    }



    //    /// <summary>
    //    /// Gets the first day of the week represented by this instance.
    //    /// </summary>
    //    public IPersianDateTime FirstDayOfWeek
    //    {
    //        get { return AddDays(-DayOfWeek).Date; }
    //    }


    //    /// <summary>
    //    /// Returns a new PersianDateTime that adds the specified number of days to the value of this instance.
    //    /// </summary>
    //    /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
    //    /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.</returns>
    //    public IPersianDateTime AddDays(double value)
    //    {
    //        return new PersianDateTime(_dateTime.AddDays(value));
    //    }

    //    /// <summary>
    //    /// Returns a new PersianDateTime that adds the value of the specified System.TimeSpan to the value of this instance.
    //    /// </summary>
    //    /// <param name="value">A positive or negative time interval.</param>
    //    /// <returns>An object whose value is the sum of the date and time represented by this instance and the time interval represented by value.</returns>
    //    public IPersianDateTime Add(TimeSpan value)
    //    {
    //        return new PersianDateTime(_dateTime.Add(value));
    //    }

    //    /// <summary>
    //    /// Returns a System.DateTime object that is set to the date and time represented by this instance.
    //    /// </summary>
    //    /// <returns>A System.DateTime object that is set to the date and time represented by this instance</returns>
    //    public DateTime ToDateTime()
    //    {
    //        return _dateTime;
    //    }

    //    /// <summary>
    //    /// Converts the date represented by this instance to an equivalent 32-bit signed integer.
    //    /// </summary>
    //    /// <returns>n 32-bit signed integer equivalent to the date represented by this instance.</returns>
    //    public int ToInt()
    //    {
    //        return int.Parse(Year.ToString() + Month.ToString().PadLeft(2, '0') + Day.ToString().PadLeft(2, '0'));
    //    }

    //    /// <summary>
    //    /// Converts the value of the current PersianDateTime object to its equivalent string representation.
    //    /// </summary>
    //    /// <returns>A string representation of the value of the current PersianDateTime object.</returns>
    //    public override string ToString()
    //    {
    //        return ToString(PersianDateTimeFormat.DateTime);
    //    }

    //    /// <summary>
    //    /// Converts the value of the current PersianDateTime object to its equivalent string representation using the specified format.
    //    /// </summary>
    //    /// <param name="format">A custom date and time format string.</param>
    //    /// <returns>A string representation of value of the current PersianDateTime object as specified by format.</returns>
    //    public string ToString(string format)
    //    {
    //        string towDigitYear = (Year % 100).ToString();
    //        string month = Month.ToString();
    //        string day = Day.ToString();
    //        string fullHour = Hour.ToString();
    //        string hour = (Hour % 12 == 0 ? 12 : Hour % 12).ToString();
    //        string minute = Minute.ToString();
    //        string second = Second.ToString();
    //        string dayPart = Hour >= 12 ? PM : AM;

    //        return format.Replace("yyyy", Year.ToString())
    //                     .Replace("yy", towDigitYear.PadLeft(2, '0'))
    //                     .Replace("y", towDigitYear)
    //                     .Replace("MMMM", MonthName)
    //                     .Replace("MM", month.PadLeft(2, '0'))
    //                     .Replace("M", month)
    //                     .Replace("dddd", DayName)
    //                     .Replace("ddd", DayName[0].ToString())
    //                     .Replace("dd", day.PadLeft(2, '0'))
    //                     .Replace("d", day)
    //                     .Replace("HH", fullHour.PadLeft(2, '0'))
    //                     .Replace("H", fullHour.ToString())
    //                     .Replace("hh", hour.PadLeft(2, '0'))
    //                     .Replace("h", hour.ToString())
    //                     .Replace("mm", minute.PadLeft(2, '0'))
    //                     .Replace("m", minute.ToString())
    //                     .Replace("ss", second.PadLeft(2, '0'))
    //                     .Replace("s", second)
    //                     .Replace("tt", dayPart)
    //                     .Replace('t', dayPart[0]);
    //    }

    //    /// <summary>
    //    /// Converts the value of the current PersianDateTime object to its equivalent string representation using the specified format.
    //    /// </summary>
    //    /// <param name="format">A persian date and time format string.</param>
    //    /// <returns>A string representation of value of the current PersianDateTime object as specified by format.</returns>
    //    public string ToString(PersianDateTimeFormat format)
    //    {
    //        switch (format)
    //        {
    //            case PersianDateTimeFormat.Date:
    //                return Year.ToString() + "/" + Month.ToString().PadLeft(2, '0') + "/" + Day.ToString().PadLeft(2, '0');

    //            case PersianDateTimeFormat.DateTime:
    //                return ToString(PersianDateTimeFormat.Date) + " " + TimeOfDay.ToHHMMSS();

    //            case PersianDateTimeFormat.DateShortTime:
    //                return ToString(PersianDateTimeFormat.Date) + " " + TimeOfDay.ToHHMM();

    //            case PersianDateTimeFormat.LongDate:
    //                return DayName + " " + Day + " " + MonthName;

    //            case PersianDateTimeFormat.LongDateFullTime:
    //                return DayName + " " + Day + " " + MonthName + " ساعت " + TimeOfDay.ToHHMMSS();

    //            case PersianDateTimeFormat.LongDateLongTime:
    //                return DayName + " " + Day + " " + MonthName + " ساعت " + TimeOfDay.ToHHMM();

    //            case PersianDateTimeFormat.ShortDateShortTime:
    //                return Day.ToString() + " " + MonthName + " " + TimeOfDay.ToHHMM();

    //            case PersianDateTimeFormat.FullDate:
    //                return DayName + " " + Day + " " + MonthName + " " + Year;

    //            case PersianDateTimeFormat.FullDateLongTime:
    //                return DayName + " " + Day + " " + MonthName + " " + Year + " ساعت " + TimeOfDay.ToHHMM();

    //            case PersianDateTimeFormat.FullDateFullTime:
    //                return DayName + " " + Day + " " + MonthName + " " + Year + " ساعت " + TimeOfDay.ToHHMMSS();

    //            default:
    //                throw new NotImplementedException(format.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// Returns the hash code for this instance.
    //    /// </summary>
    //    /// <returns>A 32-bit signed integer hash code.</returns>
    //    public override int GetHashCode()
    //    {
    //        return _dateTime.GetHashCode();
    //    }

    //    public bool Equals(IPersianDateTime value)
    //    {
    //        if (object.ReferenceEquals(value, null))
    //        {
    //            return false;
    //        }
    //        return _dateTime.Equals(value._dateTime);
    //    }


    //    /// <summary>
    //    /// بازگرداندن میزان زمان گذشته از تاریخ ارسالی به فارسی
    //    /// </summary>
    //    /// <param name="dateTime">تاریخ ورودی به میلادی</param>
    //    /// <returns>بازگرداندن میزان زمان گذشته از تاریخ ارسالی به فارسی مانند یک دقیقه قبل</returns>
    //    public string GetRelativeTime(DateTime dateTime)
    //    {
    //        const int SECOND = 1;
    //        const int MINUTE = 60 * SECOND;
    //        const int HOUR = 60 * MINUTE;
    //        const int DAY = 24 * HOUR;
    //        const int MONTH = 30 * DAY;

    //        var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
    //        double delta = Math.Abs(ts.TotalSeconds);
    //        if (delta < 1 * MINUTE)
    //        {
    //            return ts.Seconds == 1 ? "لحظه ای قبل" : ts.Seconds + " ثانیه قبل";
    //        }
    //        if (delta < 2 * MINUTE)
    //        {
    //            return "یک دقیقه قبل";
    //        }
    //        if (delta < 45 * MINUTE)
    //        {
    //            return ts.Minutes + " دقیقه قبل";
    //        }
    //        if (delta < 90 * MINUTE)
    //        {
    //            return "یک ساعت قبل";
    //        }
    //        if (delta < 24 * HOUR)
    //        {
    //            return ts.Hours + " ساعت قبل";
    //        }
    //        if (delta < 48 * HOUR)
    //        {
    //            return "دیروز";
    //        }
    //        if (delta < 30 * DAY)
    //        {
    //            return ts.Days + " روز قبل";
    //        }
    //        if (delta < 12 * MONTH)
    //        {
    //            int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
    //            return months <= 1 ? "یک ماه قبل" : months + " ماه قبل";
    //        }
    //        int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
    //        return years <= 1 ? "یک سال قبل" : years + " سال قبل";
    //    }
    //    private DateTime _privateDateTime;

    //    public DateTime _dateTime
    //    {
    //        get
    //        {
    //            return _privateDateTime;
    //        }
    //        set
    //        {
    //            _privateDateTime = value;
    //        }
    //    }
    //}
}
