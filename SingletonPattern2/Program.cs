using System;

namespace SingletonPattern2
{
    class Program
    {
        public static int Main()
        {
            Computer comp = new Computer();
            comp.Launch("Windows 7");
            Console.WriteLine(comp.OS.Name);

            comp.OS = OS.GetInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);

            return 0;
        }
    }
}
