using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PLTProgram
{
    /*Write a pseudocode to accept name, empId, basic, special allowances, percentage of
    bonus and monthly tax saving investments.The gross monthly salary is basic + special
    allowances. Compute the annual salary. The gross annual salary also includes the bonus. 
    Compute the annual net salary, by deducting taxes as suggested.
    Income upto 1 lac – exempted
    Income from 1 to 1.5 lac – 20% 
    Income from 1.5 lac onwards – 30% 
    However if there is any tax saving investment, then there is further exemption of upto 1 
    lac annually. This would mean that by having tax saving investments of about 1 lac, an
    income of 2 lacs is non-taxable.Display the annual gross, annual net and tax payable.*/
    internal class SalaryCalculation
    {
        static string name;
        static int empid;
        static double basic, special, bonus, taxSavingInvestment;
        static double grossMonthly,annual,grossAnnual,netSal,taxPayable;
        static void CalculateGrossMonthlySalary()
        {
            grossMonthly = basic + special;
        }
        static void CalculateAnnualSalary()
        {
            annual = grossMonthly * 12;
        }
        static void CalculateGrossAnnualSalary()
        {
            grossAnnual = annual + bonus;
        }
        static void CaluculateNetSalaryAndTaxPayable()
        {
            double grossAnnualForTax = grossAnnual;
            taxPayable = 0.0;
            netSal = grossAnnualForTax;
            if(taxSavingInvestment > 0 && taxSavingInvestment<=100000)
            {
                grossAnnualForTax = grossAnnual - taxSavingInvestment;
            }
            else
            {
                grossAnnualForTax = grossAnnual - 100000;
            }
            if(grossAnnualForTax > 100000 && grossAnnualForTax < 150000)
            {
                netSal = grossAnnualForTax + grossAnnualForTax * 0.2;
                taxPayable = grossAnnualForTax * 0.2;
            }
            else if(grossAnnualForTax >= 150000)
            {
                netSal = grossAnnualForTax + grossAnnualForTax * 0.3;
                taxPayable = grossAnnualForTax * 0.3;
            }
        }
        static void DisplayResults() {
            Console.WriteLine("Gross Annual Salary = " + grossAnnual);
            Console.WriteLine("Net Annual Salary = " + netSal);
            Console.WriteLine("Tax Payable = " + taxPayable);
        }
        static void Main()
        {
            //Accept data from the user
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Employee ID: ");
            empid = int.Parse(Console.ReadLine());
            Console.Write("Enter Basic Salary: ");
            basic = double.Parse(Console.ReadLine());
            Console.Write("Enter Special Allowances: ");
            special = double.Parse(Console.ReadLine());
            Console.Write("Enter Bonus Percentage: ");
            bonus = double.Parse(Console.ReadLine());
            Console.Write("Enter Tax Saving Investment Amount: ");
            taxSavingInvestment= double.Parse(Console.ReadLine());
            //Calculate gross monthly salary
            CalculateGrossMonthlySalary();
            //Calculate annual salary
            CalculateAnnualSalary();
            //Calculate gross annual salary
            CalculateGrossAnnualSalary();
            //Calculate net salary and tax payable
            CaluculateNetSalaryAndTaxPayable();
            //Display the result
            DisplayResults();
            Console.ReadKey();
        }
    }
}
