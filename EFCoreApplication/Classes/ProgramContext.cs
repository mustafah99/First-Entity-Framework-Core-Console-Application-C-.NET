using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApplication.Classes
{
    public class ProgramContext : DbContext
    {
        public DbSet<Categories> Category { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet <ChildCategories> ChildCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=EFCoreProductManagerDB;Trusted_Connection=True;");
        }
    }
}
