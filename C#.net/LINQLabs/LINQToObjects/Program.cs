using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. List all products whose price in between 50K to 80K
            Console.WriteLine("1. List all products whose price in between 50K to 80K");
            var Products = from prod in ProductsDB.GetProducts()
                           where prod.Price >= 50000 && prod.Price <= 80000
                           select prod;

            foreach (var prod in Products)
            {
                Console.WriteLine(prod.Name);
            }
            Console.WriteLine();
            //2. Extract all products belongs to Laptops catagory
            Console.WriteLine("2. Extract all products belongs to Laptops catagory");
            Products = from prod in ProductsDB.GetProducts()
                             where prod.Catagory.Name == "Laptops"
                             select prod;

            foreach (var prod in Products)
            {
                Console.WriteLine(prod.Name);
            }
            Console.WriteLine();
            //3. Extract/Show Product Name and Catagory Name only
            Console.WriteLine("3. Extract/Show Product Name and Catagory Name only");
            Products = from prod in ProductsDB.GetProducts()
                       select prod;
            Console.WriteLine("Name\tCategory");
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Name}\t{prod.Catagory.Name}");
            }
            Console.WriteLine();
            //4. Show the costliest product name 
            Console.WriteLine("4. Show the costliest product name ");
            Products = (from prod in ProductsDB.GetProducts()
                       orderby prod.Price descending
                       select prod).Take(1);
            Console.WriteLine("Name\tPrice");
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Name}\t{prod.Price}");
            }
            Console.WriteLine();
            //5. Show the cheepest product name and its price
            Console.WriteLine("5. Show the cheepest product name and its price");
            Products = (from prod in ProductsDB.GetProducts()
                        orderby prod.Price
                        select prod).Take(1);
            Console.WriteLine("Name\tPrice");
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Name}\t{prod.Price}");
            }
            Console.WriteLine();
            //6. Show the 2nd and 3rd product details
            Console.WriteLine("6. Show the 2nd and 3rd product details");
            Products = (from prod in ProductsDB.GetProducts()
                                      orderby prod.Price
                                      select prod).Skip(1).Take(2);
            Console.WriteLine("Name\tPrice");
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Name}\t{prod.Price}");
            }
            Console.WriteLine();
            //7. List all products in assending order of their price
            Console.WriteLine("7. List all products in assending order of their price");
            Products = from prod in ProductsDB.GetProducts()
                        orderby prod.Price
                        select prod;
            Console.WriteLine("Name\tPrice");
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Name}\t{prod.Price}");
            }
            Console.WriteLine();
            //8. Count the no. of products belong to Tablets
            Console.WriteLine("8. Count the no. of products belong to Tablets");
            var products = (from prod in ProductsDB.GetProducts()
                            where prod.Catagory.Name == "Tablets"
                            select prod).Count();
            Console.WriteLine($"Total number of tablets: {products}");
            Console.WriteLine();
            //9. Show which catagory has costly product
            Console.WriteLine("9. Show which catagory has costly product");
            Products = (from prod in ProductsDB.GetProducts()
                        orderby prod.Price descending
                        select prod).Take(1);
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Catagory.Name}");
            }
            Console.WriteLine();
            //10. Show which catagory has less products
            Console.WriteLine("10. Show which catagory has less products");
            Products = (from prod in ProductsDB.GetProducts()
                        orderby prod.Catagory.Products.Count
                        select prod).Take(1);
            foreach (var prod in Products)
            {
                Console.WriteLine($"{prod.Catagory.Name}");
            }
            Console.WriteLine();
            //11.Extract the Product Details based on the catagory and show as below
            //Laptops
            //Dell XPS 13
            //HP 430
            //Mobiles
            //IPhone 6
            //Galaxy S6
            //Tablets
            //IPad Pro
            Console.WriteLine("11. Extract the Product Details based on the catagory");
            var Categories = (from prod in ProductsDB.GetProducts()
                              select prod.Catagory.Name).Distinct();

            foreach (var category in Categories)
            {
                Console.WriteLine($"{category}");
                Products = from prod in ProductsDB.GetProducts()
                           where prod.Catagory.Name == category
                                  select prod;
                foreach(var Product in Products)
                {
                    Console.WriteLine($"{Product.Name}");
                }
            }
            Console.WriteLine();
            //12.Extract the Product count based on the catagory and show as below
            //Laptops: 2
            //Mobiles: 2
            //Tablets: 1
            Console.WriteLine("12.Extract the Product count based on the catagory and show as below");
            Categories = (from prod in ProductsDB.GetProducts()
                              select prod.Catagory.Name).Distinct();

            foreach (var category in Categories)
            {
                var count = (from prod in ProductsDB.GetProducts()
                             where prod.Catagory.Name == category
                             select prod).Count();
                Console.WriteLine($"{category}: {count}");
            }
            Console.WriteLine();
        }

    }
    class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
            Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
            Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

            Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
            Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
            Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
            Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
            Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

            cat1.Products.Add(p1);
            cat1.Products.Add(p2);
            cat2.Products.Add(p3);
            cat2.Products.Add(p4);
            cat3.Products.Add(p5);

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}
