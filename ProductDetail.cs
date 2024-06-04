using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class ProductDetail : Form
    {
        StockManagement parent;
        int productID = 0;
        string operationType;
        Products products = new Products();
        public ProductDetail(StockManagement management, int id,
            string name, double price, int stock, string type, string desc, string operationType, string url)
        {
            InitializeComponent();
            productID = id;
            Dictionary<string, int> foodDictionary = new Dictionary<string, int>
             {
                {"Fruit", 0},
                {"Seafood", 1},
                {"Meat", 2},
                {"",0 }
             };

            typeBox.SelectedIndex = foodDictionary[type];
            nameTB.Text = name;
            priceTB.Text = price + "";
            stockTB.Text = stock + "";
            descriptionTB.Text = desc;
            parent = management;
            this.operationType = operationType;
            URLBox.Text = url;


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                string name = nameTB.Text;
                double price = Double.Parse(priceTB.Text);
                int stock = int.Parse(stockTB.Text);
                int selectedIndex = typeBox.SelectedIndex;
                string type = typeBox.Text;
                string description = descriptionTB.Text;
                string url = URLBox.Text;
                if (name.Length == 0)
                {
                    MessageBox.Show("Name shoud not be empty", "Empty alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (price <= 0)
                {
                    MessageBox.Show("Price should > 0", "Price incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (stock < 0)
                {
                    MessageBox.Show("Stock should >= 0", "Stock incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (description.Length == 0)
                {
                    MessageBox.Show("Description cannot be empty", "Empty alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (url.Length == 0)
                {
                    MessageBox.Show("ImageURL cannot be empty", "Empty alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                String msg = "";
                if (operationType == "add")
                {
                    if (products.isExist(name))
                    {
                        MessageBox.Show("Product name already exist", "Depulicate incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SProduct p = new SProduct
                    {
                        ProductID = productID,
                        ProductName = name,
                        ProductDescription =descriptionTB.Text,
                        ProductPrice = price,
                        ProductStock = stock,
                        ProductImageURL = url,
                        ProductType = type
                    };
                    products.addProduct(p);
                    
                    msg = "Add product success!";
                }
                else if (operationType == "update")
                {
                    products.update(productID, name, price, stock, type, description, url);
                    msg = "Update product success!";
                }


                DialogResult result = MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                    parent.Hide();
                    new StockManagement().Show();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Price and stock should be numerical", "Format incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void teamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Close();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newTextForm = new Form();
            Label label = new Label();
            label.Text = "As Australia's largest retailer, we rely on our teams across our stores, distribution centers and support offices to provide our customers with exceptional service, products and prices.\n\nOur people are at the heart of our business and we work together to ensure our company is a great place to work.\n\nAddress: 1 Woolworths Way, Bella Vista, NSW 2153\nContact number: 1300 908 631";
            label.Dock = DockStyle.Fill;
            newTextForm.Controls.Add(label);


            newTextForm.Text = "About Us";
            newTextForm.Size = new Size(400, 300);
            newTextForm.StartPosition = FormStartPosition.CenterScreen;
            newTextForm.ShowDialog();
        }
    }
}
