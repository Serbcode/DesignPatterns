namespace FactoryMethodPattern3
{
    /// <summary>
    /// Concrete Creator
    /// Whenever we create an object of class TurkeySandwich, 
    /// we can call CreateIngredients() to create the correct amount and order of ingredients for this sandwich.
    /// </summary>
    class TurkeySandwich : Sandwich
    {
        public override void CreateIngredients()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new Mayonnaise());
            Ingredients.Add(new Lettuce());
            Ingredients.Add(new Turkey());
            Ingredients.Add(new Turkey());
            Ingredients.Add(new Bread());
        }
    }
}
