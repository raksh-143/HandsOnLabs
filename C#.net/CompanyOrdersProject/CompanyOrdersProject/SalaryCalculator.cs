using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrdersProject
{
    class SalaryCalculator
    {
        public static double CalculateSalary(double Experience,double Basic)
        {
            double allowancePercentage = 0;
            if(Experience <= 2)
            {
                allowancePercentage = 0.3;
            }
            else if(Experience <= 4) {
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
            else
            {
                Console.WriteLine("UNDEFINED EXPERIENCE");
            }
            return Basic + allowancePercentage * Basic;
        }
    }
}
