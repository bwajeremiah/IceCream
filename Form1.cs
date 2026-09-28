namespace IceCream;
using MongoDB.Driver;
using IceCream.Data;
public partial class Form1 : Form
{
    MongoClient client = new MongoClient("mongodb+srv://bwajeremiah_db_user:39Firehouse@cluster0.hklay79.mongodb.net/?appName=Cluster0");
    void SetFlavorPrices()
    {
        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<FlavorPrices>("Prices");
        var document = new FlavorPrices 
        {
            Price = 1.99,
            Flavor = "",
        };
        collection.InsertOne(document);
    }
    void SetToppingPrices()
    {
        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<ToppingPrices>("Prices");
        var document = new ToppingPrices 
        {
            Price = 1.99,
            Topping = "GramCrackers",
        };
        collection.InsertOne(document); 
    }
    
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
    }
    private void Form1_Load(object? sender, EventArgs e)
    {
        SetFlavorPrices();
        SetToppingPrices();
    }
}
