using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern2
{
    public class MVideoParser : IPromoParser
    {
        public Period ParsePeriod(string str)
        {
            return new Period(DateTime.Today, DateTime.Now.AddDays(5));
        }
    }
}
