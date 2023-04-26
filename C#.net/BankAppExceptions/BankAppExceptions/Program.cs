using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Account acc1 = new Account { Accno = 1, Name = "Priya", Balance = 0, isActive = true, Pin = 1234 };
                AccountManager accman = new AccountManager();
                accman.OpenAccount(acc1);
                accman.Deposit(acc1, 1000);
                Console.WriteLine(acc1.Balance);
                //Account acc2 = null;
                //accman.CloseAccount(acc2);
                acc1.Pin = 560085;
                accman.Withdraw(acc1, 100, 560085);
            }
            catch (AccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(OperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
