using System;

namespace DelegatesFuncAction
{        
    // generic delegate 
    public delegate T Fun<T>(T arg);
    public delegate R Fun2<R, A>(A arg);

    public class Period {
        private readonly string str;

        public Period(string str)
        {
            this.str = str;
        }

        public override string ToString()
        {
            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fun<float> deleg = Functionf;
            Fun<int> deleg2 = FunctionI;

            Console.WriteLine($"Result: {deleg(0.22f)} and {deleg2(10)}");

            // The following Func delegate takes two input parameters of int type and returns a value of int type:
            Func<int, int, int> sum = Sum;

            // only OUTput parameter
            Func<int> getRandomNumber = GenRandom;

            // assign ANONYMOUS method to delegate where one in, and one out parameters like this:
            Func<int, int> getRandom2 = delegate (int max)
            {
                Random r = new Random();
                return r.Next(1, max);
            };

            // Func with LAMBDA expression like this:
            Func<int, int> getRandom3 = (int max) => new Random().Next(0, max);


            // anonymous
            Func<string, Period> ParsePeriod = delegate (string period)
            {
                Period p = new Period(period);
                return p;
            };

            // lambda variant
            Func<string, Period> Parse = (string period) => new Period(period);

            // calls
            Console.WriteLine(sum(3, 4));
            Console.WriteLine(getRandomNumber());
            Console.WriteLine(getRandom2(100));
            Console.WriteLine(getRandom3(1000));

            Console.WriteLine(ParsePeriod("any good period"));
            Console.WriteLine(Parse("lambda variant"));
        }

        private static int GenRandom()
        {
            return (new Random()).Next(1, 100);
        }

        public static float Functionf(float f)
        {
            return f;
        }

        public static int FunctionI(int i)
        {
            return i;
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
