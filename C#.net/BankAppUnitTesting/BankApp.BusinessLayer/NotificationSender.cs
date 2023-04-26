using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BusinessLayer
{
    public class NotificationSender
    {
        public virtual void EmailNotificationForWithdrawl(double amount)
        {
            Console.WriteLine($"Rs.{amount} was debited from your account");
        }
        public virtual void EmailNotificationForDeposition(double amount)
        {
            Console.WriteLine($"Rs.{amount} was credited to your account");
        }
        public virtual void EmailNotificationForTransfer(double amount)
        {
            Console.WriteLine($"Rs.{amount} was transfered from your account");
        }
    }
}
