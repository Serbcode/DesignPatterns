using OptionalObjectsPattern.Models;

public class Book
{
    public string Title { get; }
    public Option<Author> Author { get; }

    private Book(string Title, Option<Author> Author)
     => (this.Title, this.Author) = (Title, Author);

    public static Book Create(string Title, Author Author) => new(Title, Option<Author>.Some(Author));

    public static Book Create(string Title) => new(Title, Option<Author>.None());
}