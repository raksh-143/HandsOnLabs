using angular_app_tutorial.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace angular_tutorial_backend.Data
{
    public class TaskManagerDbContext:DbContext
    {
        public TaskManagerDbContext():base("name=DefaultConnection")
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
