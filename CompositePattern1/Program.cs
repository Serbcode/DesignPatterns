using System;
using System.Collections.Generic;

namespace CompositePattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hardware hdd = new Hardware("HDD", 120f);
            Hardware RAM = new Hardware("DIMM DDR", 300f);

            HardwareBox branch1 = new HardwareBox("Termaltake 11 Ryzen", 100f);
            branch1.Add(hdd);
            branch1.Add(RAM);

            HardwareBox branch2 = new HardwareBox("CPU + Motherboard BOX", 0.0f);
            branch2.Add(new Hardware("Intel core i3", 120f));
            branch2.Add(new Hardware("Asus Rock III", 300f));

            branch1.Add(branch2);
            
            Console.WriteLine(branch1.Cost);
        }
    }
}
