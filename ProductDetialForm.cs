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
    public partial class ProductDetialForm : Form
    {
        public ProductDetialForm()
        {
            InitializeComponent();
        }

        public ProductDetialForm(CProduct product)
        {
            InitializeComponent();
            ImageProduct.Load(product.ProductImageURL);
            ProductName.Text = product.ProductName;
            ProductPrice.Text = product.ProductPrice;
            ProductStock.Text = product.ProductStock;
            descriptionP.Text = product.ProductDescription;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
