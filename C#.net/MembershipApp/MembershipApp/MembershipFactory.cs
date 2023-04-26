using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MembershipApp
{
    internal class MembershipFactory
    {

        private static MembershipFactory membershipFactory = new MembershipFactory();
        public static MembershipFactory instance{
            get
            {
                return membershipFactory;
            }
        }
        
        private MembershipFactory() {
            
        }
        public Dictionary<string, Membership> pool { get; set; } = new Dictionary<string, Membership>();
        public Membership CreateMembership(string type,double fees, double discount)
        {
            Membership membership = new Membership(type, discount, fees);
            pool.Add(type,membership);
            return membership;
        }
        public Membership CreateMembership(string type)
        {
            Membership membership = new Membership(type,0,0);
            pool.Add(type,membership);
            return membership;
        }
    }
}
