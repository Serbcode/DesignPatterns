using System;

namespace Facade1
{
    public class Subsystem1
    {
        public string Operation1()
        {
            return ("Subsystem1: ready!");
        }

        public string OperationN()
        {
            return ("Subsystem1: go!\n");
        }
    }
}
