using CommandPattern1.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern1
{
    public class Patron
    {
        private FastFoodOrder _order;
        private MenuItem _menuItem;
        private OrderCommand _orderCommand;

        public Patron()
        {
            _order = new FastFoodOrder();
        }

        public void SetCommand(int CommandOption)
        {
            _orderCommand = new CommandFactory().GetCommand(CommandOption);
        }

        public void SetMenuItem(MenuItem item)
        {
            _menuItem = item;
        }

        public void ExecuteCommand()
        {
            _order.ExecuteCommand(_orderCommand, _menuItem);
        }

        public void ShowCurrentOrder()
        {
            _order.ShowCurrentItems();
        }
    }

    public class CommandFactory
    {
        public OrderCommand GetCommand(int CommandOption)
        {
            switch (CommandOption)
            {
                case 1:
                    return new AddCommand();
                case 2:
                    return new ModifyCommand();
                case 3:
                    return new RemoveCommand();
                default:
                    return new AddCommand();
            }
        }
    }
}
