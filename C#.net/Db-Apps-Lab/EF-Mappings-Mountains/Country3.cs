using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings_Mountains
{
    public class Country3
    {
        public virtual ICollection<Mountain> Mountains { get; set; }
        public Country3()
        {
            Mountains = new HashSet<Mountain>();
        }
        [Key]
        [StringLength(2,MinimumLength =2)]
        [Column(TypeName ="char")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
