using System;
using System.Text;

namespace BuilderPattern2
{

    public enum Cheese { Cheddar, Mozzarella, Parmesan, Provolone }
    public enum Size { Small, Medium, Large, XLarge }

    public class Pizza
    {
        public Size Size { get; set; }
        public Cheese Cheese { get; set; }
        public bool Sauce { get; set; }
        public bool Pepperoni { get; set; }
        public bool Ham { get; set; }
        public bool Olives { get; set; }
        public bool Mushrooms { get; set; }

        public Pizza(PizzaBuilder builder)
        {
            Size = builder.Size;
            Cheese = builder.Cheese;
            Sauce = builder.Sauce;
            Pepperoni = builder.Pepperoni;
            Ham = builder.Ham;
            Olives = builder.Olives;
            Mushrooms = builder.Mushrooms;
        }

        public override string ToString()
        {
            return $"Size: {Size}, Cheese: {Cheese}, Sauce: {Sauce}, Pepperoni: {Pepperoni}, Ham: {Ham}, Olives: {Olives}, Mushrooms: {Mushrooms}";
        }
    }

    public class PizzaBuilder
    {
        public Size Size { get; set; }
        public Cheese Cheese { get; set; }
        public bool Sauce { get; set; }
        public bool Pepperoni { get; set; }
        public bool Ham { get; set; }
        public bool Olives { get; set; }
        public bool Mushrooms { get; set; }

        public Pizza Build()
        {
            return new Pizza(this);
        }

        public PizzaBuilder(Size size = Size.Large)
        {
            Size = size;
        }

        public PizzaBuilder AddCheese(Cheese cheese = Cheese.Mozzarella)
        {
            Cheese = cheese;
            return this;
        }

        public PizzaBuilder AddSauce()
        {
            Sauce = true;
            return this;
        }

        public PizzaBuilder AddPepperoni()
        {
            Pepperoni = true;
            return this;
        }

        public PizzaBuilder AddHam()
        {
            Ham = true;
            return this;
        }

        public PizzaBuilder AddOlives()
        {
            Olives = true;
            return this;
        }

        public PizzaBuilder AddMushrooms()
        {
            Mushrooms = true;
            return this;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Set Medium size, add Sauce, add Provolone cheese, add Pepperoni, add Olives, then build.
            var pizzaPepOlives = new PizzaBuilder(Size.Medium)
                                     .AddSauce()
                                     .AddCheese(Cheese.Provolone)
                                     .AddPepperoni()
                                     .AddOlives()
                                     .Build();

            var pizzaOlivesMushrooms = new PizzaBuilder()
                                      .AddSauce()
                                      .AddCheese()
                                      .AddOlives()
                                      .AddMushrooms()
                                      .Build();

            Console.WriteLine(pizzaPepOlives);
            Console.WriteLine(pizzaOlivesMushrooms);

            char[] arr = { 'a', 'b', 'c' };

            string res = new StringBuilder()
                .Append(true)
                .Append('a')
                .Append(arr)
                .Append("string")
                .Append(100L)
                .Append(100.23)
                .Append('x', 4)
                .ToString();

            Console.WriteLine(res);
        }
    }
}
