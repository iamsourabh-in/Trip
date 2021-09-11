using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trip.Profile.Domain.Entities;
using Trip.Profile.Persistance.Builder;

namespace Trip.Profile.Persistance.Base
{
    public class ProfileWriterDbContext : DbContext
    {

        public ProfileWriterDbContext(DbContextOptions<ProfileWriterDbContext> options) : base(options)
        {
                
        }
        public DbSet<User> Blogs { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
        //    {
        //        options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        //    });
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            IamBuilder.Build(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
