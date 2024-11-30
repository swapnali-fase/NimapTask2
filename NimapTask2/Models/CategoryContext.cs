using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NimapTask2.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("name=CategoryContext") // Match your connection string
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}