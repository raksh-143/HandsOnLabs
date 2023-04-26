using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.BusinessLayer.Entities
{
    public class Employee:Person
    {
        public long EmpId { get; set; }
        public double Basic { get; set; }
        public int Experience { get; set; }
        public double GetSalary()
        {
            return Basic + SalaryCalculator.CalculateAllowance(Experience,Basic);
        }
    }
}
