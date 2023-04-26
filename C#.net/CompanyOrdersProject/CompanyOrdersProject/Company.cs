using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrdersProject
{
    class Company
    {
        public string Name { get; set; }
        public DateTime IncorporatedDt { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Branch> Branches { get; set; } = new List<Branch>();
        public Branch RegisteredBranch { get; set; }
        public Branch CorporateBranch { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Employee GetEmployee(int EmpId)
        {
            foreach(Employee employee in Employees)
            {
                if(employee.EmpId == EmpId)
                {
                    return employee;
                }
            }
            Console.WriteLine("Employee with specified ID not found. Creating an employee with ID " + EmpId+"...");
            Employee employee1 = new Employee { EmpId = EmpId };
            return employee1;
        }
        public double GetTotalSalaryPayout()
        {
            double TotalSalaryPayout = 0.0;
            foreach(Employee employee in Employees)
            {
                TotalSalaryPayout += employee.GetSalary();
            }
            return TotalSalaryPayout;
        }
        public int GetTotalCustomers()
        {
            return Customers.Count;
        }
        public int GetTotalEmployees()
        {
            return Employees.Count;
        }
    }
}
