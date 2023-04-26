using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class RegCustomer:Customer
    {
        public string dReg { get; set; }
        public Membership memberShip { get; set; }
        public RegCustomer(string custId,string custName,string email) : base(custId, custName, email){}
        public string GetTypeOfMembership()
        {
            return memberShip.typeOfMembership;
        }
        public double GetDiscount()
        {
            return memberShip.discount;
        }
        public double GetFees()
        {
            return memberShip.fees;
        }
    }
}
