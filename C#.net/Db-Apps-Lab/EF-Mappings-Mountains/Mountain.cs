using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings_Mountains
{
    public class Mountain
    {
        public virtual ICollection<Peak> Peaks { get; set; }
        public virtual ICollection<Country3> Countries { get; set; }
        public Mountain()
        {
            Countries = new HashSet<Country3>();
            Peaks= new HashSet<Peak>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
