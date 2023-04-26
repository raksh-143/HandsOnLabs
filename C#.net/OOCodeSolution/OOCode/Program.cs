using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode
{
    internal class Program
    {
        //Creates relationship HAS-A; Changes state of class and size of object of Program class
        //Customer customer = new Customer();
        static void Main(string[] args)
        {
            //Creates relationship USES
            Customer customer = new Customer(); //Consumer of the class
            customer.Id = 10;
            customer.Name = "Test";
            customer.Age = 0;
            Console.WriteLine($"Id = {customer.Id}; Name = {customer.Name}; Age = {customer.Age}");

            //Object Initialization Syntax
            Employee emp = new Employee { EmpID = 1 };
            Employee emp1 = new Employee { EmpID = 1, EmpName = "test" };
            Employee emp2 = new Employee { EmpID = 1, Salary = 10000};
            Employee emp3 = new Employee { Salary = 1000000 };
            Employee emp4 = new Employee
            {
                EmpID = 1,
                EmpName = "test",
                Salary = 10000,
                Address = new Address
                {
                    Area = "Brookfield"
                }
            };

            //Employee e1 = new Employee(1,"Test",50000);
            //e1.EmpID = 1;
            //e1.EmpName = "Test";
            //e1.Salary = 50000;
            //Employee e2 = new Employee(2); //Too many combinations of constructors required

            Address addr = new Address { Area = "Brookfield" };
            customer.Address = addr;
            Console.ReadKey();
        }
    }
    class Employee
    {
        ////Constructor Chaining
        //public Employee(int id,string name,int salary):this(id,name){ //Use properties not fields
        //    //EmpID = id;
        //    //EmpName = name;
        //    Salary = salary;
        //}
        //public Employee(int id, string name) : this(id)
        //{
        //    EmpName = name;
        //}
        //public Employee(int id)
        //{
        //    EmpID = id;
        //}
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        int salary;
        public int Salary { 
            get { return salary; }
            set
            {
                if(value < 10000)
                    salary = 10000;
                salary = value;
            }
        }
        //Creating an entity class -> only state no behavior
        //Every class has 2 users -> authors and consumers
        //Class customer is for usage by consumers (Program class)
        public Address Address { get; set; }
    }
        class Customer //Author
    {
        /*
        -> Never make fields of class public; private fields and public methods
        To enable the use of private fields for other classes
        1. Make the field public -> Not safe; accessible by all
        2. Create get and set methods
        3. Properties -> Easier for both authors and consumers
         */
        int id; //field
        string name; //field
        int age; //field
        //Properties -> Convenience for consumer and Control for author
        //Readonly property -> no set block
        //Writeonly property -> no get block (not commonly used)
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;

        }
        public int Age //age is the backing property for Age
        {
            get
            {
                return age;
            }
            set
            {
                if(age<18 || age > 60)
                {
                    value = 18;
                }
                age = value;
            }
        }
        public Address Address { get; set; }
    }
    class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}
