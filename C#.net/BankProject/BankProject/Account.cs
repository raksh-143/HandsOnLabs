using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    interface IDepositable
    {
        bool Deposit(double amount);
    }
    internal abstract class Account : IDepositable
    {
        public int AccountNumber;
        public double Balance;
        public double InterestRate;
        public int MonthsHeld;
        public Customer Customer { get; set; }

        public double CalculateInterest()
        {
            if(this is Loan)
            {
                if (Customer is Individual)
                {
                    LoanIndividualInterestCalculator liic = new LoanIndividualInterestCalculator();
                    return liic.CalculateInterest(this);
                }
                else
                {
                    LoanCompanyInterestCalculator lcic = new LoanCompanyInterestCalculator();
                    return lcic.CalculateInterest(this);
                }
            }
            else if(this is Mortgage)
            {
                if(Customer is Individual)
                {
                    MortgageIndividualInterestCalculator miic = new MortgageIndividualInterestCalculator();
                    return miic.CalculateInterest(this);
                }
                else
                {
                    MortgageCompanyInterestCalculator mcic = new MortgageCompanyInterestCalculator();
                    return mcic.CalculateInterest(this);
                }
            }
            else
            {
                SavingsInterestCalculator sic = new SavingsInterestCalculator();
                return sic.CalculateInterest(this);
            }
        }
        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
            {
                return false;
            }
            Balance += amount;
            return true;
        }
    }


    interface IInterestCalculator
    {
        double CalculateInterest(Account anAccount);
    }


}
