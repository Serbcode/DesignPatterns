namespace CommandPattern1.Commands
{
    /// <summary>
    /// Modify command
    /// </summary>
    public class ModifyCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            var item = currentItems.FirstOrDefault(i => i.Name == newItem.Name);
            if (item is not null)
            {
                item.Price = newItem.Price;
                item.Amount = newItem.Amount;
            }
        }
    }
}
