namespace CommandPattern4.DataStore;

/// <summary>
/// User data model
/// </summary>
/// <param name="Username">fixed string represents user name</param>
/// <param name="Password">fixed string represents clear text user password</param> <summary> 
/// </summary>
internal record User(string Username, string Password);

internal interface IUserStore
{
    void AddUser(User user);
    void RemoveUser(string username);
    User GetUser(string username);
    User? FindUser(string username);
    IEnumerable<User> GetUsers();
}

/// <summary>
/// Receiver
/// </summary>
internal class InMemoryUserStore : IUserStore
{
    private readonly List<User> users = new();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void RemoveUser(string username)
    {
        users.Remove(users.First(u => u.Username == username));
    }

    public User GetUser(string username)
    {
        return users.First(u => u.Username == username);
    }

    public User? FindUser(string username)
    {
        return users.FirstOrDefault(u => u.Username == username);
    }

    public IEnumerable<User> GetUsers()
    {
        return users;
    }
}
