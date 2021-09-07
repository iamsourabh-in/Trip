using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistence.Builder;

namespace Trip.Creator.Persistence.Base
{
    public class CreatorReaderDbContext : DbContext
    {
        public DbSet<Creation> Users { get; set; }

        public CreatorReaderDbContext(DbContextOptions<CreatorReaderDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            IamBuilder.Build(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
