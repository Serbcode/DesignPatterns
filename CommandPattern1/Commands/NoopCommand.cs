namespace CommandPattern1.Commands
{
    /// <summary>
    /// Command that does nothing. Used as a default command when client code provides an invalid option
    /// </summary>
    public class NoopCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            // No operation
        }
    }
}
