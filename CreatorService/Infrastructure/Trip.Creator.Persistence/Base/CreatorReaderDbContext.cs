using Microsoft.EntityFrameworkCore;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistence.Builder;

namespace Trip.Creator.Persistence.Base
{
    public class CreatorReaderDbContext : DbContext
    {
        public DbSet<Creation> Creation { get; set; }

        public DbSet<CreationResource> CreationResource { get; set; }

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
