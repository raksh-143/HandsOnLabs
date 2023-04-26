using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingWordsInASentence
{
    internal class Product
    {
        public int ProductId;
        public string BrandName;
        public string Description;
        public double Price;
        public Product(int id,string name,string desc, double price)
        {
            ProductId= id;
            BrandName= name;
            Description= desc;
            Price= price;
        }
    }
}
