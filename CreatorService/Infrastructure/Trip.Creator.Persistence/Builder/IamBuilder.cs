using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Domain.Entities;

namespace Trip.Creator.Persistence.Builder
{
    public static class IamBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creation>().ToTable("Creation");
            modelBuilder.Entity<Creation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Modified).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<Creation>().ToTable("CreationResource");
            modelBuilder.Entity<CreationResource>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

        }
    }
}
