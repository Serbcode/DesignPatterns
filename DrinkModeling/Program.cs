using System;

namespace DrinkModeling
{
    public enum DrinkType
    {
        None, Tea, Coffee, Colla, Mixed
    }

    public class DrinkState
    {
        public readonly int MaxVolume;

        public DrinkState(int volume)
        {
            MaxVolume = volume;
            DrinkType = DrinkType.None;
            CurrentVolume = 0;
        }

        public int CurrentVolume { get; set; }
        public DrinkType DrinkType { get; set; }
    }

    public class Human : DrinkState
    {
        public Human(int volume) : base(volume) { }

        public override string ToString()
        {
            return $"Human is {CurrentVolume}ml of {DrinkType:G}";
        }
    }

    public class Cap : DrinkState
    {
        public Cap(int volume) : base(volume) { }

        public override string ToString()
        {
            return $"Cap is {CurrentVolume}ml of {DrinkType:G}";
        }
    }

    public class Controller
    {
        public virtual void Drink(DrinkState human, DrinkState cap)
        {
            if (cap.CurrentVolume <= 0) return;

            if (cap.CurrentVolume > (human.MaxVolume - human.CurrentVolume))
                throw new IndexOutOfRangeException("Human is out of volume.");

            human.CurrentVolume += cap.CurrentVolume;
            
            cap.CurrentVolume = 0;
            cap.DrinkType = DrinkType.None;

            if (human.DrinkType == DrinkType.None)
                human.DrinkType = cap.DrinkType;

            else if (human.DrinkType != cap.DrinkType)
                human.DrinkType = DrinkType.Mixed;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human h = new Human(980);

            Cap coffee = new Cap(50) { DrinkType = DrinkType.Coffee, CurrentVolume = 50 };
            Cap tea = new Cap(150) { DrinkType = DrinkType.Tea, CurrentVolume = 100 };

            new Controller().Drink(h, coffee);
            Console.WriteLine(h);

            new Controller().Drink(h, tea);
            Console.WriteLine(h);

            new Controller().Drink(h, new Cap(1000) { DrinkType = DrinkType.Mixed, CurrentVolume = 700 });
            Console.WriteLine(h);
            Console.WriteLine(tea);
        }
    }
}
