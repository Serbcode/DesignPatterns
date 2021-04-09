namespace DecoratorPattern2
{
    /// <summary>
    /// Базовый класс для всех декораторов (оберток). Обратите внимание - он тоже потомок RestaurantDish и!
    /// через конструктор принимает RestaurantDish, инициируя внутреннее поле. (Агрегация)
    /// </summary>
    public abstract class Decorator : RestaurantDish
    {
        private readonly RestaurantDish dish;

        public Decorator(RestaurantDish dish)
        {
            this.dish = dish;
        }
        
        public override void Display()
        {
            dish.Display();
        }
    }
}
