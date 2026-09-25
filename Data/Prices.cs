using MongoDB.Bson;
namespace IceCream.Data;


public class FlavorPrices
{
    public ObjectId Id { get; set; }
    public double Price { get; set; }
    public string Flavor { get; set; }
}

public class ToppingPrices
{
    public ObjectId Id { get; set; }
    public double Price { get;set; }
    public string? Topping { get; set; }
}