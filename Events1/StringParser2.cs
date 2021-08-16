using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Events1
{
    public class StringParser2
    {
        private readonly string input;
        public string[] DateFormats = { "d MMMM", "dd MMMM", "dd MMMM yyyy", "d MMMM yyyy", "dd.MM.yyyy" };
        public CultureInfo RuCulture = new CultureInfo("ru-RU");

        public StringParser2(string input)
        {
            this.input = input;
        }
        
        public event ParserHandler ParseError;

        public Period ParseDates()
        {
            string startDatePattern = @"[cс]\s(\d{1,2}\s\S+\s\d{4})";
            string endDatePattern = @"до\s(\d{1,2}\s\S+\s\d{4})";

            DateTime? enddate = null;
            DateTime? startdate = null;            

            // 1. parse End Date
            Match me = new Regex(endDatePattern, RegexOptions.IgnoreCase).Match(input);
            if (me.Success && DateTime.TryParseExact(me.Groups[1].Value, DateFormats, RuCulture, DateTimeStyles.None, out DateTime outdate))
            {
                enddate = outdate.ChangeTime(23, 59, 59, 0);
            }
            else
            {
                ParseError?.Invoke(this, "Cannot parse end date: " + me.Groups[1].Value);
            }

            Match ms = new Regex(startDatePattern, RegexOptions.IgnoreCase).Match(input);
            if (ms.Success && DateTime.TryParseExact(ms.Groups[1].Value, DateFormats, RuCulture, DateTimeStyles.None, out DateTime dt))
            {
                startdate = dt;
            }
            else
            {
                ParseError?.Invoke(this, "Cannot parse start date: " + ms.Groups[1].Value);
            }

            if ((startdate == null) && (enddate != null))
            {
                startdate = DateTime.Today;
            }

            return new Period() { StartDate = startdate, EndDate = enddate };
        }
    }
}
