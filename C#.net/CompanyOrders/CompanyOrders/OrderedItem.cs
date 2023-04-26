using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    class OrderedItem
    {
        public int qty { get; set; }
        public Item Item { get; set; }

        public double GetWorth()
        {
            return Item.Rate * qty;
        }
    }
}
