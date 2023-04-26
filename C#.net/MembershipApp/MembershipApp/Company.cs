using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class Company
    {
        public string CompanyName { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public Company(string Name,List<Customer> Customers)
        {
            if(Customers.Count >= 1)
            {
                this.CompanyName = Name;
                this.Customers = Customers;
            }
            else{
                throw new Exception("A company should have at least one customer!");
            }
            
        }
    }
}
