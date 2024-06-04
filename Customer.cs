using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Customer
    {
        public string CustomerUsername { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddres { get; set; }
        public string CustomerEmail { get; set; }
        public Customer() { }

        public Customer(string username)
        {
            List<Customer> customers = new List<Customer>();
            customers = File.ReadAllLines("userDB.txt")
                      .Select(line => line.Split('-'))
                      .Select(array => new Customer { CustomerUsername = array[0], CustomerName = array[2], CustomerPhone = array[5], CustomerAddres = array[3], CustomerEmail = array[4] })
                      .ToList();
            Customer customer = SearchSaler(customers, username);
            CustomerUsername = customer.CustomerUsername;
            CustomerName = customer.CustomerName;
            CustomerPhone = customer.CustomerPhone;
            CustomerAddres = customer.CustomerAddres;
            CustomerEmail = customer.CustomerEmail;
        }

        public static Customer SearchSaler(List<Customer> users, string username)
        {
            return users.FirstOrDefault(user => user.CustomerUsername == username);
        }
    }
}
