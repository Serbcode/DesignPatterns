namespace DecoratorPattern2
{
    class Program
    {
        static void Main(string[] args)
        {

            // печатаем меню на сегодня :))

            Pasta fettuccineAlfredo = new Pasta("Fresh-made daily pasta", "Creamly garlic alfredo sauce");
            fettuccineAlfredo.Display();

            FreshSalad caesarSalad = new FreshSalad("Crisp romaine lettuce", "Freshly-grated Parmesan cheese", "House-made Caesar dressing");
            caesarSalad.Display();

            FreshSalad greenSalad = new FreshSalad("greens", "cheese", "dressing");

            // тепреь нам нужно декорировать эти блюда, сделать обёртки для этих классов, таким образом, 
            // что бы можно было отслеживать сколько блюд можно еще заказать.

            // для этого создадим базовый класс для всех декораторов (оберток) class Decorator, Decorator.cs
            // а далее создадим на его основе уже конкретный декоратор с (необходимой) добавленной функциональностью. class Available, Available.cs

            // Теперь мы создаем блюда с кол-вом возможных заказов на сегодня. 
            Available caesarAvailable = new Available(caesarSalad, 3);
            Available alfredoAvailable = new Available(fettuccineAlfredo, 4);
            Available greenSaladAvailable = new Available(greenSalad);

            // caesarAvailable и caesarSalad это все потомки класса RestaurantDish и имеют общий интерфейс.

            // Ну а теперь принимаем заказы -
            caesarAvailable.OrderItem("John");
            caesarAvailable.OrderItem("Sally");
            caesarAvailable.OrderItem("Manush");

            alfredoAvailable.OrderItem("Sally");
            alfredoAvailable.OrderItem("Francis");
            alfredoAvailable.OrderItem("Venkat");
            alfredoAvailable.OrderItem("Diana");
            alfredoAvailable.OrderItem("Dennis"); // Not enough ingredients for Dennis's order!

            greenSaladAvailable.OrderItem("John");

            // и посмотрим сколько раз заказали блюда. Статистика.
            caesarAvailable.Display();
            alfredoAvailable.Display();

            greenSaladAvailable.Display();

            // заказ Dennis не выполнился, т.к. не достаточно ингредиентов.
        }
    }
}
