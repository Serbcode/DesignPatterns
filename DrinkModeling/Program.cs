using System;

namespace DrinkModeling
{
    public class Controller
    {
        public virtual void Drink(DrinkState human, DrinkState cap)
        {
            if (cap.CurrentVolume <= 0) return;

            if (cap.CurrentVolume > (human.MaxVolume - human.CurrentVolume))
                throw new IndexOutOfRangeException("Human is out of volume.");

            human.CurrentVolume += cap.CurrentVolume;                       

            if (human.DrinkType == DrinkType.None)
                human.DrinkType = cap.DrinkType;

            else if (human.DrinkType != cap.DrinkType)
                human.DrinkType = DrinkType.Mixed;

            cap.CurrentVolume = 0;
            cap.DrinkType = DrinkType.None;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human h = new Human(980);

            Cap coffee = new Cap(50, DrinkType.Coffee) { CurrentVolume = 50 };
            Cap tea = new Cap(150, DrinkType.Tea) { CurrentVolume = 100 };

            new Controller().Drink(h, coffee);
            Console.WriteLine(h);

            new Controller().Drink(h, tea);
            Console.WriteLine(h);

            new Controller().Drink(h, new Cap(1000, DrinkType.Mixed) { CurrentVolume = 700 });
            
            Console.WriteLine(h);
            Console.WriteLine(tea);
        }
    }
}
