using System;
using System.Collections.Generic;

namespace CoR1
{
    internal class Client
    {
        public static void ClientCode(BaseHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "cap of coffee" })
            {
                var res = handler.Handle(food);
                if (res == null)
                    Console.WriteLine($"Food {food} was left untouched.");
                else
                    Console.WriteLine(res);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Client.ClientCode(squirrel);
        }
    }
}
