using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Domain.Entities;

namespace Trip.Creator.Persistence.Base
{
    public class CreatorWriterDbContext : DbContext
    {
        public DbSet<Creation> Creation { get; set; }

        public DbSet<CreationResource> CreationResource { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public CreatorWriterDbContext(DbContextOptions<CreatorWriterDbContext> options) : base(options)
        {

        }
    }


    public class CreatorWriterDbContextFactory : IDesignTimeDbContextFactory<CreatorWriterDbContext>
    {
        public CreatorWriterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CreatorWriterDbContext>();
            optionsBuilder.UseSqlite("Data Source=creator.db;");

            return new CreatorWriterDbContext(optionsBuilder.Options);
        }
    }
}
