namespace DrinkModeling
{
    public enum DrinkType
    {
        None, Tea, Coffee, Cola, Mixed
    }

    public class DrinkState
    {
        public readonly int MaxVolume;

        public DrinkState(int volume, DrinkType drinkType = DrinkType.None)
        {
            MaxVolume = volume;
            DrinkType = drinkType;
            CurrentVolume = 0;
        }

        public int CurrentVolume { get; set; }
        public DrinkType DrinkType { get; set; }
    }
}
