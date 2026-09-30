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
        TextBox flavorBox = new TextBox
        {
            Location = new Point(30, 60),
            Size = new Size(200, 30),
            Text = "Enter flavor",
        };
        Controls.Add(flavorBox);
        Button setFlavorButton = new Button
        {
            Location = new Point(30, 100),
            Size = new Size(200, 30),
            Text = "Set Flavor"
        };
        Controls.Add(setFlavorButton);
        setFlavorButton.Click += (sender, e) => // i dont know what  "(sender,e) does but the ai recmoends it and without it code does not work.  
        {
            flavor = flavorBox.Text;
            SetFlavor();
        };
        TextBox toppingBox = new TextBox
        {
            Location = new Point(30, 140),
            Size = new Size(200, 30), 
            Text = "Enter topping",
        };
        Controls.Add(toppingBox);
        Button setToppingButton = new Button
        {
            Location = new Point(30, 180),
            Size = new Size(200, 30),
            Text = "Set Topping"
        };
        Controls.Add(setToppingButton);
        setToppingButton.Click += (sender, e) =>
        {
            topping = toppingBox.Text;
            SetTopping();
        };
    }
    private void Form1_Load(object? sender, EventArgs e)
    {
        
    }
}
