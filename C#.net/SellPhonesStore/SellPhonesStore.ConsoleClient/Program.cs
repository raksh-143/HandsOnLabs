using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellPhonesStore.DataAccess;
using SellPhonesStore.Entities;

namespace SellPhonesStore.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneRepository phoneRepository = new PhoneRepository();
            //Add Phones
            Phone phone = new Phone { BrandName = "Samsung", InStock = 100, ManufacturingDate = DateTime.Parse("09-03-2023 22:49:00"), PhoneDescription = "Phone", Price = 100000 };
            phoneRepository.SavePhone(phone);
            //Add Customers
            Customer customer = new Customer { CustomerName = "Rakshitha", City = "Bangalore", EmailID = "rakshitha@gmail.com", MobileNo = 9876543210, PinCode = "560037", StreetName = "Avenue Road" };
            Customer customer2 = new Customer { CustomerName = "Rakshitha B A", City = "Bangalore", EmailID = "rakshitha@gmail.com", MobileNo = 9876543210, PinCode = "560037", StreetName = "Avenue Road" };
            long customerID = phoneRepository.SaveCustomer(customer);
            phoneRepository.SaveCustomer(customer2);
            //Order Phones
            OrderedPhone orderedphone = new OrderedPhone { OrderPhone = phone, Quantity = 10};
            CustomerOrder customerOrder = new CustomerOrder { Customer=customer, OrderDate=DateTime.Now, OrderTotal=1000000, OrderedPhones= new List<OrderedPhone> {} };
            CustomerOrder customerOrder2 = new CustomerOrder { Customer=customer2, OrderDate=DateTime.Now, OrderTotal=1000000, OrderedPhones= new List<OrderedPhone> {} };
            long orderId = phoneRepository.SaveOrder(customerOrder);
            long orderId2 = phoneRepository.SaveOrder(customerOrder2);
            phoneRepository.SaveOrderedPhone(orderedphone,orderId);
            phoneRepository.SaveOrderedPhone(orderedphone,orderId2);
            //Print orders
            var customerOrders = phoneRepository.GetCustomerOrders(customerID);
            foreach(CustomerOrder co in customerOrders)
            {
                Console.WriteLine(co.OrderTotal);
            }
            var allCustomerOrders = phoneRepository.GetAllCustomerOrders();
            foreach (CustomerOrder co in allCustomerOrders)
            {
                Console.WriteLine(co.OrderTotal);
            }
        }
    }
}
