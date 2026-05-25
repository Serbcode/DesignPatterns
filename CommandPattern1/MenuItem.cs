/// <summary>
/// Represents an item being ordered from this restaurant.
/// </summary>
/// <param name="Name"></param>
/// <param name="Amount"></param>
/// <param name="Price"></param>
public class MenuItem(string Name, int Amount, double Price)
{
    public string Name { get; set; } = Name;
    public int Amount { get; set; } = Amount;
    public double Price { get; set; } = Price;
    public override string ToString() =>
         $"Name: {Name}, Amount: {Amount}, Price: ${Price}";
}