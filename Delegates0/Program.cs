using System;

namespace Delegates0
{
    // The simpliest example to understand delegates

    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Sub(int x, int y) => x - y;
        public static int Mlt(int x, int y) => x * y;
        public static int Div(int x, int y) => x / y;
    }

    // declare delegate (TYPE of pointer to method or function)
    // Signature
    public delegate int Operation(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input x: ");
            int x = int.Parse(Console.ReadLine());
            
            Console.Write("Input y: ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("Input operation [add, sub, mlt, div]: ");
            string strOp = Console.ReadLine();

            // declare delegate
            Operation op;

            // assign delegate
            switch (strOp.ToLower())
            {
                case "add": op = SimpleMath.Add;
                    break;
                case "sub":
                    op = SimpleMath.Sub;
                    break;
                case "mlt":
                    op = SimpleMath.Mlt;
                    break;
                case "div":
                    op = SimpleMath.Div;
                    break;
                default:
                    op = null;
                    Console.WriteLine("Bye bye");
                    break;
            }

            // call delegate
            Console.WriteLine($"Result: {op?.Invoke(x, y)}"); 
        }
    }


}
