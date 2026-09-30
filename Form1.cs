namespace IceCream;
using MongoDB.Driver;
using IceCream.Data;
public partial class Form1 : Form
{
    MongoClient client = new MongoClient("mongodb+srv://bwajeremiah_db_user:39Firehouse@cluster0.hklay79.mongodb.net/?appName=Cluster0");
    string flavor = "Placeholder";
     string topping = "Placeholder";
    void SetFlavor()
    {
        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<FlavorOpt>("Flavors");
        var document = new FlavorOpt
        {
            Flavor = flavor,
        };
        collection.InsertOne(document);
    }
    void SetTopping()
    {
        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<ToppingOpt>("Toppings");
        var document = new ToppingOpt 
        {
            Topping = topping,
        };
        collection.InsertOne(document); 
    }
    void Setcone()
    {
        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<ConePrices>("Cones");
        var document = new ConePrices
        {
            Price = 2.99,
            ConeType = "SprinkeledWaffleCone"
        };
        collection.InsertOne(document);
          var document1 = new ConePrices
        {
            Price = 2.99,
            ConeType = "ChocolateDippedWaffleCone"
        };
        collection.InsertOne(document1);
          var document2 = new ConePrices
        {
            Price = 2.99,
            ConeType = "SprinkledWaffleBowl"
        };
        collection.InsertOne(document2);
          var document3 = new ConePrices
        {
            Price = 2.99,
            ConeType = "ChocolateDippedWaffleBowl"
        };
        collection.InsertOne(document3);
           var document4 = new ConePrices
        {
            Price = 1.709,
            ConeType = "PlainWaffleCone"
        };
        collection.InsertOne(document4);
           var document5 = new ConePrices
        {
            Price = 1.709,
            ConeType = "PlainWaffleBowl"
        };
        collection.InsertOne(document5);
        var document6 = new ConePrices
        {
            Price = 1.709,
            ConeType = "NoConeOrBowl(Paperbowl)"
        };
        collection.InsertOne(document6);
    }
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
        var Message = new Label
        {
            Text = "Test Text",
            AutoSize = true,
            Location = new Point(30, 30),
            Font = new Font("SansSerif", 16),
        };
        Controls.Add(Message);
    }
    private void Form1_Load(object? sender, EventArgs e)
    {
        Setcone();
    }
}
