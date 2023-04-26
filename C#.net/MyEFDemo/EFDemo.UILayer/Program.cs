using EFDemo.UILayer.Data_Access;
using EFDemo.UILayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.UILayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Want to save products info to databasse
            //EF code first approach
            //Increase the price by 2000
            ProductsDbContext db = new ProductsDbContext();

            //Not efficient for bulk modification because hits db each time
            //var plist = db.Products.ToList();
            //foreach(var item in plist)
            //{
            //    item.Rate += 2000;
            //}
            //db.SaveChanges();

            string sqlUpdate = "update products set rate = rate + 1000";
            db.Database.ExecuteSqlCommand(sqlUpdate);
            Console.WriteLine("done");
            //Console.ReadKey();
        }
        public static void InsertCustomerOrSupplierTPC()
        {
            //TPC
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var c = new Customer { Name = "Customer1", CustomerType = "Gold", Discount = 12, Email = "customer1@gmail.com", Location = "Location1", Mobile = "9876543210" };
            db.People.Add(c);

            var s = new Supplier { Name = "Supplier1", GST = "237492734938", Rating = 8 };
            db.People.Add(s);

            db.SaveChanges();
        }
        public static void InsertCustomerOrSupplierTPT()
        {
            //Inserting customer and supplier after using tpt
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var c = new Customer { Name = "Customer1", CustomerType = "Gold", Discount = 12, Email = "customer1@gmail.com", Location = "Location1", Mobile = "9876543210" };
            db.People.Add(c);

            var s = new Supplier { Name = "Supplier1", GST = "237492734938", Rating = 8 };
            db.People.Add(s);

            db.SaveChanges();
        }
        public static void GetAllCustomersOrSuppliers()
        {
            //Get all customers or all suppliers
            ProductsDbContext db = new ProductsDbContext();
            var allCustomers = db.People.OfType<Customer>().ToList(); //Checks for Discriminator=="Customer" in the database
            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer.Name);
            }
        }
        public static void AddACustomerAndSupplier()
        {
            //Add a new customer and new supplier
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            var c = new Customer { Name = "Customer1", CustomerType = "Gold", Discount = 12, Email = "customer1@gmail.com", Location = "Location1", Mobile = "9876543210" };
            db.People.Add(c);

            var s = new Supplier { Name = "Supplier1", GST = "237492734938", Rating = 8 };
            db.People.Add(s);

            db.SaveChanges();
            //Automatically adds a discriminator which takes the value of the class name
        }
        public static void GetAllMobiles()
        {
            //Get all products belonging to mobile category
            ProductsDbContext db = new ProductsDbContext();
            var allMobiles = from c in db.Categories
                             where c.CategoryName == "Mobiles"
                             select c.Products;
            foreach (var mobile in allMobiles)
            {
                foreach (var thisMobile in mobile)
                {
                    Console.WriteLine(thisMobile.Name);
                }
            }
        }
        public static void DisplayAllProductsFromAllCategories()
        {
            //Display product name, rate, category name
            ProductsDbContext db = new ProductsDbContext();
            var products = from p in db.Products//.Include("category")
                           select p;
            foreach (Product item in products)
            {
                Console.WriteLine($"{item.Name}\t{item.Rate}\t{item.category.CategoryName}");
            }
        }
        public static void AddNewProductOldCat()
        {
            //Add new product with exisitng category
            ProductsDbContext db = new ProductsDbContext();
            var mobile = (from c in db.Categories
                          where c.CategoryName == "Mobiles"
                          select c).FirstOrDefault();
            var p = new Product { Name = "Galaxy M10", Rate = 9327, Brand = "Samsung", Country = "India", category = mobile };
            db.Products.Add(p);
            //db.Categories.Add(cat); //Not necessary root object will be added in the previous stmt
            db.SaveChanges();
        }
        public static void AddNewProductNewCat()
        {
            //Add new category with new product
            var cat = new Category { CategoryName = "Mobiles" };
            var p = new Product { Name = "IPhone X", Rate = 29834, Brand = "Apple", Country = "India", category = cat };

            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            //db.Categories.Add(cat); //Not necessary root object will be added in the previous stmt
            db.SaveChanges();
        }
        public static void ReadAndLog()
        {
            ProductsDbContext pb = new ProductsDbContext();
            pb.Database.Log = Console.WriteLine;
            var allProducts = from p in pb.Products select p;
            foreach (var product in allProducts)
            {
                Console.WriteLine($"{product.Name}\t{product.Rate}");
            }
        }
        public static void Save()
        {
            Product p = new Product { Name = "IPhone X", Description = "Expensive Phone", Rate = 75000 };
            ProductsDbContext ds = new ProductsDbContext();
            ds.Products.Add(p);
            ds.SaveChanges();
            Console.WriteLine("Done");
        }
        public static void Read()
        {
            ProductsDbContext ds = new ProductsDbContext();
            //Get all products -> Linq to entities
            var allProducts = from p in ds.Products select p;
            var simpleWay = ds.Products;
            //Display
            foreach (var product in allProducts)
            {
                Console.WriteLine($"{product.Name}\t{product.Rate}");
            }
        }
        public static void Delete()
        {
            ProductsDbContext ds = new ProductsDbContext();
            var productToDelete = (from p in ds.Products
                                   where p.Name == "IPhone X"
                                   select p).FirstOrDefault(); //Get the first product or if not product null
            var productsToDel = ds.Products.Find(2); //to get product with id 2
            if (productToDelete == null)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                ds.Products.Remove(productToDelete);
            }
            ds.SaveChanges(); //Must be called otherwise data won't be updated in db
        }
        public void Update()
        {
            ProductsDbContext ds = new ProductsDbContext();
            var productToUpdate = ds.Products.Find(2);
            productToUpdate.Rate += 2000;

            //The changes won't be reflected since change was made in different context
            //and being saved in different
            ProductsDbContext ds2 = new ProductsDbContext();
            ds.SaveChanges();
        }
    }
}
