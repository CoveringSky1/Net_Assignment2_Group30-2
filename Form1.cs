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
    public partial class formLogin : Form
    {
        string[] userFile = File.ReadAllLines("userDB.txt");
        public formLogin()
        {
            InitializeComponent();
        }
        public enum userType
        {
            merchant = 0,
            customer = 1
        }
        public string lsTrue(string userNA, string userPW)
        {
            string[] userFile = File.ReadAllLines("userDB.txt");
            foreach (string line in userFile)
            {
                string[] userData = line.Split('-');
                if (userData[0] == userNA && userData[1] == userPW)
                {
                    if (userData[6] == "customer")
                    {
                        return "customer";
                    }
                    else if (userData[6] == "merchant")
                    {
                        return "merchant";
                    }
                    else { return "error"; }
                }
            }
            return "error";
        }
        private void btuLogin_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text;
            string userPassword = txtPassword.Text;
            Console.WriteLine("You name is : " + txtName.Text);
            Console.WriteLine("You Password is : " + txtPassword.Text);
            string userType = lsTrue(userName, userPassword);
            switch (userType)
            {
                case "customer":
                    txtUserType.Text = "Hello! You are logining as a customer";
                    var customer = new CustomerForm(userName);
                    customer.Show();
                    this.Hide();
                    break;
                case "merchant":
                    txtUserType.Text = "Hello! You are logining as a merchant";
                    var seller = new SellerForm();
                    seller.Show();
                    this.Hide();
                    break;
                default:
                    txtUserType.Text = "The user name or password is incorrect.";
                    break;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regFrom = new Form2();
            regFrom.ShowDialog();
        }
        public bool testEmptyInput(TextBox txtBox)
        {
            if (txtBox.Text == String.Empty)
            {
                return false;
            }
            return true;
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
