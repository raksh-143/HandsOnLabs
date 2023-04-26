using CompanyProject.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.BusinessLayer.Entities
{
    public class Company
    {
        public string Name { get; set; }
        public DateTime IncorporationDate { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Branch> OtherBranches { get; set; } = new List<Branch>();
        public Branch RegisteredBranch { get; set; }
        public Branch CorporateBranch { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public int GetTotalCustomers()
        {
            return Customers.Count;
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
        public Employee GetEmployeeByEmpId(long id)
        {
            foreach(Employee employee in Employees)
            {
                if(employee.EmpId == id)
                {
                    return employee;
                }
            }
            throw new EmployeeDoesNotExistException("The Employee with this ID was not found");
        }
        public List<Employee> GetExperiencedEmployees(int yearsOfExperience)
        {
            List<Employee> ExperiencedEmployees = new List<Employee>();
            foreach(Employee employee in Employees)
            {
                if (employee.Experience > yearsOfExperience)
                {
                    ExperiencedEmployees.Add(employee);
                }
            }
            return ExperiencedEmployees;
        }
        public Dictionary<int,List<Employee>> GetEmployeesGroupedByAge()
        {
            Dictionary<int, List<Employee>> GroupEmployeeByAge = new Dictionary<int, List<Employee>>();
            foreach(Employee employee in Employees)
            {
                if (GroupEmployeeByAge.ContainsKey(employee.Age))
                {
                    GroupEmployeeByAge[employee.Age].Add(employee);
                }
                else
                {
                    GroupEmployeeByAge[employee.Age] = new List<Employee> { employee};
                }
            }
            return GroupEmployeeByAge;
        }

    }
}
