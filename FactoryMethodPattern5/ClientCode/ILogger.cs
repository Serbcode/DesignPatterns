namespace FactoryMethodPattern5.ClientCode;

public interface ILogger<T>
{
    public void LogInformation(string message);
}

internal class ConsoleLogger<T> : ILogger<T>
{
    public void LogInformation(string message) =>
        System.Console.WriteLine(typeof(T).FullName + ": " + message);
}
