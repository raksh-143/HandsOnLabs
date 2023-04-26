using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public class PhoneRepository : IPhoneRepository
    {
        SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
        public List<CustomerOrder> GetAllCustomerOrders()
        {
            var customerOrders = db.CustomerOrders.ToList();
            return customerOrders;
        }

        public List<CustomerOrder> GetCustomerOrders(long customerId)
        {
            var customerOrders = db.CustomerOrders.Where(c=>c.Customer.CustomerID==customerId).ToList();
            return customerOrders;
        }

        public long SaveCustomer(Customer customer)
        {
            var newCustomer = db.Customers.Add(customer);
            db.SaveChanges();
            return newCustomer.CustomerID;
        }

        public long SaveOrder(CustomerOrder order)
        {
            var newOrder = db.CustomerOrders.Add(order);
            db.SaveChanges();
            return newOrder.CustomerOrderID;
        }

        public long SaveOrderedPhone(OrderedPhone orderPhone, long orderId)
        {
            var newOrderedPhone = db.OrderedPhones.Add(orderPhone);
            db.CustomerOrders.Find(orderId).OrderedPhones.Add(orderPhone);
            db.SaveChanges();
            return newOrderedPhone.OrderedPhoneId;
        }

        public long SavePhone(Phone phone)
        {
            var newPhone = db.Phones.Add(phone);
            db.SaveChanges();
            return newPhone.PhoneId;
        }
    }
}
