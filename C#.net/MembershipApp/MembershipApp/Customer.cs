using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class Customer
    {
        public string CustId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public Customer(string CustId, string CustomerName, string Customeremail)
        {
            this.CustId = CustId;
            this.CustomerName = CustomerName;
            this.CustomerEmail = CustomerEmail;
        }
    }
}
