using System;

namespace SingletonPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.Instance();
            Singleton instance2 = Singleton.Instance();

            Console.WriteLine(ReferenceEquals(instance1, instance2));

            instance1.SingletonOperation();
            string data = instance2.GetSingletonData();
            Console.WriteLine(data);
        }
    }
}
