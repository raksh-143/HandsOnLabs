using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrdersProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();

            Employee employee = new Employee { EmpId = 1, Name = "Alpha", Age = 25, Basic = 10000, Experience = 2,Address="Marathahalli" };
            company.Employees.Add(employee);

            Customer customer = new Customer { CustomerId = 1, Name = "Beta", Age = 29, Email = "beta@gmail.com", Address = "Whitefield" };
            company.Customers.Add(customer);

            Console.WriteLine(company.GetEmployee(1).Name);
            //Console.WriteLine(company.GetEmployee(2).EmpId);
            Console.WriteLine(company.GetTotalCustomers());
            Console.WriteLine(company.GetTotalEmployees());
            Console.WriteLine(company.GetTotalSalaryPayout());

            Console.ReadKey();
        }
    }
}
