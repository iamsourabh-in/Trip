using Microsoft.EntityFrameworkCore;
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
        public CreatorWriterDbContext(DbContextOptions<CreatorWriterDbContext> options) : base(options)
        {

        }
    }
}
