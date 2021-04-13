using System;

namespace MediatorPattern1
{
    class Component2 : Component
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 Calls DoC()");
            mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 calls DoD()");
            mediator.Notify(this, "D");
        }
        
    }
}
