using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Mappings
{
    public class Country3
    {
        [Key]
        [StringLength(2,MinimumLength =2)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
