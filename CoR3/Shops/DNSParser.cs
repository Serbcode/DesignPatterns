using CoR3.Parsers;

namespace CoR3.Shops
{
    public class DNSParser 
    {
        readonly c_NN_month_po_NN_month p1 = new c_NN_month_po_NN_month();
        readonly c_NN_po_NN_month p2 = new c_NN_po_NN_month();
        readonly Do_NN_month_year p3 = new Do_NN_month_year();

        public DNSParser()
        {            
            p1.SetNext(p2).SetNext(p3);
        }

        public Period Parse(string input)
        {
            return p1.Parse(input);
        }
    }
}
