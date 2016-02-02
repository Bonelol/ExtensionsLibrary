using System;

namespace ExtensionsLibrary
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;

            if (diff < 0) diff += 7;

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime UnixTimeStampToDateTime(this string unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp.ToDouble()).ToLocalTime();
            return dtDateTime;
        }
    }
}
