using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public virtual double GetTotalWorth()
        {
            double TotalWorth = 0.0;
            foreach (Order order in Orders)
            {
                TotalWorth += order.GetTotalWorth();
            }
            return TotalWorth;
        }
    }
}
