using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form2 : Form
    {
        string accountType = null;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            List<string> userTypes = new List<string>()
            {
                "customer",
                "merchant",
                "==UserType=="
            };
            cmbAccT.DataSource = userTypes;
            cmbAccT.SelectedItem = userTypes[2];
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (testInput() ==true) 
            {
                string accountData = $"\n{txtUserNA.Text}-{txtUserPW.Text}-{txtFN.Text} {txtLN.Text}-{txtStreet.Text},{txtCity.Text},{txtState.Text}-{txtEmail.Text}-{txtPhone.Text}-{accountType}";
                Console.WriteLine(accountData);
                using (StreamWriter writer = File.AppendText("userDB.txt"))
                {
                    writer.Write(accountData);
                }
                MessageBox.Show("Account registration successful!");
                this.Close();
            };
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
                else if(c is ComboBox)
                {
                    if (cmbAccT.SelectedItem.ToString() == "==UserType==")
                    {
                        MessageBox.Show("You haven't select the type of Account you want to register, please select it");
                        Isture = false;
                        break;
                    }
                    accountType = cmbAccT.SelectedItem.ToString();
                }
            }
            return Isture;
        }
    }
}
