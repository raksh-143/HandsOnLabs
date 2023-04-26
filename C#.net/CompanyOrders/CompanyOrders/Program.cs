using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Company
            Company company = new Company();

            //Create Items for Company
            Item item1 = new Item { Desc="Pen",Rate=10};
            Item item2 = new Item { Desc = "Pencil", Rate = 5 };
            Item item3 = new Item { Desc = "Notebook", Rate = 50 };

            //Add items to company
            company.Items.Add(item1);
            company.Items.Add(item2);
            company.Items.Add(item3);

            //Create Customers
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();

            //Add customers to company
            company.Customers.Add(customer1);
            company.Customers.Add(customer2);

            //select items and qty of items
            OrderedItem orderedItem1 = new OrderedItem { Item = item1, qty = 3 };
            OrderedItem orderedItem2 = new OrderedItem { Item = item2, qty = 2 };
            OrderedItem orderedItem3 = new OrderedItem { Item = item3, qty = 4 };

            //Add ordered item to the order
            Order order = new Order();
            order.OrderedItems.Add(orderedItem1);
            order.OrderedItems.Add(orderedItem2);
            order.OrderedItems.Add(orderedItem3);

            //add order to customer's account
            customer1.Orders.Add(order);

            //Find total worth of all orders
            Console.WriteLine(company.GetTotalWorthOfOrdersPlaced());

            //Add ordered item to the order
            Order order1 = new Order();
            order1.OrderedItems.Add(orderedItem1);
            order1.OrderedItems.Add(orderedItem3);

            //add order to customer's account
            customer2.Orders.Add(order1);

            //Find total worth of all orders
            Console.WriteLine(company.GetTotalWorthOfOrdersPlaced());

            //A registered customer
            RegCustomer regcustomer = new RegCustomer();
            company.Customers.Add(regcustomer);
            Order order2 = new Order();
            order2.OrderedItems.Add(orderedItem2);
            regcustomer.Orders.Add(order2);
            regcustomer.SplDiscount = 10;

            //Find total worth of all orders
            Console.WriteLine(company.GetTotalWorthOfOrdersPlaced());

            Console.ReadKey();
        }
    }
}
