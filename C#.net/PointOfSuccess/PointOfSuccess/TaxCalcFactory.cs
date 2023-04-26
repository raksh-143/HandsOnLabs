using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSuccess
{
    internal class TaxCalcFactory
    {
        public StdTaxCalc instance
        {
            get
            {
                StdTaxCalc stdTaxCalc = StdTaxCalc.instance;
                return stdTaxCalc;
            }
        }
        public void create(int vendorType) { }
    }
}
