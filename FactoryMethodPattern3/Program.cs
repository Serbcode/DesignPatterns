using System;

namespace FactoryMethodPattern3
{
    class Program
    {

        public static void ClientCode(Sandwich sandwich)
        {
            // Importand ClientCode stays unchangable even if we add new sandwiches

            // call FM here
            sandwich.CreateIngredients();

            // other staff below
        }

        static void Main(string[] args)
        {
            // driver code.
            ClientCode(new TurkeySandwich());
            ClientCode(new DagwoodSandwich());
        }
    }
}
