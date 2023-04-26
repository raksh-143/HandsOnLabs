using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SellPhonesStore.Entities
{
    public class Customer
    {
        public long CustomerID { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PinCode { get; set; }
        public long MobileNo { get; set; }
        public List<CustomerOrder> Orders { get; set; }
    }
}
