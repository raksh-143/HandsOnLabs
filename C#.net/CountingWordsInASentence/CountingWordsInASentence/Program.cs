using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingWordsInASentence
{
    internal class Program
    { 
        static void Main()
        {
            Product[] products = new Product[4];
            products[0] = new Product(200, "Dell", "15 inch Monitor", 3400.44);
            products[1] = new Product(120, "Dell", "Laptop", 45000.00);
            products[2] = new Product(150, "Microsoft", "Windows 7", 7000.50);
            products[3] = new Product(100, "Logitech", "Optical Mouse", 540.00);

            Array.Sort(products,new SortByPrice());
            foreach(Product product in products)
            {
                Console.WriteLine(product.ProductId);
            }
            Console.ReadKey();
        }
    }
    class SortByProductId : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.ProductId > y.ProductId) return 1;
            else if (x.ProductId < y.ProductId) return -1;
            else return 0;
        }
    }
    class SortByProductBrand : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.BrandName.CompareTo(y.BrandName) == 1)
            {
                return 1;
            }
            else if(x.BrandName.CompareTo(y.BrandName) == -1)
            {
                return -1;
            }
            else
            {
                SortByDesc sbd = new SortByDesc();
                return sbd.Compare(x, y);
            }
        }
    }
    class SortByDesc : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.Description.CompareTo(y.Description) == 1)
            {
                return 1;
            }
            else if (x.Description.CompareTo(y.Description) == -1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    class SortByPrice : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x.Price > y.Price) return 1;
            else if (x.Price < y.Price) return -1;
            else
            {
                SortByProductId sbpi = new SortByProductId();
                return sbpi.Compare(x, y);
            }
        }
    }
}
