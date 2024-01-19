using OptionalObjectsPattern.Models;

var BobMartin = Author.Create("Robert", "Martin");
var MartinFowler = Author.Create("Martin");

var CleanCodeBook = Book.Create("Clean Code", BobMartin);
var RefactoringBook = Book.Create("Refactoring", MartinFowler);
var CleanArchitecture = Book.Create("Clean Architecture");

string GetLabel(Author author) =>
    author.LastName
        .Map(LastName => $"{author.FirstName} {LastName}")
        .Reduce(author.FirstName);

string GetBookLabel(Book book) =>
    book.Author
        .Map(GetLabel)
        .Map(author => $"{book.Title} - {author}")
        .Reduce(book.Title);

Console.WriteLine(GetBookLabel(CleanCodeBook));
Console.WriteLine(GetBookLabel(RefactoringBook));
Console.WriteLine(GetBookLabel(CleanArchitecture));