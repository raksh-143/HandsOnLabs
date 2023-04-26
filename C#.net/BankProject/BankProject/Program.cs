using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank MyBank = new Bank();
            Account account1 = new Loan();
            Account account2 = new Mortgage();
            Savings account3 = new Savings();
            MyBank.Accounts.Add(account1);
            MyBank.Accounts.Add(account2);
            MyBank.Accounts.Add(account3);
            account1.Balance = 10000;
            account1.InterestRate = 10;
            account1.MonthsHeld = 4;
            account2.Balance = 10000;
            account2.InterestRate = 10;
            account2.MonthsHeld = 4;
            account3.Balance = 10000;
            account3.InterestRate = 10;
            account3.MonthsHeld = 4;
            Customer cust1 = new Individual();
            Customer cust2 = new Company();
            account1.Customer = cust1;
            account2.Customer = cust2;
            account3.Customer = cust2;

            Console.WriteLine(account1.CalculateInterest());
            Console.WriteLine(account2.CalculateInterest());
            Console.WriteLine(account3.CalculateInterest());
            Console.WriteLine(account3.Deposit(-10));
            Console.WriteLine(account3.Balance);
            Console.WriteLine(account3.Deposit(10));
            Console.WriteLine(account3.Balance);
            Console.WriteLine(account3.Withdraw(-10));
            Console.WriteLine(account3.Balance);
            Console.WriteLine(account3.Withdraw(10));
            Console.WriteLine(account3.Balance);

            Console.ReadKey();

        }
    }
}
