using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LINQToXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static void NameCitySexOfFemaleEmp()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            where employee.Element("Sex").Value == "Female"
                            select new
                            {
                                Name = employee.Element("Name").Value,
                                City = employee.Element("Address").Element("City").Value,
                                Gender = employee.Element("Sex").Value
                            };
            foreach (var employee in Employees)
            {
                Console.WriteLine($"Name: {employee.Name}, City: {employee.City}, Gender: {employee.Gender}");
            }
        }
        static void CountOfEmpInCA()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = (from employee in document.Descendants("Employee")
                             where employee.Element("Address").Element("State").Value == "CA"
                             select employee).Count();
            Console.WriteLine($"Employees in CA: {Employees}");
        }
        static void Top2Emp()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = (from employee in document.Descendants("Employee")
                             select employee).Take(2);
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
        static void SortBasedOnZip()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            orderby employee.Element("Address").Element("Zip").Value
                            select employee;
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
        static void DisplayEmpFromAlta()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            where employee.Element("Address").Element("City").Value == "Alta"
                            select employee.Element("Name").Value;
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
        static void DisplayHomePhone()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            where employee.Element("Phone").Attribute("Type").Value == "Home"
                            select employee.Element("Phone").Value;
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
        static void DisplayFemaleEmpIDAndName()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            where employee.Element("Sex").Value == "Female"
                            select new { Id = employee.Element("EmpId").Value, Name = employee.Element("Name").Value };
            foreach (var employee in Employees)
            {
                Console.WriteLine($"{employee.Id}, {employee.Name}");
            }
        }
        static void DisplayEmpIDAndName()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            select new { Id = employee.Element("EmpId").Value, Name = employee.Element("Name").Value };
            foreach (var employee in Employees)
            {
                Console.WriteLine($"{employee.Id}, {employee.Name}");
            }
        }
        static void DisplayAllEmpName()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employee")
                            select employee.Element("Name").Value;
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
        static void DisplayFullXML()
        {
            XDocument document = XDocument.Load("EmpInfo.xml");
            var Employees = from employee in document.Descendants("Employees")
                            select employee;
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
