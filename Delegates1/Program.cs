using System;

namespace Delegates1
{
    // define simple delegate (like types)
    // Delegate is the reference type data type that defines the signature.
    public delegate void Notify(string mesasge);


    // generic delegate, defines signature like this:
    public delegate T Add<T>(T p1, T p2);

    class Program
    {
        static void Main(string[] args)
        {
            // create delegate vars and reference them
            Notify notify1 = ClassA.MethodA;
            Notify notify2 = ClassA.MethodB;

            Notify multicast = notify1 + notify2;

            // lambda expression define delegate
            Notify del3 = (string msg) => Console.WriteLine("Lambda function: " + msg);            
            multicast += del3;
            
            // call simple delegate
            notify1("Hello, world!");

            multicast("Hello, multicast");

            //Passing Delegate as a Parameter
            Notify deleg = ClassA.MethodB;
            Program.InvokeDelegate(deleg);

            Add<int> intSum = Program.Sum;
            Add<string> concat = Program.Concat;

            Console.WriteLine(intSum(10, 20));
            Console.WriteLine(concat("Hello ", "World!"));

        }

        // parameter is delegate
        private static void InvokeDelegate(Notify deleg)
        {
            // call delegate
            deleg("Hallo, there!");
        }

        public static int Sum(int i1, int i2)
        {
            return i1 + i2;
        }

        public static string Concat(string s1, string s2)
        {
            return s1 + s2;
        }
    }


    public class ClassA
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("MethodA: " + message);
        }

        public static void MethodB(string msg)
        {
            Console.WriteLine("MethodB: " + msg);
        }
    }


}

