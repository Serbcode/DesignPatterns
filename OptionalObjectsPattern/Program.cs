using OptionalObjectsPattern.Models;

var BobMartin = Author.Create("Robert", "Martin");
var MartinFowler = Author.Create("Martin");

var CleanCodeBook = Book.Create("Clean Code", BobMartin);
var RefactoringBook = Book.Create("Refactoring", MartinFowler);
var CleanArchitecture = Book.Create("Clean Architecture");

string GetLabel(Author author) =>
    author.LastName
        .Apply(LastName => $"{author.FirstName} {LastName}")
        .GetValueOrDefault(author.FirstName);

string GetBookLabel(Book book) =>
    book.Author
        .Apply(GetLabel)
        .Apply(author => $"{book.Title} - {author}")
        .GetValueOrDefault(book.Title);

Console.WriteLine(GetBookLabel(CleanCodeBook));
Console.WriteLine(GetBookLabel(RefactoringBook));
Console.WriteLine(GetBookLabel(CleanArchitecture));


Option<string> CompanyName = Option<string>.Some("Microsoft");

Console.WriteLine(CompanyName
    .Apply(str => str.ToUpper())
    .GetValueOrDefault(string.Empty)
);
