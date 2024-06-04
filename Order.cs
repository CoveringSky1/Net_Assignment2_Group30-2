using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Order
    {
        private int id;
        private List<SShoppingCartItem> items;
        private string username;
        private string email;

        public string Username
        {
            get { return username; }
        }
        public string Email
        {
            get { return email; }
        }
        public List<SShoppingCartItem> Items
        {
            get { return items; }
        }
        public Order(int id, List<CShoppingCartItem> items, string username)
        {
            this.id = id;
            this.items = ItemAdapter(items);
            this.username = username;
            this.email = getEmailByUsername(username);
        }

        public List<SShoppingCartItem> ItemAdapter(List<CShoppingCartItem> items)
        {
            List<SShoppingCartItem> cartItems = new List<SShoppingCartItem>();
            foreach (CShoppingCartItem item in items)
            {
                SProduct product = new SProduct 
                {
                    ProductID = int.Parse(item.Product.ProductID),
                    ProductName = item.Product.ProductName,
                    ProductDescription = item.Product.ProductDescription,
                    ProductPrice = double.Parse(item.Product.ProductPrice),
                    ProductStock = int.Parse(item.Product.ProductStock),
                    ProductImageURL = item.Product.ProductImageURL,
                    ProductType =item.Product.ProductType
                };
                cartItems.Add(new SShoppingCartItem
                {
                    Product = product,
                    quatity = item.quatity
                });
            }
            return cartItems;
        }
        public string getEmailByUsername(string username)
        {
            string[] userFile = File.ReadAllLines("userDB.txt");
            foreach (string line in userFile)
            {
                string[] userData = line.Split('-');
                if (userData[0] == username)
                {
                    return userData[4];
                }
            }
            return null;
        }
        public int Id
        {
            get { return id; }
        }
        public Order(string fileContent)
        {

            Products products = new Products();
            string[] content = fileContent.Split('\n');

            this.id = int.Parse(content[0].Split(':')[1]);
            this.username = content[1].Split(':')[1];

            this.email = content[2].Split(':')[1].Replace("\n", "").Replace("\r", "");
    
            this.items = new List<SShoppingCartItem>();
            for (int i = 3; i < content.Length - 1; i++)
            {
                int productId = int.Parse(content[i].Split(' ')[0]);
                SProduct p = products.GetProduct(productId);
                if (p != null)
                {
                    int quantity = int.Parse(content[i].Split(' ')[1]);
                    items.Add(new SShoppingCartItem() { Product = p, quatity = quantity });
                }
            }
        }
        public void save()
        {

            File.WriteAllText($"orders/{id}.txt", ToString());
        }

        public double getTotal()
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.Product.ProductPrice * item.quatity;
            }
            return  Math.Round(total, 2);
        }

        public override string ToString()
        {
            string str = "Id:" + id + "\n";
            str += $"username: {username}" + "\n";
            str += $"email: {email}" + "\n";
            foreach (SShoppingCartItem item in items)
            {
                str += item.Product.ProductID + " " + item.quatity + "\n";
            }
            str.Remove(str.Length - 1);
            return str;
        }

    }
}
