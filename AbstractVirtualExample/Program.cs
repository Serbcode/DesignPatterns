using System;

namespace AbstractVirtualExample
{

    public abstract class Base
    {
        public abstract void YouMustImplement();

        public virtual void YouCanOverride()
        { 
        }
    }

    public abstract class Derived : Base
    {
        public abstract void OneMoreMethod();
        public override void YouCanOverride()
        {
            Console.WriteLine("Derived: Here I can override my parent virtual method");
        }
    }

    public class DerivedToUse : Derived
    {
        public override void YouMustImplement()
        {
            Console.WriteLine("DerivedToUse: Here I MUST implement all abstract methods of my parents");
        }

        public override void OneMoreMethod()
        {
            Console.WriteLine("DerivedToUse: Here I can override virtual methods of my parents");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DerivedToUse dtu = new DerivedToUse();
            dtu.YouMustImplement();
            dtu.YouCanOverride();
        }
    }
}
