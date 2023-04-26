using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings
{
    public class Rivers2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Outflow {
            get; set;
        }
        public int drainageArea { get; set; }
        public int averageDischarge{get; set;}
    }
}
