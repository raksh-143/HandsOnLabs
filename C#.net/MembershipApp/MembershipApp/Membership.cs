using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class Membership
    {
        public string typeOfMembership { get; set; }
        public double discount { get; set; }
        public double fees { get; set; }
        public Membership(string type, double discount, double fees)
        {
            this.typeOfMembership = type;
            this.discount = discount;
            this.fees = fees;
        }
    }
}
