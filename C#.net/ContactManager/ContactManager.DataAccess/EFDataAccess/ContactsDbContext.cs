using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ContactManager.DataAccess.EFDataAccess
{
    internal partial class ContactsDbContext : DbContext //To safeguard the modifications made to db
    {
        public ContactsDbContext()
            : base("name=ContactsDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Location)
                .IsFixedLength();
        }
    }
}
