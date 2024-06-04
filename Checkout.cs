using Assignment2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.WebRequestMethods;

namespace checkout
{
    public partial class Checkout : Form
    {
        string userID;
        float totalPrice;
        ShoppingCart cart;
        List<CShoppingCartItem> items;

        public Checkout()
        {
            InitializeComponent();
        }

        public Checkout(string username, float totalPrice, ShoppingCart cart, List<CShoppingCartItem> items)
        {
            InitializeComponent();
            this.userID = username;
            this.totalPrice = totalPrice;
            this.cart = cart;
            this.items = items;
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            string[] userFile = File.ReadAllLines("userDB.txt");
            totalP.Text = "$" + totalPrice.ToString();
            lb_txtTP.Text = totalP.Text;
            foreach (string line in userFile)
            {
                string[] userData = line.Split('-');
                if (userData[0] == userID)
                {
                    string[] userName = userData[2].Split(' ');
                    txtFN.Text = userName[0];
                    txtLN.Text = userName[1];
                    txtAddress.Text = userData[3];
                    txtPhone.Text = userData[5];
                    txtEmail.Text = userData[4];
                    break;
                }
            }
        }

        public bool testInput()
        {
            bool Isture = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    string txt_name = ((c as TextBox).Name);
                    Label lb = (Label)this.Controls.Find("lb_" + txt_name, true)[0];
                    if ((c as TextBox).Text == String.Empty)
                    { 
                        lb.Text = "please fill it in";
                        Isture = false;
                    }
                    else if ((c as TextBox).Text.Contains("-"))
                    {
                        lb.Text = "existencel symbol \"-\"";
                        Isture = false;
                    }
                    else
                    {
                        lb.Text = "*";
                    }
                }
            }
            return Isture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testInput() == true)
            {
                var Confirm = new Confirmation(txtLN.Text, txtEmail.Text,userID);
                MessageBox.Show("Your billing request has been sent \npressing the confirm button will take you to the completion page");
                foreach(CShoppingCartItem item in items)
                {
                    item.Product.decreaseStock(item.Product, Convert.ToInt32(item.Product.ProductStock)-item.quatity);
                }
                Confirm.Show();
                this.Hide();
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            cart.Show();
            this.Close();
        }
    }
}
