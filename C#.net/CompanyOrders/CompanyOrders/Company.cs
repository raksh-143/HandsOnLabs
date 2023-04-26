using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    class Company
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public double GetTotalWorthOfOrdersPlaced()
        {
            double TotalWorthOfOrdersPlaced = 0.0;
            foreach(Customer customer in Customers)
            {
                double worthOfOrderPlaced = customer.GetTotalWorth();
                TotalWorthOfOrdersPlaced += worthOfOrderPlaced;
            }
            return TotalWorthOfOrdersPlaced;
        }
    }
}
