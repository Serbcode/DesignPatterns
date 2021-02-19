using System;
using System.Collections.Generic;

namespace CompositePattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hardware hdd = new Hardware("HDD", 120.4f);
            Hardware RAM = new Hardware("DIMM DDR", 322f);

            HardwareBox branch1 = new HardwareBox("Termaltake 11 Ryzen", 100f);
            branch1.Add(hdd);
            branch1.Add(RAM);

            HardwareBox branch2 = new HardwareBox("CPU, Motherboard, Cooler BOX", 1390.0f);
            Hardware cpu = new Hardware("Intel core i3", 120.4f);
            Hardware mom = new Hardware("Asus Rock III", 322f);

            branch1.Add(branch2);
            
            Console.WriteLine(branch1.Cost);
        }
    }
}
