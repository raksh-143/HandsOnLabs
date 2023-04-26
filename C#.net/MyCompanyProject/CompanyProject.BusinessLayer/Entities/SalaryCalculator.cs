using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.BusinessLayer.Entities
{
    public class SalaryCalculator
    {
        private SalaryCalculator() { }
        public static double CalculateAllowance(int Experience,double Basic)
        {
            double allowancePercentage = 0.0;
            if(Experience <= 2)
            {
                allowancePercentage = 0.3;
            }
            else if(Experience <= 4)
            {
                allowancePercentage = 0.4;
            }
            else if(Experience <= 6)
            {
                allowancePercentage = 0.5;
            }
            else if(Experience > 6)
            {
                allowancePercentage = 0.65;
            }
            return allowancePercentage * Basic;
        }
    }
}
