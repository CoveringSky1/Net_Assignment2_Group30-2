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
    public partial class OrderManagement : Form
    {
        public OrderManagement()
        {
            InitializeComponent();
            update();
            this.BackColor = Color.LightSkyBlue;

        }
        public void update()
        {
            Label IdLbl1 = new Label();
            IdLbl1.Text = "Order ID";
            Label userLbl1 = new Label();
            userLbl1.Text = $"Username";
            Label emailLbl1 = new Label();
            emailLbl1.Text = $"Email";

            Label totalLbl1 = new Label();
            totalLbl1.Text = $"Total";

            Label operation = new Label();
            operation.Text = "Operation";
            orderTable.Controls.Add(IdLbl1, 0, 0);
            orderTable.Controls.Add(userLbl1, 1, 0);
            orderTable.Controls.Add(emailLbl1, 2, 0);
            orderTable.Controls.Add(totalLbl1, 3, 0);
            orderTable.Controls.Add(operation, 4, 0);
            Orders orders = new Orders();
            int row = 1;
            foreach (Order order in orders)
            {
                Label idLabel = new Label();
                idLabel.Text = order.Id + "";
                Label usernameLbl = new Label();
                usernameLbl.Text = $"{order.Username}";
                Label emailLbl = new Label();
                emailLbl.Text = $"{order.Email}";
                emailLbl.Dock = DockStyle.Fill;
                Label totalLbl = new Label();
                totalLbl.Text = $"{order.getTotal()}";

                TableLayoutPanel panel = new TableLayoutPanel();
                panel.Height = 50;
                Button updateBtn = new Button();
                updateBtn.Height = 30;
                updateBtn.BackColor = Color.Green;
                updateBtn.Text = "View Detail";
                updateBtn.Click += (sender, e) =>
                {
                    this.Close();
                    new OrderDetail(order).Show();

                };


                Button delBtn = new Button();
                delBtn.Click += (sender, e) =>
                {
                    DialogResult result = MessageBox.Show("Are u sure to delete this order",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        orders.removeOrder(order);
                        this.Close();
                        new OrderManagement().Show();



                    }
                };


                delBtn.Height = 30;
                delBtn.BackColor = Color.Red;
                delBtn.Text = "Delete";
                panel.Controls.Add(updateBtn, 0, 0);
                panel.Controls.Add(delBtn, 1, 0);
                orderTable.Controls.Add(idLabel, 0, row);
                orderTable.Controls.Add(usernameLbl, 1, row);
                orderTable.Controls.Add(emailLbl, 2, row);
                orderTable.Controls.Add(totalLbl, 3, row);
                orderTable.Controls.Add(panel, 4, row);

                row++;
            }
            foreach (Control control in orderTable.Controls)
            {
                control.Dock = DockStyle.Fill;
                control.Anchor = AnchorStyles.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SellerForm().Show();
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new formLogin().Show();
            this.Close();
        }

        private void OrderManagement_Load(object sender, EventArgs e)
        {

        }

        private void orderTable_Paint(object sender, PaintEventArgs e)
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
