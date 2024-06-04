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
    partial class OrderDetail : Form
    {
        Order order;
        public OrderDetail(Order order)
        {
            InitializeComponent();
            this.BackColor = Color.LightSkyBlue;
            this.order = order;
            itemsTable.RowStyles[0].SizeType = SizeType.Absolute;
            itemsTable.RowStyles[0].Height = 30;
            update();
        }
        public void update()
        {
            nameLbl.Text = order.Username;
            emailLbl.Text = order.Email;
            Label pnameLbl = new Label();
            pnameLbl.Text = "Product Name";
            Label priceLbl = new Label();
            priceLbl.Text = "Price";
            Label numLbl = new Label();
            numLbl.Text = "Quantity";
            Label totalLbl = new Label();
            totalLbl.Text = "SubTotal";
            itemsTable.Controls.Add(pnameLbl, 0, 0);
            itemsTable.Controls.Add(priceLbl, 1, 0);
            itemsTable.Controls.Add(numLbl, 2, 0);
            itemsTable.Controls.Add(totalLbl, 3, 0);
            int row = 1;
            double total = 0;
            foreach (SShoppingCartItem item in order.Items)
            {

                Label productNameLbl = new Label();
                productNameLbl.Text = item.Product.ProductName;
                Label productPriceLbl = new Label();
                productPriceLbl.Text = item.Product.ProductPrice + "";
                Label quantityLbl = new Label();
                quantityLbl.Text = item.quatity + "";
                Label subTotal = new Label();
                subTotal.Text = Math.Round(item.Product.ProductPrice * item.quatity, 2) + "";
                total += Math.Round(item.Product.ProductPrice * item.quatity, 2);
                
                itemsTable.Controls.Add(productNameLbl, 0, row);
                itemsTable.Controls.Add(productPriceLbl, 1, row);
                itemsTable.Controls.Add(quantityLbl, 2, row);
                itemsTable.Controls.Add(subTotal, 3, row);
                ++this.itemsTable.RowCount;
                
                row++;
            }
            Label totalLabel = new Label();
            totalLabel.Text = "Total:" + Math.Round(total, 2);
            itemsTable.Controls.Add(totalLabel, 3, row);
     
        }
   

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            new OrderManagement().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Email(order).Show();
        }

        private void itemsTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Close();
        }

        private void nameLbl_Click(object sender, EventArgs e)
        {

        }

        private void emailLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
