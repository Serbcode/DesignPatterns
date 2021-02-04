using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern3
{

    public class PeriodParser
    {
        private static PeriodParser instance = new PeriodParser();

        private PeriodParser()
        {                
        }

        public static PeriodParser GetInstance()
        {
            return instance;
        }
    }

    public sealed class COMManager
    {
        private static COMManager instance;
        public string Value { get; private set; }

        private readonly static object _lock = new object();

        private COMManager(string value)
        {
            this.Value = value;
        }

        public static COMManager GetInstance(string value)
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new COMManager(value);
                }                
            }
            return instance;
        }

    }

    // Потокобезопасная реализация без использования lock
    public class Singleton2
    {
        private static readonly Singleton2 instance = new Singleton2();

        public string Date { get; private set; }

        private Singleton2()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton2 GetInstance()
        {
            return instance;
        }
    }

    // Nested class
    public class Singleton
    {
        public string Date { get; private set; }        
        public static string text = "hello";

        private Singleton()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return Nested.instance;
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly Singleton instance = new Singleton();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Task.Run(() =>
            {
                Thread.Sleep(300);
                COMManager manager = COMManager.GetInstance("Foo");                
                Console.WriteLine(manager.Value);
            });

            var t2 = Task.Run(() =>
            {
                COMManager manager = COMManager.GetInstance("Barr");
                Console.WriteLine(manager.Value);
            });

            Task.WaitAll(t1, t2);            
        }
    }
}
