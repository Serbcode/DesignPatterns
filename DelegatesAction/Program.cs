using System;

namespace DelegatesAction
{
    class Program
    {
        /*
        Action is a delegate type defined in the System namespace. 
        An Action type delegate is the same as Func delegate except that the Action delegate doesn't return a value. 
        In other words, an Action delegate can be used with a method that has a void return type.
        
        public delegate void Action<in T>(T obj);

         */

        static void Main(string[] args)
        {
            Action<int> printActionDelegate = ConsolePrint;
            printActionDelegate(10);
        }

        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }
    }
}
