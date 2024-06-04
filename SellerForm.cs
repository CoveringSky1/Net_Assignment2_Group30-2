using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
            this.BackColor = Color.LightSkyBlue;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OrdersMgntBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new OrderManagement().Show();
            
        }

        private void stockMgntBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockManagement stockManagement = new StockManagement();
            stockManagement.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Close();
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {

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