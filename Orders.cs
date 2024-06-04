using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Orders : IEnumerable
    {

        private List<Order> orders;
        public Orders()
        {
            orders = new List<Order>();
            foreach (string path in Directory.GetFiles("./orders/"))
            {
                string content = File.ReadAllText(path);
                orders.Add(new Order(content));
            }
        }

        public IEnumerator GetEnumerator()
        {
            return orders.GetEnumerator();
        }

        public int getId()
        {
            if (orders.Count == 0) return 1;
            return orders[orders.Count - 1].Id + 1;
        }

        public void removeOrder(Order order)
        {
            orders.Remove(order);
            File.Delete($"orders/{order.Id}.txt");
        }
       
    }
}
