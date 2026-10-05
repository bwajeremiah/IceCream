namespace IceCream;
using MongoDB.Driver;
using IceCream.Data;
public partial class Form1 : Form
{
    MongoClient client = new MongoClient("mongodb+srv://bwajeremiah_db_user:39Firehouse@cluster0.hklay79.mongodb.net/?appName=Cluster0");
    string flavor = "Placeholder";
    string topping = "Placeholder";
    string[] flave =
    {
    "Strawberry Ice Cream",
    "Vanilla Lite Ice Cream - No Sugar Added, Reduced Fat",
    "Amaretto Ice Cream",
    "Banana Ice Cream",
    "Banana Bread Batter Ice Cream",
    "Birthday Cake OREO® Cookie Ice Cream",
    "Black Cherry Ice Cream",
    "Butter Pecan Ice Cream",
    "Cake Batter™ Ganache Ice Cream",
    "Caramel Truffle Ice Cream",
    "Cherry Vanilla Ice Cream",
    "Chocolate Cake Batter Ice Cream®",
    "Chocolate Cake Batter™ Ganache Ice Cream",
    "Chocolate Dipped Strawberry Ice Cream",
    "Chocolate Peanut Butter Ice Cream",
    "Cinnamon Bun Batter Ice Cream",
    "Coconut Ice Cream",
    "Cotton Candy Ice Cream",
    "Cookie Butter Ice Cream",
    "Dark Chocolate Ice Cream",
    "Dulce de Leche Ice Cream",
    "Fudge Brownie Batter Ice Cream",
    "Fudge Truffle Ice Cream",
    "Mango Ice Cream",
    "Marshmallow Ice Cream",
    "OREO® Crème Ice Cream",
    "Pistachio Ice Cream",
    "Red Velvet Cake Batter™ Ice Cream",
    "Red Velvet Cake Ice Cream",
    "REESE'S Peanut Butter Cup Ice Cream",
    "Rum Raisin Ice Cream",
    "Salted Caramel Ice Cream",
    "Strawberry Cake Batter™ Ice Cream",
    "Strawberry Cheesecake Ice Cream",
    "Strawberry Marshmallow Ice Cream",
    "Strawberry Shortcake Ice Cream",
    "Vanilla Bean Ice Cream",
    "Lemon Sorbet",
    "Orange Sorbet",
    "Raspberry Sorbet",
    "Strawberry Mango Banana Sorbet",
    "Watermelon Sorbet",
    };
    string[] topp =
    {
    "No Mix In",
    "Halloween OREO® Cookies Mix-in",
    "HONEY MAID® Graham Crackers Mix-in",
    "Cookie Butter Mix-in",
    "Almond Joy® Mix-in",
    "Apple Pie Filling Mix-in",
    "Banana Mix-in",
    "Birthday Cake OREO® Cookies Mix-in",
    "Black Cherries Mix-in",
    "Blueberries Mix-in",
    "Brownie Mix-in",
    "Butterfinger® Mix-in",
    "Caramel Topping Mix-in",
    "Cashews Mix-in",
    "Cherry Pie Filling Mix-in",
    "Chocolate Chip Cookie Mix-in",
    "Chocolate Chip Cookie Dough Mix-in",
    "Chocolate Chips Mix-in",
    "Chocolate Shavings Mix-in",
    "Chocolate Sprinkles Mix-in",
    "Cinnamon Mix-in",
    "Coconut Mix-in",
    "Crunch Bar Mix-in",
    "Devil's Food Cake Mix-in",
    "Frosting Mix-in",
    "Fudge Topping Mix-in",
    "GOLDEN OREO® Cookie Mix-in",
    "Graham Cracker Pie Crust Mix-in",
    "Gummy Bears Mix-in",
    "Heath Bar Mix-in",
    "Honey Mix-in",
    "Kit Kat® Mix-in",
    "M&M'S® Mix-in",
    "Maraschino Cherries Mix-in",
    "Marshmallows Mix-in",
    "Nilla® Wafers Mix-in",
    "Nutella Mix-in",
    "OREO® Cookie Mix-in",
    "Peanut Butter Mix-in",
    "Peanut M&M'S® Mix-in",
    "Peanuts Mix-in",
    "Pecans Mix-in",
    "Pineapple Tidbits Mix-in",
    "Pistachios Mix-in",
    "Pretzels Mix-in",
    "Pumpkin Pie Spice Mix-in",
    "Rainbow Sprinkles Mix-in",
    "Raisins Mix-in",
    "Raspberries Mix-in",
    "Red Velvet Cake Mix-in",
    "REESE'S Peanut Butter Cups Mix-in",
    "REESE'S Peanut Butter Sauce Mix-in",
    "REESE'S Pieces Mix-in",
    "Roasted Almonds Mix-in",
    "Snickers® Mix-in",
    "Strawberries Mix-in",
    "Sugar Crystals Mix-in",
    "Twix® Mix-in",
    "Walnuts Mix-in",
    "Whipped Topping Mix-in",
    "Yellow Cake Mix-in",
    "York Peppermint Patties® Mix-in",
    };
    void ToppLoop()
    {
        foreach (string t in topp)
        {
            topping = t;
            SetTopping();
        }
    }
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
            Location = new Point(30,140),
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
         Button showToppingButton = new Button
        {
            Location = new Point(570,140),
            Size = new Size(200, 30),
            Text = "Show Toppings"
        };
        Controls.Add(showToppingButton);
        showToppingButton.Click += (sender, e) =>
        {
            try
            {
                var database = client.GetDatabase("IceCream");
                var collection = database.GetCollection<ToppingOpt>("Toppings");
                var toppings = collection.Find(_ => true).ToList()
                    .Select(item => item.Topping)
                    .ToList();

                var message = toppings.Count > 0
                    ? string.Join(Environment.NewLine, toppings)
                    : "No toppings found.";
                MessageBox.Show(this, message, "All Toppings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MongoException exception)
            {
                MessageBox.Show(this, $"Unable to load toppings: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
