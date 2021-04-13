using System;

namespace MediatorPattern1
{
    /// <summary>
    /// Конкретные Компоненты реализуют различную функциональность. Они не
    /// зависят от других компонентов. Они также не зависят от каких-либо
    /// конкретных классов посредников.
    /// </summary>
    public class Component1 : Component
    {
        public void DoA()
        {
            Console.WriteLine("Component1 calls DoA()");
            mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component1 calls DoB()");
            mediator.Notify(this, "B");
        }        

    }
}
