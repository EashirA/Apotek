using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apotek.Models;

namespace Apotek.DbContext
{
    using System.Data.Entity;

    public class ApotekDbContext : DbContext
    {
        public ApotekDbContext()
            : base("name=ApotekDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Category> CategoriesTable { get; set; }
        public virtual DbSet<Product> ProductsTable { get; set; }
    }
}