using System;

namespace CommandPattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            
            Since we now have all the pieces in place, let's create our Client participant 
            which creates a ConcreteCommand and sets the receiver. 
            We will also add several items to our order, then delete an item and change another item.                         
            
            */

            Patron patron = new Patron(); // visitor

            patron.SetCommand("add");
            patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            patron.ExecuteCommand();

            patron.SetCommand("add");
            patron.SetMenuItem(new MenuItem("Hamburger", 2, 2.59));
            patron.ExecuteCommand();

            patron.SetCommand("add");
            patron.SetMenuItem(new MenuItem("Drink", 2, 1.19));
            patron.ExecuteCommand();

            patron.ShowCurrentOrder();

            //Remove the french fries
            patron.SetCommand("remove");
            patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            patron.ExecuteCommand();

            patron.ShowCurrentOrder();

            //Now we want 4 hamburgers rather than 2
            patron.SetCommand("modify");
            patron.SetMenuItem(new MenuItem("Hamburger", 4, 2.59));
            patron.ExecuteCommand();

            patron.ShowCurrentOrder();

            Console.ReadKey();
        }
    }
}
