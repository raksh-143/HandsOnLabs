using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class SaleItem
    {
        public double Rate { get; }
        public string Date { get; }
        public SaleItem() { }
        public SaleItem(string desc,double rate)
        {
            Rate = rate;
            Date = desc;
        }
    }
}
