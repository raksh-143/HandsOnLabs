using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.Entities
{
    public class CustomerOrder
    {
        public long CustomerOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public float OrderTotal { get; set; }
        public List<OrderedPhone> OrderedPhones { get; set; }
    }
}
