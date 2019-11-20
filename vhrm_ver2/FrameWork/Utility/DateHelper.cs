using System;
using System.Globalization;

namespace vhrm.FrameWork.Utility
{
    [Serializable]
    public class DateHelper
    {
        
        public static DateTime getWednesday_Week(int year, int weekOfYear)
        {
            DateTime d1 = DateHelper.getFirstDateOfWeek_DT(year, weekOfYear);
            DateTime d2 = DateHelper.getLastDateOfWeek_DT(year, weekOfYear);
            DateTime d = new DateTime();
            while (d1 <= d2)
            {
                if (d1.ToString("dddd").ToLower() == "wednesday")
                {
                    d = d1;
                }
                d1 = d1.AddDays(1);
            }
            return d;
        }
        public static string getWeekOfYear(DateTime dt)
        {
            CultureInfo myCI = CultureInfo.CurrentUICulture;
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int week = myCal.GetWeekOfYear(dt, myCWR, myFirstDOW);
            return week.ToString();
        }
        public static DateTime getFirstDatesOfMonth_DT(int month, int year)
        {
            DateTime dtmReturn = new DateTime();
            dtmReturn = new DateTime(year, month, 1);
            //dtmReturn.g
            return dtmReturn;
        }
        public static DateTime getLastDatesOfMonth_DT(int month, int year)
        {
            DateTime dtmReturn = new DateTime();
            int intLastDay = DateTime.DaysInMonth(year, month);
            dtmReturn = new DateTime(year, month, intLastDay);
            return dtmReturn;
        }
        public static DateTime getFirstDateOfWeek_DT(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset);
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1)
            {
                weekOfYear -= 1;
            }
            firstMonday = firstMonday.AddDays(weekOfYear * 7);
            return firstMonday;
        }
        public static DateTime getLastDateOfWeek_DT(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset);
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1)
            {
                weekOfYear -= 1;
            }
            firstMonday = firstMonday.AddDays(weekOfYear * 7);
            firstMonday = firstMonday.AddDays(6);
            return firstMonday;
        }

        //check string is DateTime dd/MM/yyyy, dd-MM-yyyy, yyyy-MM-dd
        public static bool IsDateTime(string strDateTime)
        {
            CultureInfo culInfo = new CultureInfo("vi-VN");
            if (string.IsNullOrEmpty(strDateTime))
                return false;

            try
            {
                DateTime _datetime = DateTime.Parse(strDateTime, culInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Convert from string to DateTime With format
        public static DateTime? convertStrToDate(string source, string format)
        {
            return DateTime.ParseExact(source, format, null);
        }

    }
}
