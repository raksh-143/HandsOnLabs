using CrazyProductsCatalogService.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrazyProductsCatalogService.Models.Data
{
    public class CrazyProductsDbContext:DbContext
    {
        public CrazyProductsDbContext():base("DefaultConnection")
        {

        }
        public DbSet<CrazyProduct> CrazyProducts { get; set; }
    }
}