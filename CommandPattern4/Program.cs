using CommandPattern4.DataStore;
using CommandPattern4.Commands;
using CommandPattern4.Management;

namespace CommandPattern4;

public class Program
{
    public static void Main(string[] args)
    {
        // Invoker
        var userManager = new UserManager();

        // Receiver
        var userStore = new InMemoryUserStore();

        CommandFactory.Usage();

        do
        {
            var input = Console.ReadLine();

            if (input is null || input == "exit")
            {
                break;
            }

            var cmd = CommandFactory.CreateCommand(input, userStore);

            if (cmd is UnknownUserCommand)
            {
                CommandFactory.Usage();
            }

            userManager.Invoke(cmd);

        } while (true);
    }
}

internal static class CommandFactory
{
    public static Command CreateCommand(string input, IUserStore store)
    {
        var parts = input.Split(' ');
        var cmd = parts[0].ToLower();
        var context = new CommandContext(store);

        return cmd switch
        {
            "add" => new AddUserCommand(new User(parts[1], parts[2]), context),
            "remove" => new RemoveUserCommand(parts[1], context),
            "display" => new DisplayUsersCommand(context),
            _ => new UnknownUserCommand(context),
        };
    }

    public static void Usage()
    {
        Console.WriteLine("┌──────────────────────────────┐");
        Console.WriteLine("│Usage: add <username> <passwd>│");
        Console.WriteLine("│Usage: remove <username>      │");
        Console.WriteLine("│Usage: display                │");
        Console.WriteLine("│Usage: exit                   │");
        Console.WriteLine("└──────────────────────────────┘");
    }
}