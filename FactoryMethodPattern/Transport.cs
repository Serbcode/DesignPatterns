using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{

    public abstract class Transport
    {
        public abstract void Deliver();
    }

    public class Ship : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Доставляю по морю");
        }
    }

    public class Track : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Доставляю по дороге");
        }
    }

    public class Train : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Доставляю по рельсам");
        }
    }

    public class Plain : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Доставляю по воздуху");
        }
    }
}
