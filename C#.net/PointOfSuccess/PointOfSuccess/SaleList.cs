using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class SaleList
    {
        public string dtSale { get; set; }
        public string custName { get; set; }
        public LinkedList<Sale> sales { get; set; } = new LinkedList<Sale>();

        public SaleList(string date, string name) { 
            this.dtSale = date;
            this.custName = name;
        }
        public void Add(Sale sale)
        {
            sales.AddLast(sale);
        }
        public double GenerateBill()
        {
            double totalSales = 0.0;
            foreach(Sale sale in sales)
            {
                totalSales += sale.GenerateBill();
            }
            return totalSales;
        }
    }
}
