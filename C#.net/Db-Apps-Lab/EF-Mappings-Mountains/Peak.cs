using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings_Mountains
{
    public class Peak
    {
        public virtual Mountain Mountain { get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Elevation { get; set; }
    }
}
