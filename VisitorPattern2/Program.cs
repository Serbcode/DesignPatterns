using System;
using System.Collections.Generic;

namespace VisitorPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPromoParser> parsers = new List<IPromoParser>() { new DnsParser(), new EldoradoParser(), new MVideoParser(), new OzonParser() };

            foreach (var parser in parsers)
            {
                Console.WriteLine(parser.ParsePeriod(null));
            }
        }
    }
}
