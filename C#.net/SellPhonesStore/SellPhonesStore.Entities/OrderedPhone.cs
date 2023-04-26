using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.Entities
{
    public class OrderedPhone
    {
        public long OrderedPhoneId { get; set; }
        public Phone OrderPhone { get; set; }
        [Range(1,int.MaxValue)]
        public float Quantity { get; set; }
    }
}
