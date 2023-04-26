using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class BillingSystem
    {
        public StdTaxCalc stdTaxCalc { get; set; }
        public BillingSystem() {
            TaxCalcFactory taxCalcFactory = new TaxCalcFactory();
            stdTaxCalc = taxCalcFactory.instance;
        }
        public void GenerateBill(SaleList saleList)
        {
            double totalBill = saleList.GenerateBill();
            Console.WriteLine($"Total Bill Generated = {totalBill}");
            double istax = stdTaxCalc.GetISTax();
            double fedtax = stdTaxCalc.GetFedTax();
            totalBill *= (100 + istax) / 100;
            totalBill *= (100 + fedtax) / 100;
            Console.WriteLine($"Inter-State Tax = {istax}%");
            Console.WriteLine($"Federal State Tax = {fedtax}%");
            Console.WriteLine($"Total Bill Generated after addition of taxes = {totalBill}");
        }
    }
}
    