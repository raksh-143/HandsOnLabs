using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppExceptions
{
    public class Account
    {
        //Secure the fields; Only AccountManager should be able to modify
        public int Accno { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }
        public bool isActive { get; set; }
        public string OpeningDate { get; set; }
        public string ClosingDate { get; set; }
    }
}
