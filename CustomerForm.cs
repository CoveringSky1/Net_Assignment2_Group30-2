using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class CustomerForm : Form
    {
        public Customer customer;
        public string username;
        public List<CProduct> products;
        public List<CShoppingCartItem> Shoppingcart = new List<CShoppingCartItem>();

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            CName.Text = customer.CustomerName;
            products = new CProduct().readtxtProduct();
            loadProduct(products);
        }

        public CustomerForm(string username)
        {
            InitializeComponent();
            this.username = username;
            customer = new Customer(username);
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            ShoppingCart cart = new ShoppingCart(username,Shoppingcart,this);
            cart.Show();
            this.Hide();
        }


        public void loadProduct(List<CProduct> Theproducts)
        {
            MainPanel.Controls.Clear();
            Label Image = new Label { Text = "Image", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Name = new Label { Text = "Name", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Price = new Label { Text = "Price", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Stock = new Label { Text = "Stock", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Quatity = new Label { Text = "Quatity", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Add = new Label { Text = "Add", Font = new Font("Arial", 15, CName.Font.Style) };

            FlowLayoutPanel TitleLayoutPanel = new FlowLayoutPanel();
            TitleLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            TitleLayoutPanel.WrapContents = false;
            TitleLayoutPanel.AutoSize = true;

            TitleLayoutPanel.Controls.Add(Image);
            TitleLayoutPanel.Controls.Add(Name);
            TitleLayoutPanel.Controls.Add(Price);
            TitleLayoutPanel.Controls.Add(Stock);
            TitleLayoutPanel.Controls.Add(Quatity);
            TitleLayoutPanel.Controls.Add(Add);

            MainPanel.Controls.Add(TitleLayoutPanel);

            for (int i = 0; i< Theproducts.Count;i++)
            {
                Label productName = new Label { Text = Theproducts[i].ProductName, Font = new Font("Arial", 15, CName.Font.Style) };
                Label productStock= new Label { Text = Theproducts[i].ProductStock, Font = new Font("Arial", 15, CName.Font.Style) };
                PictureBox productImage = new PictureBox {SizeMode = PictureBoxSizeMode.StretchImage };
                productImage.Load(Theproducts[i].ProductImageURL);
                Label productPrice = new Label { Text = Theproducts[i].ProductPrice, Font = new Font("Arial", 15, CName.Font.Style) };
                NumericUpDown quantitySelector = new NumericUpDown {Minimum = 1, Maximum= 99999};
                Button buyButton = new Button { Text = "Add", Font = new Font("Arial", 10, CName.Font.Style) };
                Button detialButton = new Button { Text = "Detail", Font = new Font("Arial", 10, CName.Font.Style) };
                CProduct product = Theproducts[i];

                detialButton.Click += (sender, e) =>
                {
                    ProductDetialForm productDetialForm = new ProductDetialForm(product);
                    productDetialForm.ShowDialog();
                };

                buyButton.Click += (sender, e) => {
                    int quantity = (int)quantitySelector.Value;
                    CShoppingCartItem item = new CShoppingCartItem(product,quantity);
                    bool isExist = false;
                    int index = 0;

                    if(quantity > Convert.ToInt32(product.ProductStock))
                    {
                        MessageBox.Show($"Not enough stock!");
                        return;
                    }
                    
                    for(int x=0; x < Shoppingcart.Count; x++)
                    {
                        if(Shoppingcart[x].Product == item.Product)
                        {
                            isExist = true;
                            index = x;
                        }
                    }
                    if (isExist)
                    {
                        quantity = quantity + Shoppingcart[index].quatity;
                        if(quantity <= Convert.ToInt32(product.ProductStock))
                        {
                            CShoppingCartItem item1 = new CShoppingCartItem(product, quantity);
                            Shoppingcart[index] = item1;
                            MessageBox.Show($"{quantity} x {Shoppingcart[index].Product.ProductName} currently!");
                        }
                        else
                        {
                            MessageBox.Show($"Not enough stock!");
                            return;
                        }
                    }
                    else if (!isExist)
                    {
                        Shoppingcart.Add(item);
                        MessageBox.Show($"{quantity} x {product.ProductName} added to cart!");
                    }
                };

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel ();
                flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanel.WrapContents = false;
                flowLayoutPanel.AutoSize = true;

                flowLayoutPanel.Controls.Add(productImage);
                flowLayoutPanel.Controls.Add(productName);
                flowLayoutPanel.Controls.Add(productPrice);
                flowLayoutPanel.Controls.Add(productStock);
                flowLayoutPanel.Controls.Add(quantitySelector);
                flowLayoutPanel.Controls.Add(buyButton);
                flowLayoutPanel.Controls.Add(detialButton);

                MainPanel.Controls.Add(flowLayoutPanel);

            }
        }

        private void All_Click(object sender, EventArgs e)
        {
            products = new CProduct().readtxtProduct();
            loadProduct(products);
        }

        private void Fruit_Click(object sender, EventArgs e)
        {
            products = new CProduct().readtxtProductByType("Fruit");
            loadProduct(products);
        }

        private void Seafood_Click(object sender, EventArgs e)
        {
            products = new CProduct().readtxtProductByType("Seafood");
            loadProduct(products);
        }

        private void Meat_Click(object sender, EventArgs e)
        {
            products = new CProduct().readtxtProductByType("Meat");
            loadProduct(products);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            products = new CProduct().readtxtProductByName(name);
            loadProduct(products);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Close();
        }
    }
}
