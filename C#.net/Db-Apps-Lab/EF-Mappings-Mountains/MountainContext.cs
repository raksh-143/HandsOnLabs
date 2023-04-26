using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings_Mountains
{
    public class MountainContext:DbContext
    {
        public MountainContext():base("name=MountainContext")
        {

        }
        public virtual DbSet<Country3> Countries { get; set; }
        public virtual DbSet<Mountain> Mountains { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
    }
}
