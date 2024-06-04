using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class CShoppingCartItem
    {
        public CProduct Product { get; set; }
        public int quatity { get; set; }
        public CShoppingCartItem() { }

        public CShoppingCartItem(CProduct product, int quatity)
        {
            this.Product = product;
            this.quatity = quatity;
        }


    }
}
