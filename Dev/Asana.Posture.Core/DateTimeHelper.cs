namespace NsTasks.Core
{
    #region

	using System;

	#endregion

    public static class DateTimeHelper
    {
        #region Public Methods

        public static DateTime AddQuarter(int quarters, DateTime origin)
        {
            var months = quarters * 3;
            return FirstDayOfQuarter(origin.AddMonths(months));
        }

        public static DateTime AddWorkDays(int days, DateTime theDate)
        {
            var direction = 1;
            if (days < 0)
            {
                direction = -direction;
            }

            // INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of days for every iteration:
            var tempFor1 = days;
            for (var dayToAdd = 1; dayToAdd <= tempFor1; dayToAdd++)
            {
                theDate = theDate.AddDays(direction);
                while (theDate.DayOfWeek == DayOfWeek.Saturday | theDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    theDate = theDate.AddDays(direction);
                }
            }

            return theDate;
        }

        public static DateTime BeginningOfFiscalYearDate(DateTime inputDate, DateTime currentFiscalBeginDate)
        {
            DateTime newDate;
            DateTime dteTemp;

            if (inputDate.DayOfYear < currentFiscalBeginDate.DayOfYear)
            {
                dteTemp = inputDate;
                dteTemp = dteTemp.AddYears(-1);
                newDate = new DateTime(dteTemp.Year, currentFiscalBeginDate.Month, currentFiscalBeginDate.Day);
            }
            else
            {
                dteTemp = inputDate;
                newDate = new DateTime(dteTemp.Year, currentFiscalBeginDate.Month, currentFiscalBeginDate.Day);
            }

            return newDate;
        }

        public static DateTime DateTimeFromString(string year, string month, string day)
        {
            var validDate = new DateTime();
            IsDate(month + ("/" + (day + ("/" + year))), ref validDate);
            return validDate;
        }

        public static DateTime FirstDayOfQuarter(DateTime day)
        {
            return new DateTime(day.Year, FirstMonthOfQuarter(Quarter(day)), 1);
        }

        public static int FirstMonthOfQuarter(int qtr)
        {
            if (qtr == 1)
            {
                return 1;
            }

            if (qtr == 2)
            {
                return 4;
            }

            if (qtr == 3)
            {
                return 7;
            }

            if (qtr == 4)
            {
                return 10;
            }

            return 0;
        }



        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }



        public static DateTime GetEndOfCurrentWeek()
        {
            var dt = GetStartOfCurrentWeek().AddDays(6);
            return GetEndOfDay(dt);
        }

        public static DateTime GetEndOfCurrentWorkWeek()
        {
            var dt = GetEndOfCurrentWeek().AddDays(-1);
            return dt;
        }

        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }

        public static DateTime GetEndOfDay(DateTime theDate)
        {
            return new DateTime(theDate.Year, theDate.Month, theDate.Day, 23, 59, 59, 999);
        }

        public static DateTime GetEndOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
            {
                return GetEndOfMonth(12, DateTime.Now.Year - 1);
            }
            else
            {
                return GetEndOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
            }
        }


        public static DateTime GetEndOfLastWeek()
        {
            var dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetEndOfMonth(int Month, int Year)
        {
            if (Month < 1)
            {
                throw new ArgumentException("Month < 1", "Month");
            }

            if (Month > 12)
            {
                throw new ArgumentException("Month > 12", "Month");
            }

            if (Year < 1)
            {
                throw new ArgumentException("Year < 1", "Year");
            }

            if (Year > 9999)
            {
                throw new ArgumentException("Year > 12", "Year");
            }

            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month), 23, 59, 59, 999);
        }


        public static DateTime GetEndOfWeek(DateTime dayInWeek)
        {
            return GetEndOfDay(GetStartOfWeek(dayInWeek).AddDays(6));
        }

        public static DateTime GetEndOfWorkWeek(DateTime dayInWeek)
        {
            return GetEndOfWeek(dayInWeek).AddDays(-1);
        }

        public static DateTime GetEndOfYear(int Year)
        {
            return new DateTime(Year, 12, 31, 23, 59, 59, 999);
        }



        public static string GetShortDateOrEmptyString(DateTime? nullableDateTime)
        {
            return nullableDateTime.HasValue ? nullableDateTime.Value.ToShortDateString() : string.Empty;
        }

        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }


        public static DateTime GetStartOfCurrentWeek()
        {
            return GetStartOfWeek(DateTime.Now);
        }

        public static DateTime GetStartOfCurrentWorkWeek()
        {
            var dt = GetStartOfCurrentWeek().AddDays(1);
            return dt;
        }

        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        public static DateTime GetStartOfDay(DateTime theDate)
        {
            return new DateTime(theDate.Year, theDate.Month, theDate.Day, 0, 0, 0, 0);
        }

        public static DateTime GetStartOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
            {
                return GetStartOfMonth(12, DateTime.Now.Year - 1);
            }
            else
            {
                return GetStartOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
            }
        }


        public static DateTime GetStartOfLastWeek()
        {
            var DaysToSubtract = Convert.ToInt32(DateTime.Now.DayOfWeek) + 7;
            var dt = DateTime.Now.Subtract(TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetStartOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, 1, 0, 0, 0, 0);
        }


        public static DateTime GetStartOfWeek(DateTime dayInWeek)
        {
            var DaysToSubtract = Convert.ToInt32(dayInWeek.DayOfWeek);
            var dt = dayInWeek.Subtract(TimeSpan.FromDays(DaysToSubtract));
            return GetStartOfDay(dt);
        }

        public static DateTime GetStartOfWorkWeek(DateTime dayInWeek)
        {
            return GetStartOfWeek(dayInWeek).AddDays(1);
        }

        public static DateTime GetStartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        public static bool IsDate(string dateAsString)
        {
            var pointlessDateTime = new DateTime();
            return IsDate(dateAsString, ref pointlessDateTime);
        }

        public static bool IsDate(string dateString, ref DateTime validDate)
        {
            var isValid = true;
            try
            {
                validDate = DateTime.Parse(dateString);
            }
            catch (Exception)
            {
                isValid = false;
                validDate = DateTime.Now;
            }

            return isValid;
        }

        public static string MonthAndYearStamp(int month, int year)
        {
            return string.Format("(0)/(1)", month, year);
        }

        public static DateTime? ParseNullableDateTimeString(string dateString)
        {
            DateTime? result = null;
            if (!String.IsNullOrEmpty(dateString))
            {
                DateTime tempDate;

                if (DateTime.TryParse(dateString, out tempDate))
                {
                    result = tempDate;
                }
            }

            return result;
        }

        public static int Quarter(DateTime theDate)
        {
            var i = theDate.Month;
            if (i <= 3)
            {
                return 1;
            }
            else if ((i >= 4) && (i <= 6))
            {
                return 2;
            }
            else if ((i >= 7) && (i <= 9))
            {
                return 3;
            }
            else if ((i >= 10) && (i <= 12))
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        public static string QuarterAndYearStamp(int quarter, int year)
        {
            return string.Format("Quarter (0) of the year (1)", quarter, year);
        }


        #endregion
    }
}