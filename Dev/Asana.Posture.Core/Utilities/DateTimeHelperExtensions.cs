namespace Asana.Posture.Core.Utilities
{
	using System;

	public static class DateTimeHelperExtensions
	{
		#region Public Methods

		public static DateTime AddQuarter(this DateTime origin, int quarters)
		{
            return DateTimeHelper.AddQuarter(quarters, origin);
		}

		public static DateTime AddWorkDays(this DateTime theDate, int days)
		{
		    return DateTimeHelper.AddWorkDays(days, theDate);
		}

		public static DateTime BeginningOfFiscalYearDate(this DateTime inputDate, DateTime fiscalBeginDateToUse)
		{
		    return DateTimeHelper.BeginningOfFiscalYearDate(inputDate, fiscalBeginDateToUse);
		}

		public static DateTime DateTimeFromString(string year, string month, string day)
		{
		    return DateTimeHelper.DateTimeFromString(year, month, day);
		}

		public static DateTime FirstDayOfQuarter(this DateTime day)
		{
			return new DateTime(day.Year, FirstMonthOfQuarter(Quarter(day)), 1);
		}

		public static int FirstMonthOfQuarter(int qtr)
		{
		    return DateTimeHelper.FirstMonthOfQuarter(qtr);
		}


		public static DateTime GetEndOfDay(this DateTime theDate)
		{
		    return DateTimeHelper.GetEndOfDay(theDate);
		}

		public static DateTime GetEndOfWeek(this DateTime dayInWeek)
		{
			return GetEndOfDay(GetStartOfWeek(dayInWeek).AddDays(6));
		}

		public static DateTime GetEndOfWorkWeek(this DateTime dayInWeek)
		{
			return GetEndOfWeek(dayInWeek).AddDays(-1);
		}

		public static DateTime GetEndOfYear(this DateTime value)
		{
            return DateTimeHelper.GetEndOfYear(value.Year);
		}

		public static string GetShortDateOrEmptyString(this DateTime? nullableDateTime)
		{
			return nullableDateTime.HasValue ? nullableDateTime.Value.ToShortDateString() : string.Empty;
		}

		public static DateTime GetStartOfDay(this DateTime theDate)
		{
			return new DateTime(theDate.Year, theDate.Month, theDate.Day, 0, 0, 0, 0);
		}

		public static DateTime GetStartOfWeek(this DateTime dayInWeek)
		{
		    return DateTimeHelper.GetStartOfWeek(dayInWeek);
		}

		public static DateTime GetStartOfWorkWeek(this DateTime dayInWeek)
		{
			return GetStartOfWeek(dayInWeek).AddDays(1);
		}

		public static DateTime GetStartOfYear(this DateTime value)
		{
			return DateTimeHelper.GetStartOfYear(value.Year);
		}

		public static DateTime? ParseNullableDateTimeString(this string dateString)
		{
		    return DateTimeHelper.ParseNullableDateTimeString(dateString);
		}

		public static int Quarter(this DateTime theDate)
		{
		    return DateTimeHelper.Quarter(theDate);
		}

		#endregion
	}
}