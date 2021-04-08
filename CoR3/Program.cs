using System;
using CoR3.Shops;

namespace CoR3
{
    class Program
    {
        static void Main(string[] args)
        {
            DNSParser dns = new DNSParser();

            Period p = dns.Parse("Срок проведения акции: с 19 декабря 2018 года по 8 января 2019 года");
            Period p1 = dns.Parse("Срок проведения акции: с 17 по 31 декабря 2018 года");

            Period p2 = new Period(null, DateTime.Today);
            Console.WriteLine(p2);
        }
    }
}
