using System;

namespace Events1
{

    class Program
    {
        static void Main(string[] args)
        {
            StringParser1 sp = new StringParser1("акция проходит с 12 июня 2021 по 31 декабря 2021");
            sp.ParseError = (object who, string msg) =>
            {
                Console.WriteLine("anonym function using lambda post:");
                Console.WriteLine("Parse Error: " + msg);
            };

            // this delegate declaration overrides prev setup
            sp.ParseError += delegate (object sender, string message)
            {
                Console.WriteLine("anonym delegate said: ");
                Console.WriteLine(message);
            };

            // this setup clear all setup before.
            sp.ParseError = null;

            Period res = sp.ParseDates();
            Console.WriteLine("{0:dd.MM.yyy hh:mm}\t {1:dd.MM.yyy hh:mm}", res.StartDate?.ToString(), res.EndDate?.ToString());


            // string parser2 with event implementation
            // diff between delegates and event declaration

            StringParser2 sp2 = new StringParser2("акция проходит с 12 июня 2021 по 31 декабря 2021");
            
            sp.ParseError = (object who, string msg) =>
            {
                Console.WriteLine("anonym function using lambda post:");
                Console.WriteLine("Parse Error: " + msg);
            };

            // this delegate declaration overrides prev setup
            sp.ParseError = delegate (object sender, string message)
            {
                Console.WriteLine("anonym delegate said: ");
                Console.WriteLine(message);
            };

            // this setup clear all setup before.
            sp.ParseError = null;

            Period result = sp.ParseDates();
            Console.WriteLine("{0:dd.MM.yyy hh:mm}\t {1:dd.MM.yyy hh:mm}", result.StartDate?.ToString(), result.EndDate?.ToString());

        }
    }
}
