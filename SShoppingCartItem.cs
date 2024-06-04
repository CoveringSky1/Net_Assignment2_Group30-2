using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class SShoppingCartItem
    {
        public SProduct Product { get; set; }
        public int quatity { get; set; }
        public SShoppingCartItem() { }

        public SShoppingCartItem(SProduct product, int quatity)
        {
            this.Product = product;
            this.quatity = quatity;
        }


    }
}
