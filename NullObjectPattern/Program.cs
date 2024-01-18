using NullObjectPattern.Products;

var repo = new ProductRepository();

while (true)
{
    var input = Console.ReadLine();

    if (string.IsNullOrEmpty(input) || int.TryParse(input, out int id) == false)
        break;

    Console.WriteLine(
        repo.GetById(id).GetSummary()
    );
}

Console.WriteLine(repo.NotFound == repo.GetById(-1));
