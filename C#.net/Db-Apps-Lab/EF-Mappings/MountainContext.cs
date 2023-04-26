using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings
{
    public class MountainContext:DbContext
    {
        public MountainContext():base("name=Geography")
        {

        }
        public virtual DbSet<Country> Countries { get; set; }
    }
}
