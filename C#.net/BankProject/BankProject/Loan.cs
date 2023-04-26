using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    internal class Loan:Account
    {

    }
    class LoanIndividualInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            double balance = anAccount.Balance;
            double interest = anAccount.InterestRate;
            int monthsHeld = anAccount.MonthsHeld - 3;
            return balance * interest * monthsHeld / 100;
        }
    }
    class LoanCompanyInterestCalculator : IInterestCalculator
    {
        public double CalculateInterest(Account anAccount)
        {
            double balance = anAccount.Balance;
            double interest = anAccount.InterestRate;
            int monthsHeld = anAccount.MonthsHeld - 2;
            return balance * interest * monthsHeld / 100;
        }
    }
}
