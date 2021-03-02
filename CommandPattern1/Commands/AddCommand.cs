using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern1.Commands
{
    /// <summary>
    /// A concrete command
    /// </summary>
    public class AddCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            currentItems.Add(newItem);
        }
    }
}
