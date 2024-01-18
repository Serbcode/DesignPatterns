namespace NullObjectPattern.Abstract;

internal abstract class AbstractProduct
{
    public abstract int Id { get; set; }
    public abstract string? Name { get; set; }
    public abstract string GetSummary();
}
