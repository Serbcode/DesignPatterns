namespace DrinkModeling
{
    public class Cap : DrinkState
    {
        public Cap(int volume, DrinkType drinkType) : base(volume, drinkType) { }

        public override string ToString()
        {
            return $"Cap is {CurrentVolume}ml of {DrinkType:G}";
        }
    }
}
