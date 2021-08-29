using Microsoft.EntityFrameworkCore;
using Trip.Profile.Domain.Entities;

namespace Trip.Profile.Persistance.Builder
{
    public class IamBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
