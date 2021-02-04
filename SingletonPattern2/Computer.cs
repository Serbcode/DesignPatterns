using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern2
{
    public class Computer
    {
        public OS OS { get; set; }

        public void Launch(string osname)
        {
            OS = OS.GetInstance(osname);
        }
    }
}
