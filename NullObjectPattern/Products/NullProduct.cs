namespace NullObjectPattern.Products;
using NullObjectPattern.Abstract;

internal class NullProduct : AbstractProduct
{
    public override int Id { get; set; }
    public override string? Name { get; set; }
    public override string GetSummary()
    {
        return $"Product: {Name}";
    }
}