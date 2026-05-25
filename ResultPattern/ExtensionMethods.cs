public static class ExtensionMethods
{
    public record Employee(string Name, int Age);

    static bool IsYoung(Employee employee) => employee.Age < 30;
    static string FirstName(Employee employee) => employee.Name.Split(' ')[0];

    public static TOutput Match<TInput, TOutput>
        (this TInput @this, params (Func<TInput, bool> IsMatch, Func<TInput, TOutput> Transform)[] matches)
    {
        var match = matches.FirstOrDefault(x => x.IsMatch(@this));
        var returnValue = match.Transform(@this) ?? default;

        return returnValue ?? default!;

    }

    public static readonly IReadOnlyCollection<Employee> EmployeeList =
        [
            new("Alice", 30),
            new("Bob", 25),
            new("Charlie", 35)
        ];
}
