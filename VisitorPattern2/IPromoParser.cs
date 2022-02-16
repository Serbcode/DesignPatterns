using System.Collections.Generic;
using System.Text;

namespace VisitorPattern2
{
    public interface IPromoParser
    {
        public Period ParsePeriod(string str);
    }
}
