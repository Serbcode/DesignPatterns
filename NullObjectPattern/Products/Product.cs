namespace NullObjectPattern.Products;

internal class Product : Abstract.AbstractProduct
{
    public override int Id { get; set; }
    public override string? Name { get; set; }
    public override string GetSummary()
    {
        return $"Product: {Id} - {Name}";
    }
}