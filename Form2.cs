namespace IceCream;
using MongoDB.Driver;
using IceCream.Data;
using MongoDB.Driver.Linq;

public partial class Form2 : Form
{
    MongoClient client = new MongoClient("mongodb+srv://bwajeremiah_db_user:39Firehouse@cluster0.hklay79.mongodb.net/?appName=Cluster0");
    string? FlavorChosen = "Your Flavor Choice";
    string? ConeChosen = "Your Cone Choice";
    string? SizeChosen = "Your Size Choice";
    string? ToppingChosen1 = "FreeTopping!";
    string? ToppingChosen2 = "2nd Topping";
    string? ToppingChosen3 = "3rd Topping";
    string? ToppingChosen4 = "4th Topping";
    string? ToppingChosen5 = "5th Topping";
    Button CalculateOrder;
    ComboBox OrderFlavor;
    TextBox DisplayFlavorChoice;
    ComboBox OrderSize;
    TextBox DisplaySizeChoice;
    ComboBox OrderCone;
    TextBox DisplayConeChoice;
    ComboBox OrderTopping1;
    TextBox DisplayToppingChoice1;
    ComboBox OrderTopping2;
    TextBox DisplayToppingChoice2;
    ComboBox OrderTopping3;
    TextBox DisplayToppingChoice3;
    ComboBox OrderTopping4;
    TextBox DisplayToppingChoice4;
    ComboBox OrderTopping5;
    TextBox DisplayToppingChoice5;
    void SetFlavorChoice()
    {
        if (OrderFlavor is null)
        {
            return;
        }

        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<FlavorOpt>("Flavors");
        var flavors = collection.Find(_ => true).ToList();
        foreach (var flavor in flavors)
        {
            OrderFlavor.Items.Add(flavor.Flavor);
        }
    }
    void SetSizeChoice()
    {
        OrderSize.Items.Add(new KeyValuePair<string, double>("Mini", 4.50));
        OrderSize.Items.Add(new KeyValuePair<string, double>("Small", 7.50));
        OrderSize.Items.Add(new KeyValuePair<string, double>("Medium", 8.50));
        OrderSize.Items.Add(new KeyValuePair<string, double>("Large", 9.50));
    }
    void SetConeChoice()
    {
        if (OrderCone is null)
        {
            return;
        }

        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<ConePrices>("Cones");
        var cones = collection.Find(_ => true).ToList();
        foreach (var cone in cones)
        {
            OrderCone.Items.Add(new KeyValuePair<string?, double>(cone.ConeType, cone.Price));
        }
    }
    void SetToppingChoice()
    {
        if (OrderTopping1 is null || OrderTopping2 is null || OrderTopping3 is null || OrderTopping4 is null || OrderTopping5 is null)
        {
            return;
        }

        var database = client.GetDatabase("IceCream");
        var collection = database.GetCollection<ToppingOpt>("Toppings");
        var toppings = collection.Find(_ => true).ToList();
        foreach (var topping in toppings)
        {
            var price = string.Equals(topping.Topping?.Trim(), "NO Mix IN", StringComparison.OrdinalIgnoreCase)
                ? 0
                : topping.Price;
            OrderTopping1.Items.Add(new KeyValuePair<string?, double>(topping.Topping, topping.Price));
            OrderTopping2.Items.Add(new KeyValuePair<string?, double>(topping.Topping, topping.Price));
            OrderTopping3.Items.Add(new KeyValuePair<string?, double>(topping.Topping, topping.Price));
            OrderTopping4.Items.Add(new KeyValuePair<string?, double>(topping.Topping, topping.Price));
            OrderTopping5.Items.Add(new KeyValuePair<string?, double>(topping.Topping, topping.Price));
        }
    }
    
    public Form2()
    {
        InitializeComponent();
        Load += Form2_Load;

        OrderFlavor = new ComboBox
        {
            Location = new Point(30, 100),
            Size = new Size(200, 30),
            DropDownStyle = ComboBoxStyle.DropDownList,
            DropDownWidth = 400,
        };
        Controls.Add(OrderFlavor);
        OrderFlavor.SelectedIndexChanged += OrderFlavor_SelectedIndexChanged;

        SetFlavorChoice();

        var Message = new Label
        {
            Text = "Order",
            Size = new Size(200, 30),
            Location = new Point(325, 30),
            Font = new Font("SansSerif", 16),
        };
        Controls.Add(Message);
        DisplayFlavorChoice = new TextBox
        {
            Location = new Point(30, 60),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayFlavorChoice);
        DisplaySizeChoice = new TextBox
        {
            Location = new Point(30, 140),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplaySizeChoice);
        DisplayConeChoice = new TextBox
        {
            Location = new Point(30, 220),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayConeChoice);
        DisplayToppingChoice1 = new TextBox
        {
            Location = new Point(30, 300),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayToppingChoice1);
        DisplayToppingChoice2 = new TextBox
        {
            Location = new Point(570, 60),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayToppingChoice2);
        DisplayToppingChoice3 = new TextBox
        {
            Location = new Point(570, 140),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayToppingChoice3);
        DisplayToppingChoice4 = new TextBox
        {
            Location = new Point(570, 220),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayToppingChoice4);
        DisplayToppingChoice5 = new TextBox
        {
            Location = new Point(570, 300),
            Size = new Size(200, 30),
            ReadOnly = true,
        };
        Controls.Add(DisplayToppingChoice5);
        OrderTopping1 = new ComboBox();
        {
            OrderTopping1.Location = new Point(30, 340);
            OrderTopping1.Size = new Size(200, 30);
            OrderTopping1.DropDownStyle = ComboBoxStyle.DropDownList;
            OrderTopping1.DropDownWidth = 400;
        }   
       
        Controls.Add(OrderTopping1);
        OrderTopping1.SelectedIndexChanged += OrderTopping1_SelectedIndexChanged;
        DisplayToppingChoice1.Text = ToppingChosen1;
        OrderTopping2 = new ComboBox();
        {
            OrderTopping2.Location = new Point(570, 100);
            OrderTopping2.Size = new Size(200, 30);
            OrderTopping2.DropDownStyle = ComboBoxStyle.DropDownList;
            OrderTopping2.DropDownWidth = 400;
        }   
        Controls.Add(OrderTopping2);
        OrderTopping2.SelectedIndexChanged += OrderTopping2_SelectedIndexChanged;
        DisplayToppingChoice2.Text = ToppingChosen2;
        OrderTopping3 = new ComboBox();
        {
            OrderTopping3.Location = new Point(570, 180);
            OrderTopping3.Size = new Size(200, 30);
            OrderTopping3.DropDownStyle = ComboBoxStyle.DropDownList;
            OrderTopping3.DropDownWidth = 400;
        }
        Controls.Add(OrderTopping3);
        OrderTopping3.SelectedIndexChanged += OrderTopping3_SelectedIndexChanged;
        DisplayToppingChoice3.Text = ToppingChosen3;
        OrderTopping4 = new ComboBox();
        {
            OrderTopping4.Location = new Point(570, 260);
            OrderTopping4.Size = new Size(200, 30);
            OrderTopping4.DropDownStyle = ComboBoxStyle.DropDownList;
            OrderTopping4.DropDownWidth = 400;
        }
        Controls.Add(OrderTopping4);
        OrderTopping4.SelectedIndexChanged += OrderTopping4_SelectedIndexChanged;
        DisplayToppingChoice4.Text = ToppingChosen4;
        OrderTopping5 = new ComboBox();
        {
            OrderTopping5.Location = new Point(570, 340);
            OrderTopping5.Size = new Size(200, 30);
            OrderTopping5.DropDownStyle = ComboBoxStyle.DropDownList;
            OrderTopping5.DropDownWidth = 400;
        }  
        Controls.Add(OrderTopping5);
        OrderTopping5.SelectedIndexChanged += OrderTopping5_SelectedIndexChanged;
        DisplayToppingChoice5.Text = ToppingChosen5;
        OrderCone = new ComboBox();
        {
            OrderCone.Location = new Point(30, 260);
            OrderCone.Size = new Size(200, 30);
            OrderCone.DropDownStyle = ComboBoxStyle.DropDownList;
            OrderCone.DropDownWidth = 400;
        }
        SetConeChoice();
        Controls.Add(OrderCone);
        OrderCone.SelectedIndexChanged += OrderCone_SelectedIndexChanged;
        DisplayConeChoice.Text = ConeChosen;
        
        OrderSize = new ComboBox();
        {
        OrderSize.Location = new Point(30,180);
        OrderSize.Size = new Size(200,30);
        OrderSize.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        Controls.Add(OrderSize);
        SetSizeChoice();
        OrderSize.SelectedIndexChanged += OrderSize_SelectedIndexChanged;
        DisplaySizeChoice.Text = SizeChosen;
        DisplayFlavorChoice.Text = FlavorChosen;
        SetToppingChoice();
        CalculateOrder = new Button
        {
            Location = new Point(325, 380),
            Size = new Size(150, 30),
            Text = "Calculate Order"
        };
        Controls.Add(CalculateOrder);
        CalculateOrder.Click += (sender, e) =>
        {
            CalculateUserOrder();
        };
    }
        private void OrderFlavor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderFlavor.SelectedItem is string selectedFlavor)
            {
                FlavorChosen = selectedFlavor;
                DisplayFlavorChoice.Text = "You Chose: " + FlavorChosen;
            }
        }
        private void OrderSize_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderSize.SelectedItem is string selectedSize)
            {
                SizeChosen = selectedSize;
                DisplaySizeChoice.Text = "You Chose: " + SizeChosen;
            }
        }
        private void OrderCone_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderCone.SelectedItem is string selectedCone)
            {
                ConeChosen = selectedCone;
                DisplayConeChoice.Text = "You Chose: " + ConeChosen;
            }
        }
        private void OrderTopping1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderTopping1.SelectedItem is string selectedTopping1)
            {
                ToppingChosen1 = selectedTopping1;
                DisplayToppingChoice1.Text = "Free: " + ToppingChosen1;
            }
        }
        private void OrderTopping2_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderTopping2.SelectedItem is string selectedTopping2)
            {
                ToppingChosen2 = selectedTopping2;
                DisplayToppingChoice2.Text = "2:" + ToppingChosen2;
            }
        }
        private void OrderTopping3_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderTopping3.SelectedItem is string selectedTopping3)
            {
                ToppingChosen3 = selectedTopping3;
                DisplayToppingChoice3.Text = "3:" + ToppingChosen3;
            }
        }
        private void OrderTopping4_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderTopping4.SelectedItem is string selectedTopping4)
            {
                ToppingChosen4 = selectedTopping4;
                DisplayToppingChoice4.Text = "4:" + ToppingChosen4;
            }
        }
        private void OrderTopping5_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderTopping5.SelectedItem is string selectedTopping5)
            {
                ToppingChosen5 = selectedTopping5;
                DisplayToppingChoice5.Text = "5:" + ToppingChosen5;
            }
        }
        void CalculateUserOrder()
        {
            double sizeSelectedPrice = OrderSize.SelectedItem is KeyValuePair<string, double> sizeSelected ? sizeSelected.Value : 0;
            double coneSelectedPrice = OrderCone.SelectedItem is KeyValuePair<string?, double> coneSelected ? coneSelected.Value : 0;
            double topping1SelectedPrice = OrderTopping1.SelectedItem is KeyValuePair<string?, double> topping1Selected ? topping1Selected.Value : 0;
            double topping2SelectedPrice = OrderTopping2.SelectedItem is KeyValuePair<string?, double> topping2Selected ? topping2Selected.Value : 0;
            double topping3SelectedPrice = OrderTopping3.SelectedItem is KeyValuePair<string?, double> topping3Selected ? topping3Selected.Value : 0;
            double topping4SelectedPrice = OrderTopping4.SelectedItem is KeyValuePair<string?,  double> topping4Selected ? topping4Selected.Value : 0;
            double topping5SelectedPrice = OrderTopping5.SelectedItem is KeyValuePair<string?,  double> topping5Selected ? topping5Selected.Value : 0;
            double totalPrice = sizeSelectedPrice + coneSelectedPrice + topping1SelectedPrice + topping2SelectedPrice + topping3SelectedPrice + topping4SelectedPrice + topping5SelectedPrice;
            MessageBox.Show($"Your Order is: {Environment.NewLine}{FlavorChosen}{Environment.NewLine}{ OrderSize.SelectedItem}{Environment.NewLine}{OrderCone.SelectedItem}{Environment.NewLine}{OrderTopping1.SelectedItem}{Environment.NewLine}{OrderTopping2.SelectedItem}{Environment.NewLine}{OrderTopping3.SelectedItem}{Environment.NewLine}{OrderTopping4.SelectedItem}{Environment.NewLine}{OrderTopping5.SelectedItem}{Environment.NewLine}{"total price is: $"}{totalPrice}");
        }

     private void Form2_Load(object? sender, EventArgs e)
    {
    
    }
}