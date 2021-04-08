using System;

namespace CoR2
{
    public class PurchaseOrder
    {
        static int numInstances;

        public int RequestNumber
        { 
            get 
            {
                return numInstances;
            }
        }

        public PurchaseOrder(double amount, double price, string name)
        {        
            Amount = amount;
            Price = price;
            Name = name;
            Console.WriteLine($"Purchase request for {name}, amount {amount} for ${price} has been submitted.");

            ++numInstances;
        }
        
        public double Amount { get; }
        public double Price { get; }
        public string Name { get; }
    }
}
