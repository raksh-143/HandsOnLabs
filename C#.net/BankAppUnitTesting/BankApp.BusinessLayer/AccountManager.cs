using BankApp.BusinessLayer;
using BankApp.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAppExceptions
{
    public class AccountManager
    {
        IDataStorage Ids;
        NotificationSender NS;
        public AccountManager(IDataStorage MyRepo, NotificationSender nS)
        {
            Ids = MyRepo;
            NS = nS;
        }
        public List<Account> Accounts { get; set; } = new List<Account>();
        public void OpenAccount(Account account)
        {
            if (Accounts.Contains(account) && account.ClosingDate!=null)
            {
                throw new AccountException("Account already closed");
            }
            else if (Accounts.Contains(account) && account.ClosingDate == null)
            {
                throw new AccountException("Account already present");
            }
            Accounts.Add(account);
            account.OpeningDate = Convert.ToString(DateTime.Now);
            account.isActive = true;
        }
        public void CloseAccount(Account account)
        {
            if (!Accounts.Contains(account))
            {
                throw new AccountException("Account not present");
            }
            else if(account.ClosingDate != null)
            {
                throw new AccountException("Account already closed");
            }
            else if (account.Balance > 0)
            {
                throw new AccountException("Cannot close account because balance is more than 0");
            }
            account.ClosingDate = Convert.ToString(DateTime.Now);
            account.isActive = false;
        }
        public void Withdraw(Account account,int Amount,int Upin)
        {
            if(!Accounts.Contains(account))
            {
                throw new AccountException("Account not found");

            }
            else if (account.ClosingDate != null)
            {
                throw new AccountException("Account is closed");
            }
            if (Amount < 0)
            {
                throw new OperationException("Amount cannot be less than 0");
            }
            else if (Amount > account.Balance)
            {
                throw new OperationException("Amount greater than balance");
            }
            if (account.Pin != Upin)
            {
                throw new OperationException("Incorrect PIN entered");
            }
            account.Balance -= Amount;
            NS.EmailNotificationForWithdrawl(Amount);
        }
        public void Deposit(Account account, int Amount)
        {
            if (!Accounts.Contains(account))
            {
                throw new AccountException("Account not found");

            }
            else if (account.ClosingDate != null)
            {
                throw new AccountException("Account is closed");
            }
            if (Amount < 0)
            {
                throw new OperationException("Amount cannot be less than 0");
            }
            account.Balance += Amount;
            NS.EmailNotificationForDeposition(Amount);
        }
        public void Transfer(Account from, int Amount,Account To)
        {
            if(from.TransactionsToday == 3)
            {
                throw new MoreThan3TransactionsTodayException("This account has already made 3 transfers today. Try tomorrow");
            }
            if (!Accounts.Contains(from))
            {
                throw new AccountException("Tranferring Account not found");

            }
            else if (!Accounts.Contains(To))
            {
                throw new AccountException("Account to be transfered to is not found");

            }
            else if (from.ClosingDate != null)
            {
                throw new AccountException("Tranferring Account is closed");
            }
            else if (To.ClosingDate != null)
            {
                throw new AccountException("Account to be transfered to is closed");
            }
            if (Amount < 0)
            {
                throw new OperationException("Amount cannot be less than 0");
            }
            from.Balance -= Amount;
            To.Balance += Amount;
            from.TransactionsToday += 1;
            NS.EmailNotificationForTransfer(Amount);
            Ids.Save($"Rs. {Amount} transfered from {from.Name} to {To.Name}");
        }
    }
}
