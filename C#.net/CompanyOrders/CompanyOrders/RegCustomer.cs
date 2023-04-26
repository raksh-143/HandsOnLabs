using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    class RegCustomer : Customer
    {
        public int SplDiscount { get; set; }
        public override double GetTotalWorth()
        {
            double TotalWorth = base.GetTotalWorth();
            TotalWorth = TotalWorth * (100 - SplDiscount)/100;
            return TotalWorth;
        }
    }
}
