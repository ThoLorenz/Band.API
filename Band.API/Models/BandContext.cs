using System;
using Microsoft.EntityFrameworkCore;

namespace Band.API.Models
    {
    public class BandContext : DbContext
        {
        public BandContext(DbContextOptions options) : base(options)
            {
            }

        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            // Database.EnsureCreated();
            }
        }
    }
