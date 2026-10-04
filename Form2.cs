namespace IceCream;
using MongoDB.Driver;
using IceCream.Data;
public partial class Form2 : Form
{
    MongoClient client = new MongoClient("mongodb+srv://bwajeremiah_db_user:39Firehouse@cluster0.hklay79.mongodb.net/?appName=Cluster0");

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
    }

     private void Form2_Load(object? sender, EventArgs e)
    {
        
    }
}