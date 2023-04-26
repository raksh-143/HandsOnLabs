using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionDemo.DataLayer;

namespace TransactionDemo.UILayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransactionBetweenAccounts trans = new TransactionBetweenAccounts();
            try
            {
                bool res = trans.TransferFunds(111, 222, 1000);
                if (res)
                {
                    Console.WriteLine("Funds Transfered successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
