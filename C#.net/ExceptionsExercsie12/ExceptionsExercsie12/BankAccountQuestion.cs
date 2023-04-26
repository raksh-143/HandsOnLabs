using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercsie12
{
    internal class SavingsAccount
    {
        private int accountNumber;
        private double balance;
        public SavingsAccount(int accountNumber, double balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new OverdrawnException("You cannot withdraw amount greater than your balance",balance);
            }
            balance -= amount;
        }
    }
    class BankAccountQuestion
    {
        static void Main()
        {
            SavingsAccount account = new SavingsAccount(12345, 200);
            try
            {
                account.Withdraw(500);
            }
            catch (OverdrawnException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Your current balance is {ex.Balance}");
            }
        }
    }
    class OverdrawnException : ApplicationException
    {
        public double Balance;
        public OverdrawnException(string msg="",double balance=0.0):base(msg)
        {
            Balance = balance;
        }
    }
}
