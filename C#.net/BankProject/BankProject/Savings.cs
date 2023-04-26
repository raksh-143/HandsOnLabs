using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    interface IWithdrawable
    {
        bool Withdraw(double amount);
    }
    internal class Savings : Account, IWithdrawable
    {
        public bool Withdraw(double amount)
        {
            if (Balance > 0 && amount > 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public override bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }
    }
    class SavingsInterestCalculator : IInterestCalculator 
    {
        public double CalculateInterest(Account anAccount)
        {
            double balance = anAccount.Balance;
            double interest = anAccount.InterestRate;
            int monthsHeld = anAccount.MonthsHeld;
            if(balance > 0 && balance < 1000)
            {
                return 0;
            }
            return balance * interest * monthsHeld / 100;
        }
    }
}
