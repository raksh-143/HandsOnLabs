using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookCatalogApplication
{
    public partial class MyDbModel : DbContext
    {
        public MyDbModel()
            : base("name=MyDbModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<IssueBook> IssueBooks { get; set; }
        public virtual DbSet<ReturnBook> ReturnBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.BookName)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<IssueBook>()
                .Property(e => e.MembershipName)
                .IsFixedLength();
        }
    }
}
