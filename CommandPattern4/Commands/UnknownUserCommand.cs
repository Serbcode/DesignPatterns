namespace CommandPattern4.Commands;

using CommandPattern4.DataStore;

internal class UnknownUserCommand : Command
{
    private readonly IUserStore _userStore;
    public UnknownUserCommand(CommandContext context)
    {
        _userStore = context.DataStore;
    }

    public override void Execute()
    {
        Console.WriteLine("Unknown command");
    }
}