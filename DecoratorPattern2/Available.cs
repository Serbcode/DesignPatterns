using System;
using System.Collections.Generic;

namespace DecoratorPattern2
{
    /// <summary>
    /// А вот и конкретный декоратор, он тоже RestaurantDish с добавленной функциональностью.
    /// Он хранит информацию о том, сколько раз его заказали!
    /// Таким образом, в конструкторе мы указываем блюдо, у которого мы расширяем функционал и колличество этих блюд дотупных для заказа!
    /// </summary>
    public class Available : Decorator
    {
        public int NumAvailable { get; set; }
        protected List<string> customers = new List<string>();

        public Available(RestaurantDish dish, int numAvailable = 0) : base(dish)        
        {
            NumAvailable = numAvailable;
        }

        public void OrderItem(string CustomerName)
        {
            if (NumAvailable > 0)
            {
                customers.Add(CustomerName);
                NumAvailable--;
            }
            else
            {
                Console.WriteLine($"\n Not enough ingredients for {CustomerName}'s order!");
            }
        }

        public override void Display()
        {
            base.Display();
            foreach (string c in customers)
                Console.WriteLine("\tOrdered by " + c);
        }
    }
}
