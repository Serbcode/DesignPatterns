using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyweight1
{
    public record Car(string Model,
                      string Company,
                      string Color,
                      string? Owner = null,
                      string? Number = null);

    public class Flyweight(Car car)
    {
        private Car sharedState = car;

        public void Operation(Car uniqueState)
        {
            string s = JsonConvert.SerializeObject(sharedState);
            string u = JsonConvert.SerializeObject(uniqueState);
            Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
    }

    // Фабрика Легковесов создает объекты-Легковесы и управляет ими. Она
    // обеспечивает правильное разделение легковесов. Когда клиент запрашивает
    // легковес, фабрика либо возвращает существующий экземпляр, либо создает
    // новый, если он ещё не существует.
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] args)
        {
            foreach (var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.GetKey(elem)));
            }
        }

        // Возвращает хеш строки Легковеса для данного состояния.
        public string GetKey(Car key)
        {
            List<string> elements = [key.Model, key.Color, key.Company];

            if (key.Owner != null && key.Number != null)
            {
                elements.Add(key.Number);
                elements.Add(key.Owner);
            }

            elements.Sort();

            return string.Join("_", elements);
        }

        // Возвращает существующий Легковес с заданным состоянием или создает
        // новый.
        public Flyweight? GetFlyweight(Car sharedState)
        {
            string key = this.GetKey(sharedState);

            if (!flyweights.Any(t => t.Item2 == key))
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return flyweights.FirstOrDefault(t => t.Item2 == key)?.Item1;
        }

        public void ListFlyweights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }

    class Program
    {
        public static void addCarToPoliceDatabase(FlyweightFactory factory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new Car(car.Model, car.Company, car.Color));

            // Клиентский код либо сохраняет, либо вычисляет внешнее состояние и
            // передает его методам легковеса.
            flyweight?.Operation(car);
        }

        static void Main(string[] args)
        {
            // Клиентский код обычно создает кучу предварительно заполненных
            // легковесов на этапе инициализации приложения.
            var factory = new FlyweightFactory(
                new Car("Chevrolet", "Camaro2018", "pink"),
                new Car("Mercedes Benz", "C300", "black"),
                new Car("Mercedes Benz", "C500", "red"),
                new Car("BMW", "M5", "red"),
                new Car("BMW", "X6", "white"));
            factory.ListFlyweights();

            addCarToPoliceDatabase(factory, new Car("James Doe", "CL234IR", "BMW", "M5", "red"));

            addCarToPoliceDatabase(factory, new Car("James Doe", "CL234IR", "BMW", "X1", "red"));

            factory.ListFlyweights();
        }
    }
}
