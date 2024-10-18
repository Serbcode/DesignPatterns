namespace CommandPattern4.Commands;

using CommandPattern4.DataStore;

internal class RemoveUserCommand : Command
{
    private readonly IUserStore _userStore;
    private readonly string _username;

    public RemoveUserCommand(string username, CommandContext context)
    {
        ArgumentNullException.ThrowIfNull(username, nameof(username));
        _userStore = context.DataStore;
        _username = username;
    }

    public override void Execute()
    {
        _userStore.RemoveUser(_username);
    }
}
