using System.Collections.Generic;

namespace FactoryMethodPattern3
{
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
}
