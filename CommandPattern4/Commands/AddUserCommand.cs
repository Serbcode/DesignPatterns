namespace CommandPattern4.Commands;

using CommandPattern4.DataStore;

internal class AddUserCommand : Command
{
    private readonly IUserStore _userStore;
    private readonly User _user;

    public AddUserCommand(User user, CommandContext context)
    {
        _userStore = context.DataStore ?? throw new ArgumentNullException(nameof(context.DataStore));
        _user = user ?? throw new ArgumentNullException(nameof(user));
    }

    public override void Execute()
    {
        _userStore.AddUser(_user);
    }
}