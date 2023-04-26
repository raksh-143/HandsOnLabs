using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a company with a customer
            Customer customer = new Customer("C1", "Priya", "priya@gmail.com");
            List<Customer> customerList = new List<Customer>();
            customerList.Add(customer);
            Company company = new Company("Rakshitha's Company", customerList);

            MembershipFactory membershipFactory = MembershipFactory.instance;
            Membership membership1 = membershipFactory.CreateMembership("A grade membership", 10000, 50000);
            Membership membership2 = membershipFactory.CreateMembership("B grade membership");

            RegCustomer customer2 = new RegCustomer("C2", "Riya", "riya@gmail.com");
            company.Customers.Add(customer2);
            customer2.memberShip = membership2;
            customer2.dReg = "2023-02-18";

            Console.WriteLine($"{customer2.CustId} {customer2.CustomerName} {customer2.CustomerEmail} {customer2.dReg} {customer2.GetTypeOfMembership()} {customer2.GetFees()} {customer2.GetDiscount()}");
            Console.ReadKey();
        }
    }
}
