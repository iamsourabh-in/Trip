﻿using Microsoft.EntityFrameworkCore;
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
    public class ProfileReaderDbContext : DbContext
    {
        public DbSet<User> Blogs { get; set; }

        public ProfileReaderDbContext(DbContextOptions<ProfileReaderDbContext> options) : base(options)
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
