using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public class SellPhonesStoreDbContext:DbContext
    {
        public SellPhonesStoreDbContext():base("name=default")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<OrderedPhone> OrderedPhones { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
