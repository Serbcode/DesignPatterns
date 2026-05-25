using CommandPattern1.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern1
{
    /// <summary>
    /// The Receiver
    /// </summary>
    public class FastFoodOrder
    {
        public List<MenuItem> currentItems { get; set; }
        public FastFoodOrder()
        {
            currentItems = [];
        }

        public void ExecuteCommand(OrderCommand command, MenuItem item)
        {
            command.Execute(currentItems, item);
        }

        public void ShowCurrentItems()
        {
            foreach (var item in currentItems)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------");
        }
    }
}
