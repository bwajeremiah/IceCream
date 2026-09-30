using MongoDB.Bson;
namespace IceCream.Data;

public class FlavorOpt
{
    public ObjectId Id { get; set; }
    public required string Flavor { get; set; }
}

public class ToppingOpt
{
    public ObjectId Id { get; set; }
    public string? Topping { get; set; }
}
public class SizePrice
{
    public ObjectId Id { get; set; }
    public double Price { get; set; }
    public string? Size { get; set; }
}
public class ConePrices
{
    public ObjectId Id { get; set; }
    public double Price { get; set; }
    public string? ConeType { get; set; }
}