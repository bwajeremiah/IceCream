namespace IceCream;
using MongoDB.Driver;
using IceCream.Data;
public partial class Form2 : Form
{
    MongoClient client = new MongoClient("mongodb+srv://bwajeremiah_db_user:39Firehouse@cluster0.hklay79.mongodb.net/?appName=Cluster0");
    string FlavorChosen = "placeholder";
    string ToppingChosen = "placeholder";
    ComboBox OrderFlavor;
    private void LoadComboBoxData()
        {
            try
            {

                // Get database and collection
                var database = client.GetDatabase("IceCream");
                var collection = database.GetCollection<FlavorOpt>("Flavors");
                // Fetch all documents
                var documents = collection.Find(new FlavorOpt()).ToList();
                OrderFlavor.Items.Clear();
                foreach (var doc in documents)
                {
                    if (doc.Contains("Flavor") && doc["Flavor"].IsString)
                    {
                        OrderFlavor.Items.Add(doc["Flavor"].AsString);
                    }
                }
            }
                catch (MongoConnectionException ex)
                {
                MessageBox.Show($"Error connecting to MongoDB: {ex.Message}", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        

    public Form2()
    {
        InitializeComponent();
        Load += Form2_Load;
        var Message = new Label
        {
            Text = "Order",
            Size = new Size(200, 30),
            Location = new Point(325, 30),
            Font = new Font("SansSerif", 16),
        };
        Controls.Add(Message);
        TextBox DiplayFlavorChoice = new TextBox
        {
            Location = new Point(30, 60),
            Size = new Size(200, 30),
        };
        Controls.Add(DiplayFlavorChoice);
        OrderFlavor = new ComboBox();
        {
        OrderFlavor.Location = new Point(30,100);
        OrderFlavor.Size = new Size(200,30);
        OrderFlavor.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        OrderFlavor.Items.Add("C#");
        OrderFlavor.Items.Add("Java");
        OrderFlavor.Items.Add("Python");
        Controls.Add(OrderFlavor);
    }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (OrderFlavor.SelectedItem != null)
            {
                FlavorChosen = OrderFlavor.SelectedItem.ToString();
                TextBox DisplayFlavorChoice = Controls.Find("DisplayFlavorChoice", true).FirstOrDefault() as TextBox;
                DisplayFlavorChoice?.Text = FlavorChosen;
                MessageBox.Show($"You selected: {FlavorChosen}");
            }
        }
    

     private void Form2_Load(object? sender, EventArgs e)
    {
        
    }
}