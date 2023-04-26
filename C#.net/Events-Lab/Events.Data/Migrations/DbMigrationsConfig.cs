
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Events.Data.Migrations
{
    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<Events.Data.ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed= true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if(!context.Users.Any())
            {
                var adminEmail = "admin@admin.com";
                var adminUserName = adminEmail;
                var adminFullName = "System Administrator";
                var adminPassword = adminEmail;
                string adminRole = "Administrator";
                ApplicationUser user = new ApplicationUser
                {
                    FullName = adminFullName,
                    Email = adminEmail,
                    UserName = adminUserName,
                    PasswordHash= adminPassword,
                };
                context.Users.Add(user);
            }
        }
    }
}
