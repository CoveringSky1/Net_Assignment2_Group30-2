using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment2
{
    class Products:IEnumerable
    {
        private List<SProduct> products = new List<SProduct>();
        private int id = 1;
        public Products()
        {
            
            readtxtProduct();
            id = products.Count == 0 ? 0 : products[products.Count-1].ProductID+1;

        }

        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public void readtxtProduct()
        {
            products = new List<SProduct>();
            products = File.ReadAllLines("Products.txt")
                        .Select(line => line.Split(','))
                        .Select(array => new SProduct
                        {
                            ProductID = int.Parse(array[0]),
                            ProductName = array[1],
                            ProductDescription = array[2],
                            ProductPrice = double.Parse(array[3]),
                            ProductStock = int.Parse(array[4]),
                            ProductImageURL = array[5],
                            ProductType = array[6]
                        })
                        .ToList();
       
        }
        public Boolean isExist(string name)
        {
            var result = products.Where(p => p.ProductName == name).ToList();
            return result.Any();
        }
        public SProduct GetProduct(int id)
        {
            var result = products.Where(p => p.ProductID == id).ToList();
            return result.FirstOrDefault();
           
        }
        public void addProduct(SProduct product)
        {
            products.Add(product);
            File.AppendAllText("Products.txt", product.ToString());

        }
        public void delProduct(SProduct product)
        {
            products.Remove(product);
            File.WriteAllText("Products.txt", ToString());

        }
        public void update(int productID, string name, double price, int stock, string type,string description,string url)
        {
            foreach(SProduct product in products)
            {
                if (product.ProductID == productID)
                {
                    product.ProductName = name;
                    product.ProductDescription = description;
                    product.ProductPrice = price;
                    product.ProductStock = stock;
                    product.ProductImageURL = url;
                    product.ProductType = type;
                }
            }
            File.WriteAllText("Products.txt", ToString());
        }
        public int gernerateId()
        {
            return id++;
        }
        public override string ToString()
        {
            string str = "";
            foreach(SProduct product in products)
            {
                str+= product.ToString()+"\n";
            }
            str.Remove(str.Length-1);
            return str;
        }
    }
}
