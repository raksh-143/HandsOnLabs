using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class StdTaxCalc
    {
        private StdTaxCalc() { }
        private static StdTaxCalc stdTaxCalc = new StdTaxCalc();
        public static StdTaxCalc instance
        {
            get { return stdTaxCalc; }
        }
        public double GetFedTax()
        {
            return 0.15;
        }
        public double GetISTax()
        {
            return 10;
        }
    }
}
