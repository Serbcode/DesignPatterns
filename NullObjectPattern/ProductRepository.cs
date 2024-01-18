using NullObjectPattern.Abstract;
using NullObjectPattern.Products;

internal class ProductRepository
{
    private readonly List<AbstractProduct> _products;

    public readonly NullProduct NotFound = new() { Id = -1, Name = "Not Found" };

    public ProductRepository() => _products = new List<AbstractProduct>()
        {
            new Product() { Id = 1, Name = "Product 1" },
            new Product() { Id = 2, Name = "Product 2" },
            new Product() { Id = 3, Name = "Product 3" },
        };

    public AbstractProduct GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product ?? NotFound;
    }

    public List<AbstractProduct> GetAllProducts()
    {
        return _products;
    }
}
