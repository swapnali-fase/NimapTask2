using NimapTask2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NimapTask2
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}