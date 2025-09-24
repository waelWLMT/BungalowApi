using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WLMT.Bungalows.Domain.Entities;

namespace WLMT.Bungalows.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }

        public DbSet<Campaign> Campaigns => Set<Campaign>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>().HasKey(c => c.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
