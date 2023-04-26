using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class Sale
    {
        public int Qty { get; }
        public double Discount { get; }
        public SaleItem Item { get; }
        public Sale() { }
        public Sale(SaleItem item, int qty, double discount)
        {
            this.Item = item;
            this.Qty = qty;
            this.Discount = discount;
        }
        public double GenerateBill()
        { 
            return Qty * Item.Rate * (100 - Discount)/100;
        }
    }
}
