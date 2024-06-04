using checkout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class ShoppingCart : Form
    {
        public Customer customer;
        public List<CShoppingCartItem> Shoppingcart;
        public string username;
        public CustomerForm customerForm;
        public float totalPrice;
        public ShoppingCart()
        {
            InitializeComponent();
        }

        public ShoppingCart(string username, List<CShoppingCartItem> Shoppingcart, CustomerForm customerF)
        {
            InitializeComponent();
            this.username = username;
            this.Shoppingcart = Shoppingcart;
            customer = new Customer(username);
            this.customerForm = customerF;
        }

        public void loadProduct()
        {
            Label Image = new Label { Text = "Image", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Name = new Label { Text = "Name", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Price = new Label { Text = "Price", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Quatity = new Label { Text = "Quatity", Font = new Font("Arial", 15, CName.Font.Style) };
            Label SubTotal = new Label { Text = "SubTotal", Font = new Font("Arial", 15, CName.Font.Style) };
            Label Add = new Label { Text = "Add", Font = new Font("Arial", 15, CName.Font.Style) };
            totalPrice = 0 ;

            FlowLayoutPanel TitleLayoutPanel = new FlowLayoutPanel();
            TitleLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            TitleLayoutPanel.WrapContents = false;
            TitleLayoutPanel.AutoSize = true;

            TitleLayoutPanel.Controls.Add(Image);
            TitleLayoutPanel.Controls.Add(Name);
            TitleLayoutPanel.Controls.Add(Price);
            TitleLayoutPanel.Controls.Add(Quatity);
            TitleLayoutPanel.Controls.Add(SubTotal);
            TitleLayoutPanel.Controls.Add(Add);

            MainPanel.Controls.Add(TitleLayoutPanel);
            for (int i = 0; i < Shoppingcart.Count; i++)
            {
                Label productName = new Label { Text = Shoppingcart[i].Product.ProductName, Font = new Font("Arial", 15, CName.Font.Style) };
                PictureBox productImage = new PictureBox { };
                //productImage.Load(product.ProductImageURL);
                Label productPrice = new Label { Text = "$" + Shoppingcart[i].Product.ProductPrice, Font = new Font("Arial", 15, CName.Font.Style) };
                Label quatity = new Label { Text = Shoppingcart[i].quatity.ToString(), Font = new Font("Arial", 15, CName.Font.Style) };
                float subTotal = (float)Convert.ToDouble(Shoppingcart[i].Product.ProductPrice) * (float)Convert.ToDouble(Shoppingcart[i].quatity);
                Label productSubTotalPrice = new Label { Text = "$" + subTotal.ToString(), Font = new Font("Arial", 15, CName.Font.Style) };
                Button removeButton = new Button { Text = "Remove", Font = new Font("Arial", 10, CName.Font.Style) };
                int x = i;

                removeButton.Click += (sender, e) => {
                    Shoppingcart.Remove(Shoppingcart[x]);
                    MainPanel.Controls.Clear();
                    loadProduct();
                };
                totalPrice = totalPrice + subTotal;

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanel.WrapContents = false;
                flowLayoutPanel.AutoSize = true;

                flowLayoutPanel.Controls.Add(productImage);
                flowLayoutPanel.Controls.Add(productName);
                flowLayoutPanel.Controls.Add(productPrice);
                flowLayoutPanel.Controls.Add(quatity);
                flowLayoutPanel.Controls.Add(productSubTotalPrice);
                flowLayoutPanel.Controls.Add(removeButton);
                MainPanel.Controls.Add(flowLayoutPanel);
            }
            TotalPrices.Text = "$" + totalPrice.ToString();
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            loadProduct();
            CName.Text = customer.CustomerName;
        }

        private void CheckoutB_Click(object sender, EventArgs e)
        {
            if (Shoppingcart.Count != 0)
            {
                Checkout checkout = new Checkout(username, totalPrice, this, Shoppingcart);
                Orders orders = new Orders();
                Order order = new Order(orders.getId(), Shoppingcart, username);
                order.save();
                checkout.Show();
                this.Hide();
            }else if(Shoppingcart.Count == 0)
            {
                MessageBox.Show($"No Product In Shopping Cart");
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            customerForm.Show();
            this.Close();
        }
    }
}
