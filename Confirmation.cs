using Assignment2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace checkout
{
    public partial class Confirmation : Form
    {
        private string UName;
        private string UEmail;
        private string username;
        public Confirmation(string userName, string userEmail, string username)
        {
            InitializeComponent();
            UName = userName;
            UEmail = userEmail;
            this.username = username;
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            txtDescription.Text = ("Thank you for your purchase " + UName + "\n The invoice has been sent to the following email address:\n" + UEmail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm(username);
            frm.Show();
            this.Close();
        }
    }
}
