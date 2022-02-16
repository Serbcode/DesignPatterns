using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern2
{
    public class EldoradoParser : IPromoParser
    {
        public Period ParsePeriod(string str)
        {
            return new Period(DateTime.Today, DateTime.Today.AddDays(4));
        }
    }
}
