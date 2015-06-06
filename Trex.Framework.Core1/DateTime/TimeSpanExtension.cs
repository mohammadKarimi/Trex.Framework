using System;

namespace Trex.Framework.Core.DateTime
{
    /// <summary>
    /// کلاسی برای تبدیل تایم استمپ به نوع های دیگر
    /// </summary>
    public static class TimeSpanExtension
    {
        /// <summary>
        /// متد الحاقی تبدیل تایم استمپ به عدد
        /// </summary>
        /// <param name="time">تایم ورودی</param>
        /// <returns>عدد</returns>
        public static int ToInteger(this TimeSpan time)
        {
            return int.Parse(time.Hours.ToString() + time.Minutes.ToString().PadLeft(2, '0') + time.Seconds.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// متد الحاقی تبدیل تایم استمپ به عدد
        /// </summary>
        /// <param name="time">تایم ورودی</param>
        /// <returns>عدد</returns>
        public static short ToShort(this TimeSpan time)
        {
            return short.Parse(time.Hours.ToString() + time.Minutes.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// متد الحاقی تبدیل تایم استمپ به استرینگ
        /// </summary>
        /// <param name="time">تایم ورودی</param>
        /// <returns> hh:mm استرینگ با فرمت </returns>
        public static string ToHHMM(this TimeSpan time)
        {
            return time.ToString("hh\\:mm");
        }

        /// <summary>
        /// متد الحاقی تبدیل تایم استمپ به استرینگ
        /// </summary>
        /// <param name="time">تایم ورودی</param>
        /// <returns> hh:mm:ss استرینگ با فرمت </returns>
        public static string ToHHMMSS(this TimeSpan time)
        {
            return time.ToString("hh\\:mm\\:ss");
        }
    }
}

