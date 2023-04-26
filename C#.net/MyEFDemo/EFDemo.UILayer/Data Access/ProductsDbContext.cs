using EFDemo.UILayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.UILayer.Data_Access
{
    public class ProductsDbContext:DbContext
    {
        //configure db
        public ProductsDbContext():base("name=default")
        {

        }
        //configure tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //If we don't add the following line we cannot individually work with the suppliers class
        //We can reach suppliers only via Product
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }

        //TPC -> Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("Customers");
            });
            modelBuilder.Entity<Supplier>().Map(s =>
            {
                s.MapInheritedProperties();
                s.ToTable("Supplier");
            });

            //for stored procedure
            modelBuilder.Entity<Customer>().MapToStoredProcedures();
            
            //Stored procedures are created only for insert, update and delete because
            //select may vary in conditions
        }
    }
    
}
