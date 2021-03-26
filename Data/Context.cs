using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class Context : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AssetTracker;Integrated Security=True;");
        }
    }
}
