namespace DrinkModeling
{
    public class Human : DrinkState
    {
        public Human(int volume) : base(volume) { }

        public override string ToString()
        {
            return $"Human is {CurrentVolume}ml of {DrinkType:G}";
        }
    }
}
