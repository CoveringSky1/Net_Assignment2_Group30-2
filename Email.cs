using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    partial class Email : Form
    {
        Order order;
        public Email(Order order)
        {
            InitializeComponent();
            this.BackColor = Color.LightSkyBlue;
            this.order = order;
            emailLbl.Text = order.Email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string subject = subjectTB.Text;
            string message = msgTB.Text;
            if (subject.Length == 0)
            {
                MessageBox.Show("Subject Can not be empty", "Empty alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (message.Length == 0)
            {
                MessageBox.Show("Message cannot be empty", "Empty alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Sending, please wait", "Email Sending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EmailService service = new EmailService();
                
                string result = service.sendEmail(subject, message, order.Email);
                MessageBox.Show(result, "Email result", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new OrderDetail(order).Show();
        }

        private void emailLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
