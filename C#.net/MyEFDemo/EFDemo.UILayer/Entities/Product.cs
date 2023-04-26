using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.UILayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public virtual Category category { get; set; } //mark it virtual for lazy loading
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }

    [Table("Table_name")]
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        [MaxLength(500)]
        [Column("desc",TypeName ="varchar")]
        public string CategoryName { get; set; }
        [NotMapped]
        public double Profit { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
    //[Table("Supplier")] //TPT
    public class Supplier:Person
    {   
        public string GST { get; set; }
        public int Rating { get; set; }
        public virtual List<Product> Products { get; set;} = new List<Product>();
        public Address Address { get; set; }
    }
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //TPC
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string Location { set; get; }
    }
    //[Table("Customers")] //TPT
    public class Customer : Person
    {
        public string CustomerType { get; set; }
        public double Discount { get; set; }
    }
    [ComplexType] //Doesn't create a separate table and if present as property anywhere the columns will be added there
    public class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
    }
}
