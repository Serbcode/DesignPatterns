using CommandPattern1.Commands;

namespace CommandPattern1
{
    public class Patron
    {
        private readonly FastFoodOrder _order;
        private MenuItem _menuItem;
        private OrderCommand _orderCommand;

        public Patron()
        {
            _order = new FastFoodOrder();
            _orderCommand = new NoopCommand();
            _menuItem = new MenuItem("No item", 0, 0);
        }

        public void SetCommand(string CommandOption)
        {
            _orderCommand = CommandFactory.GetCommand(CommandOption);
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

    public static class CommandFactory
    {
        public static OrderCommand GetCommand(string CommandOption)
        {
            return CommandOption.ToLower() switch
            {
                "add" => new AddCommand(),
                "modify" => new ModifyCommand(),
                "remove" => new RemoveCommand(),
                _ => new NoopCommand(),
            };
        }
    }
}
