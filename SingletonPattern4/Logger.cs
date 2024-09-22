namespace SingletonPattern4;

/// <summary>
/// When there must be exactly one instance of a class
/// and it must be accessible to clients from well-known 
/// access point
/// </summary>
public class Logger
{
    private static Lazy<Logger> _instance
        = new(() => new Logger(), isThreadSafe: true);

    protected Logger()
    {
    }

    public static Logger Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    public void Log(string message)
    {
        System.Console.WriteLine($"Logged message: {message}");
    }
}