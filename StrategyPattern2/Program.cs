using System.Reflection;
using StrategyPattern2.Abstract;

public class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Please enter a parser name (MVideo, Mtc, Dns): ");
            var input = Console.ReadLine();

            if (input is null)
            {
                return;
            }

            // 2. instantiate a strategy class
            var strategy = InstantiateStrategy<IPeriodParser>(input);

            // 3. call the strategy class
            Console.WriteLine(strategy.Parse("from 12.01 to 12.09"));
        } while (true);
    }

    private static T InstantiateStrategy<T>(string parserKey)
    {
        var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.IsAssignableFrom(t) && string.Equals(t.Name, $"{parserKey}Parser", StringComparison.InvariantCultureIgnoreCase)) ??
                 throw new ArgumentException($"Parser for {parserKey} not found", nameof(parserKey));

        return (T)Activator.CreateInstance(type);
    }
}
