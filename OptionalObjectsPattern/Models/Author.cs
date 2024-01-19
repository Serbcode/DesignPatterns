namespace OptionalObjectsPattern.Models;

public class Author
{
    private Author(string FirstName, Option<string> LastName) => (this.FirstName, this.LastName) = (FirstName, LastName);

    public static Author Create(string FirstName, string LastName) => new(FirstName, Option<string>.Some(LastName));

    public static Author Create(string FirstName) => new(FirstName, Option<string>.None());

    public string FirstName { get; }

    public Option<string> LastName { get; }
}