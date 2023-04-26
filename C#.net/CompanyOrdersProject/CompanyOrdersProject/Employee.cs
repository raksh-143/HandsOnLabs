using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrdersProject
{
    class Employee:Person
    {
        public int EmpId;
        public double Basic;
        public double Experience;
        public double GetSalary()
        {
            return SalaryCalculator.CalculateSalary(Experience, Basic);
        }
    }
}
