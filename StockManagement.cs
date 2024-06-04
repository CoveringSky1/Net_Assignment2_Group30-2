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
    public partial class StockManagement : Form
    {
        Products products = new Products();
        public StockManagement()
        {
            InitializeComponent();
            update();
            this.BackColor = Color.LightSkyBlue;

        }

        public void update()
        {
            Label nameLbl1 = new Label();
            nameLbl1.Text = "Product";
            Label priceLbl1 = new Label();
            priceLbl1.Text = $"Price";
            Label stockLbl1 = new Label();
            stockLbl1.Text = $"Stock";
            Label onSaleLbl1 = new Label();
            onSaleLbl1.Text = $"Type";
            Label operation = new Label();
            operation.Text = "Operation";
            productsPanel.Controls.Add(nameLbl1, 0, 0);
            productsPanel.Controls.Add(priceLbl1, 1, 0);
            productsPanel.Controls.Add(stockLbl1, 2, 0);
            productsPanel.Controls.Add(onSaleLbl1, 3, 0);
            productsPanel.Controls.Add(operation, 4, 0);

            int row = 1;

            foreach (SProduct product in products)
            {
                Label nameLbl = new Label();
                nameLbl.Text = product.ProductName;
                Label priceLbl = new Label();
                priceLbl.Text = $"{product.ProductPrice}";
                Label stockLbl = new Label();
                stockLbl.Text = $"{product.ProductStock}";
                Label typeLbl = new Label();
                typeLbl.Text = $"{product.ProductType}";

                TableLayoutPanel panel = new TableLayoutPanel();
                panel.Height = 50;
                Button updateBtn = new Button();
                updateBtn.Height = 30;
                updateBtn.BackColor = Color.Green;
                updateBtn.Text = "Update";
                updateBtn.Click += (sender, e) =>
                {
                    new ProductDetail(this, product.ProductID, product.ProductName,
                        product.ProductPrice, product.ProductStock, product.ProductType, product.ProductDescription, "update", product.ProductImageURL).Show();
                };


                Button delBtn = new Button();
                delBtn.Click += (sender, e) =>
                {
                    DialogResult result = MessageBox.Show("Are u sure to delete this product",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        products.delProduct(product);
                        this.Hide();
                        new StockManagement().Show();
                    }
                };


                delBtn.Height = 30;
                delBtn.BackColor = Color.Red;

                delBtn.Text = "Delete";
                panel.Controls.Add(updateBtn, 0, 0);
                panel.Controls.Add(delBtn, 1, 0);
                productsPanel.Controls.Add(nameLbl, 0, row);
                productsPanel.Controls.Add(priceLbl, 1, row);
                productsPanel.Controls.Add(stockLbl, 2, row);
                productsPanel.Controls.Add(typeLbl, 3, row);
                productsPanel.Controls.Add(panel, 4, row);
                row++;
            }
            foreach (Control control in productsPanel.Controls)
            {
                control.Dock = DockStyle.Fill;
                control.Anchor = AnchorStyles.None;
            }
        }

        private void productsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ProductDetail detail = new ProductDetail(this, products.gernerateId(), "", 0, 0, "", "", "add", "");
            detail.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            new SellerForm().Show();
            this.Close();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
