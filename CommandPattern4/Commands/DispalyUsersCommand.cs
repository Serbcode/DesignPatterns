namespace CommandPattern4.Commands;

using CommandPattern4.DataStore;

internal class DisplayUsersCommand : Command
{
    private readonly IUserStore _userStore;

    public DisplayUsersCommand(CommandContext context)
    {
        _userStore = context.DataStore ?? throw new ArgumentNullException(nameof(context.DataStore));
    }

    public override void Execute()
    {
        var users = _userStore.GetUsers();
        users.ToList().ForEach(u => Console.WriteLine(u.Username));
    }
}