using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();
        public Customer customer { get; set; }
        public double GetTotalWorth()
        {
            double TotalWorth = 0.0;
            foreach (OrderedItem orderedItem in OrderedItems)
            {
                TotalWorth += orderedItem.GetWorth();
            }
            return TotalWorth;
        }
    }
}
