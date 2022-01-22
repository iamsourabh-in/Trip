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
            modelBuilder.Entity<CreationResource>().ToTable("CreationResource");
            modelBuilder.Entity<CreationResource>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Modified).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Modified).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Modified).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }
    }
}
