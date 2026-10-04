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
    void StartOrder()
    {
        new Form2().Show(this);
    }
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
        var Message = new Label
        {
            Text = "Upload",
            Size = new Size(200, 30),
            Location = new Point(335, 30),
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
        Button showFlavorButton = new Button
        {
            Location = new Point(290, 100),
            Size = new Size(200, 30),
            Text = "Show Flavors"
        };
        Controls.Add(showFlavorButton);
        showFlavorButton.Click += (sender, e) =>
        {
            try
            {
                var database = client.GetDatabase("IceCream");
                var collection = database.GetCollection<FlavorOpt>("Flavors");
                var flavors = collection.Find(_ => true).ToList()
                    .Select(item => item.Flavor)
                    .ToList();

                var message = flavors.Count > 0
                    ? string.Join(Environment.NewLine, flavors)
                    : "No flavors found.";
                MessageBox.Show(this, message, "All Flavors", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MongoException exception)
            {
                MessageBox.Show(this, $"Unable to load flavors: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };
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
            Location = new Point(570, 60),
            Size = new Size(200, 30), 
            Text = "Enter topping",
        };
        Controls.Add(toppingBox);
        Button setToppingButton = new Button
        {
            Location = new Point(570, 100),
            Size = new Size(200, 30),
            Text = "Set Topping"
        };
        Controls.Add(setToppingButton);
        setToppingButton.Click += (sender, e) =>
        {
            topping = toppingBox.Text;
            SetTopping();
        };
        Button OrderButton = new Button
        {
          Location = new Point(290,200),
          Size = new Size(200,30),
          Text = "Start Order"
        };
        Controls.Add(OrderButton);
        OrderButton.Click += (sender, e) =>
        {
            StartOrder();
        };
    }
    private void Form1_Load(object? sender, EventArgs e)
    {
        
    }
}
