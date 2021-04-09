using System;

namespace DecoratorPattern2
{
    /// <summary>
    /// Конкретное блюдо в ресторане - свежий салат, салат из свежих овощей.
    /// За одно потренируемся в английском в контексте "посещение ресторана" :-)
    /// </summary>
    public class FreshSalad : RestaurantDish
    {
        private readonly string greens; /* зелень */
        private readonly string cheese; /* сыр */
        private readonly string dressing; /* приправы */

        public FreshSalad(string greens, string cheese, string dressing)
        {
            this.greens = greens;
            this.cheese = cheese;
            this.dressing = dressing;
        }

        public override void Display()
        {
            Console.WriteLine("\nFresh salad:");
            Console.WriteLine("\tGreens: {0}", greens);
            Console.WriteLine("\tCheese: {0}", cheese);
            Console.WriteLine("\tDressing: {0}", dressing);
        }
    }
}
