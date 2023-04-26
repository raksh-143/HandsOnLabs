using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    internal class WardCostCalculator
    {
        public static double FindWardCost(double BasicCost,WardType WardType)
        {
            if(WardType == WardType.GeneralUnit)
            {
                return 1.1 * BasicCost;
            }
            else if(WardType == WardType.IntensiveCareUnit)
            {
                return 1.2 * BasicCost;
            }
            else if(WardType == WardType.PadiatricUnit)
            {
                return 1.25 * BasicCost;
            }
            else
            {
                return 1.4 * BasicCost;
            }
        }
    }
}
