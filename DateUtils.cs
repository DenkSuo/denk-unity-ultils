using System;
using System.Globalization;

namespace Utilities
{
    public class DateUtils
    {

        public static DateTime ParseStringToDate(string str, string format) //"M/d/yyyy H:mm"
        {
            DateTime dateTime;
            DateTime.TryParseExact(str, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);
            return dateTime;
        }

        public static DateTime MilisecondToUtcDate(long milliSec)
        {
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            DateTime parseDate = new DateTime(beginTicks + milliSec * 10000, DateTimeKind.Utc);
            return parseDate;
        }

        public static DateTime SecondToUtcDate(long second)
        {
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            long milliSec = second * 1000;
            DateTime parseDate = new DateTime(beginTicks + milliSec * 10000, DateTimeKind.Utc);
            return parseDate;
        }

        public static DateTime DayToUtcDate(int day)
        {
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            long milliSec = (long) day * 86400000;

            DateTime parseDate = new DateTime(beginTicks + milliSec * 10000, DateTimeKind.Utc);
            //Debug.LogError(parseDate);
            return parseDate;
        }

        public static DateTime HourToUtcDate(int hours)
        {
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            long milliSec = (long) hours * 3600000;
            DateTime parseDate = new DateTime(beginTicks + milliSec * 10000, DateTimeKind.Utc);
            //Debug.LogError(parseDate);
            return parseDate;
        }

        public static int UtcDayNow()
        {
#if !PLAY_INSTANT
            return (int) DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 86400;
#else
        return 0;
#endif
        }

        public static int SecondsToUtcDay(long seconds)
        {
            return (int) (seconds / 86400);
        }

        public static long UtcSecondNow()
        {
#if !PLAY_INSTANT
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
#else
        return 0;
#endif

        }

        public static long UtcMilisecondNow()
        {
#if !PLAY_INSTANT
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
#else
        return 0;
#endif

        }

        public static long DateToUtcSecond(DateTime dateTime)
        {
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
            return (dateTime.Ticks - beginTicks) / 10000000;
        }

        public static string ParseTimeSpanToHHMMSS(TimeSpan span)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", span.Hours, span.Minutes, span.Seconds);
        }

        public static int ToIso8601Weeknumber(DateTime date)
        {
            var thursday = date.AddDays(3 - DayOffset(date.DayOfWeek));
            return (thursday.DayOfYear - 1) / 7 + 1;
        }

        private static int DayOffset(DayOfWeek weekDay)
        {
            return ((int) weekDay + 6) % 7;
        }

        public static string DateToString(DateTime date)
        {
            var now = DateTime.Now;
            if (date.Day == now.Day && date.Month == now.Month && date.Year == now.Year)
                return date.ToString("HH:mm");
           
            return date.ToString("MM/dd/yyyy HH:mm");
        }

        public static DateTime StartOfWeek()
        {
            return DateTime.UtcNow.AddDays(-(int) DateTime.UtcNow.DayOfWeek);
        }
    }
}
