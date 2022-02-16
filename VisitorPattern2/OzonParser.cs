using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern2
{
    public class OzonParser : IPromoParser
    {
        public Period ParsePeriod(string str)
        {
            return new Period(DateTime.Today, DateTime.Today.AddDays(1));
        }
     }
}
