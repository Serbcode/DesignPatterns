using System;
using System.Collections.Generic;

namespace FactoryMethodPattern3
{
    /// <summary>
    /// Product. The Product defines the interfaces of objects that the factory method will create.
    /// </summary>
    abstract class Ingredient { }

    /// <summary>
    /// Concrete Product. The ConcreteProduct objects implement the Product interface.
    /// </summary>
    class Bread : Ingredient { }

    /// <summary>
    /// Concrete Product. The ConcreteProduct objects implement the Product interface.
    /// </summary>
    class Turkey : Ingredient { }

    /// <summary>
    /// Concrete Product. The ConcreteProduct objects implement the Product interface.
    /// </summary>
    class Lettuce : Ingredient { }

    /// <summary>
    /// Concrete Product. The ConcreteProduct objects implement the Product interface.
    /// </summary>
    class Mayonnaise : Ingredient { }

    /// <summary>
    /// Creator. The Creator declares the factory method, which returns an object of type Product.  
    /// </summary>
    abstract class Sandwich
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();

        public Sandwich()
        {
            CreateIngredients();
        }

        //***** Factory method
        public abstract void CreateIngredients();

        public List<Ingredient> Ingredients
        {
            get { return _ingredients; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
