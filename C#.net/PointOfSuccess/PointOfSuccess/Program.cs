using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaleItem item1 = new SaleItem("Monitor",7000);
            SaleItem item2 = new SaleItem("Hard disk",5500);
            Sale sale1 = new Sale(item1, 2, 5);
            Sale sale2 = new Sale(item2, 5, 10);
            SaleList list = new SaleList("16-03-2006", "Jennifer");
            list.Add(sale1);
            list.Add(sale2);
            BillingSystem sys = new BillingSystem();
            sys.GenerateBill(list);
            Console.ReadKey();
        }
    }
}
