using CommandPattern4.DataStore;

internal abstract class Command
{
    public abstract void Execute();
}

internal class CommandContext
{
    public IUserStore DataStore { get; }

    public CommandContext(IUserStore dataStore)
    {
        DataStore = dataStore;
    }
}
