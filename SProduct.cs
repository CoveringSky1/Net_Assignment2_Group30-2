using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class SProduct
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductImageURL { get; set; }

        public string ProductType { get; set; }

        public SProduct() { }
        public override string ToString()
        {
            return ProductID + "," + ProductName + "," + ProductDescription + "," + ProductPrice + "," + ProductStock + "," + ProductImageURL + "," + ProductType;
        }

    }


}
