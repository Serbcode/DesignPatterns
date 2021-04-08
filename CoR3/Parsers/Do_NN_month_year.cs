using System;
using System.Collections.Generic;
using System.Text;

namespace CoR3.Parsers
{
    public class Do_NN_month_year :PeriodParser
    {
        public override Period Parse(string input)
        {
            return new Period(null, null);
        }
    }
}
