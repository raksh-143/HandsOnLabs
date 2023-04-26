using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    internal class Mortgage:Account
    {
    }
    class MortgageIndividualInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            double balance = anAccount.Balance;
            double interest = anAccount.InterestRate;
            int monthsHeld = anAccount.MonthsHeld - 6;
            return balance * interest * monthsHeld / 100;
        }
    }
    class MortgageCompanyInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            double balance = anAccount.Balance;
            double interest = anAccount.InterestRate;
            int monthsHeld = anAccount.MonthsHeld;
            if (monthsHeld < 12)
            {
                return balance * interest / 2 * monthsHeld / 100;
            }
            return (balance * interest / 2 * 12 / 100 + balance * interest * (monthsHeld - 12) / 100);
        }
    }
}
