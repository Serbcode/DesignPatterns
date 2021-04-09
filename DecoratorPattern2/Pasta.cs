using System;

namespace DecoratorPattern2
{
    /// <summary>
    /// Пицца. Тип пиццы и соус.
    /// </summary>
    public class Pasta : RestaurantDish
    {
        private readonly string pastaType; /* тип пиццы */
        private readonly string sause; /* соус */

        public Pasta(string pastaType, string sause)
        {
            this.pastaType = pastaType;
            this.sause = sause;
        }

        public override void Display()
        {
            Console.WriteLine("\nClassic pasta: ");
            Console.WriteLine("\tPasta type: {0}", pastaType);
            Console.WriteLine("\tSause: {0}", sause);
        }
    }
}
