using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public class CProduct
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string ProductStock { get; set; }
        public string ProductImageURL { get; set; }

        public string ProductType { get; set; }

        public CProduct() { }

        public List<CProduct> readtxtProduct()
        {
            List<CProduct> products = new List<CProduct>();
            products = File.ReadAllLines("Products.txt")
                      .Select(line => line.Split(','))
                      .Select(array => new CProduct{ ProductID = array[0], ProductName = array[1], ProductDescription = array[2], ProductPrice = array[3], ProductStock = array[4], ProductImageURL = array[5], ProductType = array[6] })
                      .ToList();
            return products;
        }

        public List<CProduct> readtxtProductByType(string type)
        {
            List<CProduct> products = readtxtProduct();
            List<CProduct> productsBytype = new List<CProduct>();
            foreach (CProduct product in products)
            {
                if(product.ProductType == type)
                {
                    productsBytype.Add(product);
                }
            }
            return productsBytype;
        }

        public List<CProduct> readtxtProductByName(string name)
        {
            List<CProduct> products = readtxtProduct();
            List<CProduct> productsByname = new List<CProduct>();
            foreach (CProduct product in products)
            {
                if (product.ProductName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    productsByname.Add(product);
                }
            }
            return productsByname;
        }

        public void decreaseStock(CProduct product, int newquatity)
        {
            List<CProduct> cProducts = readtxtProduct();
            List<String> list = new List<String>();
            foreach(CProduct product1 in cProducts)
            {
                if(product1.ProductID == product.ProductID)
                {
                    string newdata = product1.ProductID + "," + product1.ProductName + "," + product1.ProductDescription + "," + product1.ProductPrice + "," + newquatity.ToString() + "," + product1.ProductImageURL + "," + product1.ProductType;
                    list.Add(newdata);
                }
                else
                {
                    string newdata = product1.ProductID + "," + product1.ProductName + "," + product1.ProductDescription + "," + product1.ProductPrice + "," + product1.ProductStock + "," + product1.ProductImageURL + "," + product1.ProductType;
                    //001, Apple, This is a Apple,1.10,200,sdasd,Fruit
                    list.Add(newdata);
                }
            }
            File.WriteAllLines("Products.txt", list);
        }
    }
}
