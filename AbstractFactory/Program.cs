﻿using System;

namespace AbstractFactoryPattern
{

    // these are our AbstractProduct participants
    abstract class Sandwich { }
    abstract class Dessert { }
    
    // Next, we need an abstract class that will return a Sandwich and a Dessert (this is the AbstractFactory participant)
    abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();
        public abstract Dessert CreateDessert();
    }

    // Now we can start implementing the actual objects. 

    // First let's consider the ADULT MENU (these next classes are ConcreteProduct objects):
    class BLT : Sandwich { }
    class CremeBrulee : Dessert { }

    // We also need a _ConcreteFactory_ which implements the AbstractFactory and returns the adult recipes:
    class AdultCuisineFactory : RecipeFactory
    {
        public override Sandwich CreateSandwich()
        {
            return new BLT();
        }

        public override Dessert CreateDessert()
        {
            return new CremeBrulee();
        }
    }

    // Now let's define the CHILD's recipes. Here are the ConcreteProduct classes and ConcreteFactory for said recipes:
    class GrilledCheese : Sandwich { }
    class IceCreamSundae : Dessert { }

    class KidCuisineFactory : RecipeFactory
    {
        public override Sandwich CreateSandwich()
        {
            return new GrilledCheese();
        }

        public override Dessert CreateDessert()
        {
            return new IceCreamSundae();
        }
    }

    // How do we use this? 
    // First, let's ask the user if they are an adult or a child, then display the corresponding menu items.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you? (A)dult or (C)hild?");
            char input = Console.ReadKey().KeyChar;
            RecipeFactory recipeFactory;

            switch (input)
            {
                case 'a':
                    recipeFactory = new AdultCuisineFactory();
                    break;
                case 'c':
                    recipeFactory = new KidCuisineFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }

            var sandwich = recipeFactory.CreateSandwich();
            var dessert = recipeFactory.CreateDessert();
            
            Console.WriteLine();

            Console.WriteLine("Sandwich: " + sandwich.GetType().Name);
            Console.WriteLine("Dessert: " + dessert.GetType().Name);

            Console.ReadKey();
        }
    }
}

